import React from 'react';
import PropTypes from 'prop-types';
import {
  Link, Stack, Table, TableBody, TableCell, TableContainer, TableHead, TableRow,
  Typography, Box, IconButton, Paper
} from '@mui/material';
import EditIcon from '@mui/icons-material/Edit';

// project import
import Dot from 'components/@extended/Dot';

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
  { id: 'name', align: 'left', disablePadding: false, label: 'Name' },
  { id: 'email', align: 'left', disablePadding: false, label: 'Email' },
  { id: 'role', align: 'left', disablePadding: false, label: 'Role' },
  { id: 'dateJoined', align: 'left', disablePadding: false, label: 'Date Joined' },
  { id: 'status', align: 'left', disablePadding: false, label: 'Status' },
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

function UserStatus({ status }) {
  let color;
  let title;

  switch (status) {
    case 1:
      color = 'success';
      title = 'Active';
      break;
    case 0:
      color = 'error';
      title = 'Inactive';
      break;
    default:
      color = 'primary';
      title = 'Unknown';
  }

  return (
    <Stack direction="row" spacing={1} alignItems="center">
      <Dot color={color} />
      <Typography>{title}</Typography>
    </Stack>
  );
}

export default function UserTable({ users, setUsers, handleEditClick }) {
  const order = 'asc';
  const orderBy = 'name';

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
                    <Link color="secondary">{user.name}</Link>
                  </TableCell>
                  <TableCell sx={{ padding: '8px' }}>{user.email}</TableCell>
                  <TableCell sx={{ padding: '8px' }}>{user.role}</TableCell>
                  <TableCell sx={{ padding: '8px' }}>{user.dateJoined}</TableCell>
                  <TableCell sx={{ padding: '8px' }}>
                    <UserStatus status={user.status} />
                  </TableCell>
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
UserStatus.propTypes = { status: PropTypes.number };
