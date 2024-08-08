import React, { useState, useEffect } from 'react';
import axios from 'axios';
import Typography from '@mui/material/Typography';
import Button from '@mui/material/Button';
import Paper from '@mui/material/Paper';

// Project imports
import MainCard from 'components/MainCard';
import UsersTable from '../presentation/UsersTable'; // Updated path
import UserForm from '../presentation/UserForm'; // Updated path
import RolesContainer from './RolesContainer'; // Updated path

// Function to create a user
function createUser(firstName, lastName, contactNumber, email, companyId) {
  return { firstName, lastName, contactNumber, email, companyId };
}

function descendingComparator(a, b, orderBy) {
  if (b[orderBy] < a[orderBy]) {
    return -1;
  }
  if (b[orderBy] > a[orderBy]) {
    return 1;
  }
  return 0;
}

function getComparator(order, orderBy) {
  return order === 'desc'
    ? (a, b) => descendingComparator(a, b, orderBy)
    : (a, b) => -descendingComparator(a, b, orderBy);
}

function stableSort(array, comparator) {
  const stabilizedThis = array.map((el, index) => [el, index]);
  stabilizedThis.sort((a, b) => {
    const order = comparator(a[0], b[0]);
    if (order !== 0) {
      return order;
    }
    return a[1] - b[1];
  });
  return stabilizedThis.map((el) => el[0]);
}

export default function DashboardDefault() {
  const [users, setUsers] = useState([]);
  const [isUserFormVisible, setIsUserFormVisible] = useState(false);
  const [isEdit, setIsEdit] = useState(false);
  const [selectedUser, setSelectedUser] = useState(null);
  const [formData, setFormData] = useState({
    firstName: '',
    lastName: '',
    contactNumber: '',
    email: '',
    companyId: localStorage.getItem('companyId') || 0  // Get companyId from local storage
  });

  const [order, setOrder] = useState('asc');
  const [orderBy, setOrderBy] = useState('firstName');

  const [isRolesContainerOpen, setIsRolesContainerOpen] = useState(false);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchUsers = async () => {
      try {
        const companyId = localStorage.getItem('companyId');
        const response = await axios.get(`https://localhost:7265/api/UserInfo/CompanyUsers?cid=${companyId}`);
        setUsers(response.data);
        setLoading(false);
      } catch (error) {
        console.error('Error fetching users', error);
        setLoading(false);
      }
    };
    fetchUsers();
  }, []);

  const handleRequestSort = (property) => {
    const isAscending = orderBy === property && order === 'asc';
    setOrder(isAscending ? 'desc' : 'asc');
    setOrderBy(property);
  };

  const handleUserClickOpen = () => {
    setIsUserFormVisible(!isUserFormVisible);
    setIsEdit(false);
    setSelectedUser(null);
    setFormData({
      firstName: '',
      lastName: '',
      contactNumber: '',
      email: '',
      companyId: localStorage.getItem('companyId') || 0
    });
  };

  const handleEditClick = (user) => {
    setSelectedUser(user);
    setFormData(user);
    setIsEdit(true);
    setIsUserFormVisible(true);
  };

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.name === 'companyId' ? parseInt(e.target.value, 10) : e.target.value
    });
  };

  const handleSubmit = (event) => {
    event.preventDefault();
    if (isEdit) {
      handleEditUser();
    } else {
      handleAddUser();
    }
  };

  const handleAddUser = async () => {
    const newUser = createUser(
      formData.firstName,
      formData.lastName,
      formData.contactNumber,
      formData.email,
      formData.companyId
    );

    try {
      const response = await axios.post('https://localhost:7265/api/UserInfo/CreateUser', newUser);
      if (response.status === 200 || response.status === 201) {
        setUsers([...users, newUser]);
        setIsUserFormVisible(false);
      } else {
        console.error('Failed to add user', response);
      }
    } catch (error) {
      console.error('Error adding user', error);
    }
  };

  const handleEditUser = async () => {
    try {
      const response = await axios.put('https://localhost:7265/api/UserInfo/UpdateUser', formData);
      if (response.status === 200) {
        setUsers(users.map(user => user.id === formData.id ? response.data : user));
        setIsUserFormVisible(false);
      } else {
        console.error('Failed to update user', response);
      }
    } catch (error) {
      console.error('Error updating user', error);
    }
  };

  if (loading) {
    return <div>Loading...</div>;
  }

  return (
    <div style={{ padding: '16px' }}>
      {/* Users Section */}
      <div style={{ marginBottom: '16px' }}>
        <Typography variant="h5">Users</Typography>
        <Button variant="contained" color="primary" onClick={handleUserClickOpen}>
          {isUserFormVisible ? 'Close Form' : 'Add User'}
        </Button>
      </div>
      {isUserFormVisible && (
        <Paper sx={{ mt: 2, p: 2 }}>
          <UserForm 
            formData={formData} 
            handleChange={handleChange} 
            handleSubmit={handleSubmit}
            isEdit={isEdit} 
            setIsFormVisible={setIsUserFormVisible} 
          />
        </Paper>
      )}
      <MainCard sx={{ mt: 2 }} content={false}>
        <UsersTable 
          users={stableSort(users, getComparator(order, orderBy))}
          setUsers={setUsers} 
          handleEditClick={handleEditClick}
          order={order}
          orderBy={orderBy}
          handleRequestSort={handleRequestSort}
        />
      </MainCard>

      {/* Roles Section */}
      <div style={{ marginTop: '32px', marginBottom: '16px' }}>
        <Typography variant="h5">Roles</Typography>
        <Button variant="contained" color="primary" onClick={() => setIsRolesContainerOpen(!isRolesContainerOpen)}>
          {isRolesContainerOpen ? 'Close Form' : 'Add Role'}
        </Button>
      </div>
      {isRolesContainerOpen && (
        <Paper sx={{ mt: 2, p: 2 }}>
          <RolesContainer />
        </Paper>
      )}
      <MainCard sx={{ mt: 2 }} content={false}>
        <RolesContainer />
      </MainCard>
    </div>
  );
}