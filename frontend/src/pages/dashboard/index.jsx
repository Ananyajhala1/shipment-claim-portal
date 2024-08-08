import React, { useState } from 'react';
import Avatar from '@mui/material/Avatar';
import AvatarGroup from '@mui/material/AvatarGroup';
import Button from '@mui/material/Button';
import Grid from '@mui/material/Grid';
import Stack from '@mui/material/Stack';
import Typography from '@mui/material/Typography';
import TextField from '@mui/material/TextField';
import Paper from '@mui/material/Paper';
import FormGroup from '@mui/material/FormGroup';

// project import
import MainCard from 'components/MainCard';
import OrdersTable from './UsersTable';
import RolesTable from './RolesTable';

// Function to create a user
function createUser(userId, id, firstName, lastName, contactNumber, email, companyId) {
  return { userId, id, firstName, lastName, contactNumber, email, companyId };
}

const initialUsers = [
  createUser(101, 1, 'John', 'Doe', '123-456-7890', 'john@example.com', 1),
  createUser(102, 2, 'Jane', 'Smith', '234-567-8901', 'jane@example.com', 0),
  createUser(103, 3, 'Sam', 'Wilson', '345-678-9012', 'sam@example.com', 1)
];

export default function DashboardDefault() {
  const [users, setUsers] = useState(initialUsers);
  const [isFormVisible, setIsFormVisible] = useState(false);
  const [isEdit, setIsEdit] = useState(false);
  const [selectedUser, setSelectedUser] = useState(null);
  const [formData, setFormData] = useState({
    firstName: '',
    lastName: '',
    contactNumber: '',
    email: '',
    companyId: 0
  });

  const handleClickOpen = () => {
    setIsFormVisible(!isFormVisible);
    setIsEdit(false);
    setSelectedUser(null);
    setFormData({
      firstName: '',
      lastName: '',
      contactNumber: '',
      email: '',
      companyId: 0
    });
  };

  const handleEditClick = (user) => {
    setSelectedUser(user);
    setFormData(user);
    setIsEdit(true);
    setIsFormVisible(true);
  };

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value
    });
  };

  const handleAddUser = () => {
    const newUserId = 101 + users.length;
    setUsers([
      ...users,
      createUser(newUserId, users.length + 1, formData.firstName, formData.lastName, formData.contactNumber, formData.email, formData.companyId)
    ]);
    setIsFormVisible(false);
  };

  const handleEditUser = () => {
    setUsers(users.map(user => user.id === selectedUser.id ? { ...selectedUser, ...formData } : user));
    setIsFormVisible(false);
  };

  const [roles, setRoles] = useState([]);
  const [isRoleFormVisible, setIsRoleFormVisible] = useState(false);
  const handleRoleClickOpen = () => {
    setIsRoleFormVisible(!isRoleFormVisible);
    setFormData({
      name: '',
      description: '',
      claims: [],
      permissions: []
    });
  };

  return (
    <Grid container rowSpacing={0} columnSpacing={0}>
      {/* row 3 */}
      <Grid item xs={12}>
        <Grid container alignItems="center" justifyContent="space-between">
          <Grid item>
            <Typography variant="h5">Users</Typography>
          </Grid>
          <Grid item>
            <Button variant="contained" color="primary" onClick={handleClickOpen}>
              {isFormVisible ? 'Close Form' : 'Add User'}
            </Button>
          </Grid>
        </Grid>
        {isFormVisible && (
          <Paper sx={{ mt: 2, p: 2 }}>
            <FormGroup>
              <TextField label="First Name" name="firstName" value={formData.firstName} onChange={handleChange} fullWidth sx={{ mb: 2 }} />
              <TextField label="Last Name" name="lastName" value={formData.lastName} onChange={handleChange} fullWidth sx={{ mb: 2 }} />
              <TextField label="Contact Number" name="contactNumber" value={formData.contactNumber} onChange={handleChange} fullWidth sx={{ mb: 2 }} />
              <TextField label="Email" name="email" value={formData.email} onChange={handleChange} fullWidth sx={{ mb: 2 }} />
              <TextField
                label="Company ID"
                name="companyId"
                select
                SelectProps={{ native: true }}
                value={formData.companyId}
                onChange={handleChange}
                fullWidth
              >
                <option value={1}>1</option>
                <option value={0}>0</option>
              </TextField>
              <Stack direction="row" spacing={2} justifyContent="flex-end">
                <Button onClick={() => setIsFormVisible(false)} color="secondary">
                  Cancel
                </Button>
                <Button onClick={isEdit ? handleEditUser : handleAddUser} color="primary">
                  {isEdit ? 'Save' : 'Submit'}
                </Button>
              </Stack>
            </FormGroup>
          </Paper>
        )}
        <MainCard sx={{ mt: 2 }} content={false}>
          <OrdersTable users={users} setUsers={setUsers} handleEditClick={handleEditClick} />
        </MainCard>
      </Grid>

      {/* row 4 */}
      <Grid item xs={12} sx={{ mt: 4 }}>
        <Grid container alignItems="center" justifyContent="space-between">
          <Grid item>
            <Typography variant="h5">Roles</Typography>
          </Grid>
          <Grid item>
            <Button variant="contained" color="primary" onClick={handleRoleClickOpen}>
              {isRoleFormVisible ? 'Close Form' : 'Add Role'}
            </Button>
          </Grid>
        </Grid>
        <MainCard sx={{ mt: 2 }} content={false}>
          <RolesTable
            roles={roles}
            setRoles={setRoles}
            isRoleFormVisible={isRoleFormVisible}
            handleRoleClickOpen={handleRoleClickOpen}
            formData={formData}
            setFormData={setFormData}
          />
        </MainCard>
      </Grid>
    </Grid>
  );
}
