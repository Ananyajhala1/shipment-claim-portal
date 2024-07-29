import React from 'react';
import { Table, TableBody, TableCell, TableHead, TableRow, IconButton } from '@mui/material';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';

const ClaimsList = ({ claims, onDelete, onEdit }) => {
  return (
    <Table>
      <TableHead>
        <TableRow>
          <TableCell>Claim ID</TableCell>
          <TableCell>File Date</TableCell>
          <TableCell>Customer ID</TableCell>
          <TableCell>Carrier ID</TableCell>
          <TableCell>Insurance ID</TableCell>
          <TableCell>Actions</TableCell>
        </TableRow>
      </TableHead>
      <TableBody>
      {claims && claims.length > 0 ? (
          claims.map((claim) => (
            <TableRow key={claim.claimId}>
              <TableCell>{claim.claimId}</TableCell>
              <TableCell>{claim.fileDate}</TableCell>
              <TableCell>{claim.customerId}</TableCell>
              <TableCell>{claim.carrierId}</TableCell>
              <TableCell>{claim.insuranceId}</TableCell>
              <TableCell>
                <IconButton onClick={() => onEdit(claim)}>
                  <EditIcon />
                </IconButton>
                <IconButton onClick={() => onDelete(claim.claimId)}>
                  <DeleteIcon />
                </IconButton>
              </TableCell>
            </TableRow>
          ))
        ) : (
          <TableRow>
            <TableCell colSpan={6} align="center">
              No claims available
            </TableCell>
          </TableRow>
        )}
      </TableBody>
    </Table>
  );
};

export default ClaimsList;
