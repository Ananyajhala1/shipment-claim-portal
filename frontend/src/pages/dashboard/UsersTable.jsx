import React from 'react';
import PropTypes from 'prop-types';
import {
  Link, Stack, Table, TableBody, TableCell, TableContainer, TableHead, TableRow,
  Typography, Box, IconButton, Paper
} from '@mui/material';
import EditIcon from '@mui/icons-material/Edit';


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
  return order === 'desc' ? (a, b) => descendingComparator(a, b, orderBy) : (a, b) => -descendingComparator(a, b, orderBy);
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

const headCells = [
  { id: 'userId', align: 'left', disablePadding: false, label: 'User ID' },
  { id: 'firstName', align: 'left', disablePadding: false, label: 'First Name' },
  { id: 'lastName', align: 'left', disablePadding: false, label: 'Last Name' },
  { id: 'contactNumber', align: 'left', disablePadding: false, label: 'Contact Number' },
  { id: 'email', align: 'left', disablePadding: false, label: 'Email' },
  { id: 'companyId', align: 'left', disablePadding: false, label: 'Company ID' },
  { id: 'actions', align: 'center', disablePadding: false, label: 'Actions' }
];

function UserTableHead({ order, orderBy }) {
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
            {headCell.label}
          </TableCell>
        ))}
      </TableRow>
    </TableHead>
  );
}

export default function UserTable({ users, setUsers, handleEditClick }) {
  const order = 'asc';
  const orderBy = 'userId';

  return (
    <Box sx={{ width: '100%' }}>
      <TableContainer component={Paper} sx={{ width: '100%', overflowX: 'auto' }}>
        <Table aria-labelledby="tableTitle" sx={{ minWidth: 750 }}>
          <UserTableHead order={order} orderBy={orderBy} />
          <TableBody>
            {stableSort(users, getComparator(order, orderBy)).map((user, index) => {
              const labelId = `enhanced-table-checkbox-${index}`;

              return (
                <TableRow
                  hover
                  role="checkbox"
                  sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                  tabIndex={-1}
                  key={user.id}
                >
                  <TableCell component="th" id={labelId} scope="row" sx={{ padding: '8px' }}>
                    <Link color="secondary">{user.userId}</Link>
                  </TableCell>
                  <TableCell sx={{ padding: '8px' }}>{user.firstName}</TableCell>
                  <TableCell sx={{ padding: '8px' }}>{user.lastName}</TableCell>
                  <TableCell sx={{ padding: '8px' }}>{user.contactNumber}</TableCell>
                  <TableCell sx={{ padding: '8px' }}>{user.email}</TableCell>
                  <TableCell sx={{ padding: '8px' }}>{user.companyId}</TableCell>
                  <TableCell align="center" sx={{ padding: '8px' }}>
                    <IconButton color="primary" onClick={() => handleEditClick(user)}>
                      <EditIcon />
                    </IconButton>
                  </TableCell>
                </TableRow>
              );
            })}
          </TableBody>
        </Table>
      </TableContainer>
    </Box>
  );
}

UserTable.propTypes = {
  users: PropTypes.array.isRequired,
  setUsers: PropTypes.func.isRequired,
  handleEditClick: PropTypes.func.isRequired
};

UserTableHead.propTypes = { order: PropTypes.any, orderBy: PropTypes.string };
