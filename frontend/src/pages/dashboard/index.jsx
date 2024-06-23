import React, { useState } from 'react';
import Avatar from '@mui/material/Avatar';
import AvatarGroup from '@mui/material/AvatarGroup';
import Button from '@mui/material/Button';
import Grid from '@mui/material/Grid';
import List from '@mui/material/List';
import ListItemAvatar from '@mui/material/ListItemAvatar';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemSecondaryAction from '@mui/material/ListItemSecondaryAction';
import ListItemText from '@mui/material/ListItemText';
import Stack from '@mui/material/Stack';
import Typography from '@mui/material/Typography';
import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import Paper from '@mui/material/Paper';
import IconButton from '@mui/material/IconButton';
import FormGroup from '@mui/material/FormGroup'; // Import FormGroup

// project import
import MainCard from 'components/MainCard';
import OrdersTable from './OrdersTable';
import RolesTable from './RolesTable';

// Function to create a user
function createUser(id, name, email, role, dateJoined, status) {
  return { id, name, email, role, dateJoined, status };
}

const initialUsers = [
  createUser(1, 'John Doe', 'john@example.com', 'Admin', '2021-05-20', 1),
  createUser(2, 'Jane Smith', 'jane@example.com', 'User', '2022-03-14', 0),
  createUser(3, 'Sam Wilson', 'sam@example.com', 'Moderator', '2023-01-10', 1)
];

export default function DashboardDefault() {
  const [users, setUsers] = useState(initialUsers);
  const [isFormVisible, setIsFormVisible] = useState(false);
  const [isEdit, setIsEdit] = useState(false);
  const [selectedUser, setSelectedUser] = useState(null);
  const [formData, setFormData] = useState({
    name: '',
    email: '',
    role: '',
    dateJoined: '',
    status: 1
  });

  const handleClickOpen = () => {
    setIsFormVisible(!isFormVisible);
    setIsEdit(false);
    setSelectedUser(null);
    setFormData({
      name: '',
      email: '',
      role: '',
      dateJoined: '',
      status: 1
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
    setUsers([
      ...users,
      createUser(users.length + 1, formData.name, formData.email, formData.role, formData.dateJoined, formData.status)
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
            <TextField label="Name" name="name" value={formData.name} onChange={handleChange} fullWidth sx={{ mb: 2 }} />
<TextField label="Email" name="email" value={formData.email} onChange={handleChange} fullWidth sx={{ mb: 2 }} />
<TextField label="Role" name="role" value={formData.role} onChange={handleChange} fullWidth sx={{ mb: 2 }} />
              <TextField
                label="Date Joined"
                name="dateJoined"
                type="date"
                InputLabelProps={{ shrink: true }}
                value={formData.dateJoined}
                onChange={handleChange}
                fullWidth sx={{ mb: 2 }}
              />
              <TextField
                label="Status"
                name="status"
                select
                SelectProps={{ native: true }}
                value={formData.status}
                onChange={handleChange}
                fullWidth
              >
                <option value={1}>Active</option>
                <option value={0}>Inactive</option>
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
