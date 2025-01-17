// RolesTable.jsx
import React from 'react';
import PropTypes from 'prop-types';
import {
  Box, Button, Typography, Stack, TextField, Checkbox, FormControlLabel, FormGroup, Paper
} from '@mui/material';

function RolesTable({ roles, setRoles, isRoleFormVisible, handleRoleClickOpen, formData, setFormData }) {
  const handleCheckboxChange = (e, section) => {
    const { name, checked } = e.target;
    setFormData((prevData) => ({
      ...prevData,
      [section]: checked ? [...prevData[section], name] : prevData[section].filter((item) => item !== name)
    }));
  };

  const handleAddRole = () => {
    const newRole = {
      id: Date.now(), // Unique ID based on current timestamp
      name: formData.name,
      description: formData.description,
      claims: formData.claims.length,
      permissions: formData.permissions.length
    };
    setRoles([...roles, newRole]);
    handleRoleClickOpen(); // Close the form after adding role
  };

  return (
    <Box sx={{ display: 'flex', flexDirection: 'column', gap: '20px' }}>
      {isRoleFormVisible && (
        <Paper sx={{ mt: 2, p: 2 }}>
          <Stack spacing={2}>
            <TextField
              label="Role Name"
              name="name"
              value={formData.name}
              onChange={(e) => setFormData({ ...formData, name: e.target.value })}
              fullWidth
            />
            <TextField
              label="Description"
              name="description"
              value={formData.description}
              onChange={(e) => setFormData({ ...formData, description: e.target.value })}
              fullWidth
              multiline
              rows={4}
            />
            <Typography variant="h6">Claims Assignment</Typography>
            <FormGroup>
              <FormControlLabel
                control={<Checkbox onChange={(e) => handleCheckboxChange(e, 'claims')} name="Claim 1" />}
                label="Claim 1"
              />
              {/* Add more claims if needed */}
            </FormGroup>
            <Typography variant="h6">Permissions</Typography>
            <FormGroup>
              <FormControlLabel
                control={<Checkbox onChange={(e) => handleCheckboxChange(e, 'permissions')} name="Permission 1" />}
                label="Permission 1"
              />
              {/* Add more permissions if needed */}
            </FormGroup>
            <Stack direction="row" spacing={2} justifyContent="flex-end">
              <Button onClick={handleRoleClickOpen} color="secondary">
                Cancel
              </Button>
              <Button onClick={handleAddRole} color="primary">
                Submit
              </Button>
            </Stack>
          </Stack>
        </Paper>
      )}
      <Box sx={{ display: 'flex', flexDirection: 'row', flexWrap: 'wrap', gap: '20px' }}>
        {roles.map((role) => (
          <Paper key={role.id} sx={{ p: 2, minWidth: 200, maxWidth: 300 }}>
            <Typography variant="h6" fontWeight="bold">{role.name}</Typography>
            <Typography variant="body1">{role.description}</Typography>
            <Typography variant="body2" color="textSecondary">Claims Assigned: {role.claims}</Typography>
            <Typography variant="body2" color="textSecondary">Permissions Assigned: {role.permissions}</Typography>
          </Paper>
        ))}
      </Box>
    </Box>
  );
}

RolesTable.propTypes = {
  roles: PropTypes.array.isRequired,
  setRoles: PropTypes.func.isRequired,
  isRoleFormVisible: PropTypes.bool.isRequired,
  handleRoleClickOpen: PropTypes.func.isRequired,
  formData: PropTypes.object.isRequired,
  setFormData: PropTypes.func.isRequired,
};

export default RolesTable;
