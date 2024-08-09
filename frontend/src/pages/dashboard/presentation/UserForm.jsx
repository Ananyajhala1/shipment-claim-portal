import React from 'react';
import { Button, TextField, FormGroup, Stack } from '@mui/material';
import PropTypes from 'prop-types';

function UserForm({ formData, handleChange, handleSubmit, isEdit, setIsFormVisible }) {
  return (
    <FormGroup>

      <TextField
        label="First Name"
        name="firstName"
        value={formData.firstName}
        onChange={handleChange}
        fullWidth
        sx={{ mb: 2 }}
      />
      <TextField
        label="Last Name"
        name="lastName"
        value={formData.lastName}
        onChange={handleChange}
        fullWidth
        sx={{ mb: 2 }}
      />
      <TextField
        label="Contact Number"
        name="contactNumber"
        value={formData.contactNumber}
        onChange={handleChange}
        fullWidth
        sx={{ mb: 2 }}
      />
      <TextField
        label="Email"
        name="email"
        value={formData.email}
        onChange={handleChange}
        fullWidth
        sx={{ mb: 2 }}
      />

      <Stack direction="row" spacing={2} justifyContent="flex-end">
        <Button onClick={() => setIsFormVisible(false)} color="secondary">
          Cancel
        </Button>
        <Button onClick={handleSubmit} color="primary">
          {isEdit ? 'Save' : 'Submit'}
        </Button>
      </Stack>
    </FormGroup>
  );
}

UserForm.propTypes = {
  formData: PropTypes.object.isRequired,
  handleChange: PropTypes.func.isRequired,
  handleSubmit: PropTypes.func.isRequired,
  isEdit: PropTypes.bool.isRequired,
  setIsFormVisible: PropTypes.func.isRequired
};

export default UserForm;