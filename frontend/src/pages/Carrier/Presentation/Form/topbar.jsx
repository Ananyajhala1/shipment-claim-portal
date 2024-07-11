import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import Button from '@mui/material/Button';
import IconButton from '@mui/material/IconButton';


export default function Topbar({ props }) {
  return (
    <Box sx={{ flexGrow: 1 }}>
      <AppBar position="static" color="inherit" elevation={1}>
        <Toolbar>
          <IconButton
            size="small"
            edge="start"
            color="inherit"
            aria-label="menu"
            sx={{ mr: 2 }}
          >X
            {/* <Button  color="inherit" sx={{ height: '2px', width: '1px' }}>X</Button> */}
          </IconButton>
          <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
            {props}
          </Typography>
          <Button color="inherit" sx={{ color: 'green' }}>Cancel</Button>
          <Button variant="contained" color="inherit">Save</Button>
        </Toolbar>
      </AppBar>
    </Box>
  );
}
