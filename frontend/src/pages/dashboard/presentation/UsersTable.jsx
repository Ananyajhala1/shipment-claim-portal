import React from 'react';
import PropTypes from 'prop-types';
import {
  Table, TableBody, TableCell, TableContainer, TableHead, TableRow,
  Typography, IconButton, Paper, TableSortLabel
} from '@mui/material';
import EditIcon from '@mui/icons-material/Edit';

// Project import
import Dot from 'components/@extended/Dot';

const headCells = [
  { id: 'firstName', align: 'left', disablePadding: false, label: 'First Name' },
  { id: 'lastName', align: 'left', disablePadding: false, label: 'Last Name' },
  { id: 'contactNumber', align: 'left', disablePadding: false, label: 'Contact Number' },
  { id: 'email', align: 'left', disablePadding: false, label: 'Email' },
  { id: 'companyId', align: 'left', disablePadding: false, label: 'Company ID' },
  { id: 'actions', align: 'center', disablePadding: false, label: 'Actions' }
];

function UserTableHead({ order, orderBy, onRequestSort }) {
  const createSortHandler = (property) => (event) => {
    onRequestSort(property);
  };

  return (
    <TableHead>
      <TableRow>
        {headCells.map((headCell) => (
          <TableCell
            key={headCell.id}
            align={headCell.align}
            padding={headCell.disablePadding ? 'none' : 'normal'}
            sortDirection={orderBy === headCell.id ? order : false}
          >
            <TableSortLabel
              active={orderBy === headCell.id}
              direction={orderBy === headCell.id ? order : 'asc'}
              onClick={createSortHandler(headCell.id)}
            >
              {headCell.label}
            </TableSortLabel>
          </TableCell>
        ))}
      </TableRow>
    </TableHead>
  );
}

function UsersTable({ users, setUsers, handleEditClick, order, orderBy, handleRequestSort }) {
  return (
    <TableContainer component={Paper}>
      <Table aria-labelledby="tableTitle" size="medium" aria-label="enhanced table">
        <UserTableHead order={order} orderBy={orderBy} onRequestSort={handleRequestSort} />
        <TableBody>
          {users.map((user, index) => (
            <TableRow key={index}>
              <TableCell>{user.firstName}</TableCell>
              <TableCell>{user.lastName}</TableCell>
              <TableCell>{user.contactNumber}</TableCell>
              <TableCell>{user.email}</TableCell>
              <TableCell>{user.companyId}</TableCell>
              <TableCell align="center">
                <IconButton onClick={() => handleEditClick(user)}>
                  <EditIcon />
                </IconButton>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
}

UsersTable.propTypes = {
  users: PropTypes.array.isRequired,
  setUsers: PropTypes.func.isRequired,
  handleEditClick: PropTypes.func.isRequired,
  order: PropTypes.string.isRequired,
  orderBy: PropTypes.string.isRequired,
  handleRequestSort: PropTypes.func.isRequired
};

export default UsersTable;