import React from 'react';
import { TextField, Button, Box, AppBar, Toolbar, Typography } from '@mui/material';

const ClaimsForm = ({ formData, handleChange, handleSubmit, isEdit }) => {
  return (
    <Box sx={{ flexGrow: 1 }}>
      <AppBar position="static">
        <Toolbar>
          <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
            {isEdit ? 'Update Claim' : 'Create Claim'}
          </Typography>
        </Toolbar>
      </AppBar>
      <Box
        component="form"
        sx={{
          '& .MuiTextField-root': { m: 1, width: '25ch' },
          display: 'flex',
          flexDirection: 'column',
          alignItems: 'center',
          p: 2
        }}
        onSubmit={handleSubmit}
      >
        <TextField
          label="File Date"
          name="fileDate"
          type="date"
          value={formData.fileDate}
          onChange={handleChange}
          InputLabelProps={{
            shrink: true,
          }}
        />
        <TextField
          label="Customer ID"
          name="customerId"
          type="number"
          value={formData.customerId}
          onChange={handleChange}
        />
        <TextField
          label="Carrier ID"
          name="carrierId"
          type="number"
          value={formData.carrierId}
          onChange={handleChange}
        />
        <TextField
          label="Insurance ID"
          name="insuranceId"
          type="number"
          value={formData.insuranceId}
          onChange={handleChange}
        />
        <Button variant="contained" color="primary" type="submit">
          {isEdit ? 'Update' : 'Submit'}
        </Button>
      </Box>
    </Box>
  );
};

export default ClaimsForm;
