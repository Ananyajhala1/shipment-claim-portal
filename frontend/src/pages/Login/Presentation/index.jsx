import React, { useState } from 'react';
import { Container, Box, Typography, TextField, FormControlLabel, Checkbox, Button, Grid, Link } from '@mui/material';

export default function Signin({ username, setUsername, password, setPassword, userDetails, error, handleSubmit }) {
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  const handleFormSubmit = (e) => {
    handleSubmit(e);
    setIsLoggedIn(true);
  };

  return (
    <div className="flex flex-col items-center mt-12 font-sans">
      {(!isLoggedIn || error) && (
        <Container component="main" maxWidth="xs">
          <Box
            sx={{
              marginTop: 8,
              display: 'flex',
              flexDirection: 'column',
              alignItems: 'center',
            }}
          >
            <Typography component="h1" variant="h5">
              Sign in
            </Typography>
            <Box component="form" onSubmit={handleFormSubmit} noValidate sx={{ mt: 1 }}>
              <TextField
                margin="normal"
                required
                fullWidth
                id="email"
                label="Username"
                name="email"
                autoComplete="email"
                autoFocus
                onChange={(e) => setUsername(e.target.value)}
              />
              <TextField
                margin="normal"
                required
                fullWidth
                name="password"
                label="Password"
                type="password"
                id="password"
                autoComplete="current-password"
                onChange={(e) => setPassword(e.target.value)}
              />
              <FormControlLabel
                control={<Checkbox value="remember" color="primary" />}
                label="Remember me"
              />
              {error && <Typography variant="body2" color="error">{error}</Typography>}
              <Button
                type="submit"
                fullWidth
                variant="contained"
                sx={{ mt: 3, mb: 2 }}
              >
                Sign In
              </Button>
              <Grid container>
                <Grid item xs>
                  <Link href="#" variant="body2">
                    Forgot password?
                  </Link>
                </Grid>
                <Grid item>
                  <Link href="#" variant="body2">
                    {"Don't have an account? Sign Up"}
                  </Link>
                </Grid>
              </Grid>
            </Box>
          </Box>
        </Container>
      )}
      {isLoggedIn && !error && userDetails && (
        <div className="w-full max-w-sm bg-white shadow-md rounded px-8 pt-6 pb-8 mt-4">
          <h2 className="text-xl font-bold mb-4">User Details</h2>
          <p className="mb-2"><strong>First Name:</strong> {userDetails.firstName}</p>
          <p className="mb-2"><strong>Company Name:</strong> {userDetails.companyName}</p>
          <p className="mb-2"><strong>Company ID:</strong> {userDetails.companyId}</p>
        </div>
      )}
    </div>
  );
}
