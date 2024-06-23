import React from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import Button from '@mui/material/Button';
import IconButton from '@mui/material/IconButton';

// Remove type alias
// type TopPartProps = {
//     props: string;
// };

// Use JavaScript object for props instead
export default function TopPart({ props }) {
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
                    >
                        X
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
