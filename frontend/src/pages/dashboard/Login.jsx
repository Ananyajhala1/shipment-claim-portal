import React, { useState } from 'react';

const Login = () => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [userDetails, setUserDetails] = useState(null);
  const [error, setError] = useState('');

  const handleSubmit = async (e) => {
    e.preventDefault();

    const response = await fetch('https://localhost:7265/api/Login', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({ username, password }),
    });

    if (response.ok) {
      const data = await response.json();
      console.log(data);

      // Save the token and user details
      localStorage.setItem('authToken', data.authToken);
      localStorage.setItem('refreshToken', data.refreshToken);
      localStorage.setItem('firstName', data.firstName);
      localStorage.setItem('companyId', data.companyId);
      localStorage.setItem('companyName', data.companyName);

      // Update state to show user details
      setUserDetails(data);
      setError('');
    } else {
      console.error('Login failed');
      setError('Login failed. Please check your username and password.');
      // Clear user details in case of error
      setUserDetails(null);
    }
  };

  return (
<<<<<<< Updated upstream:frontend/src/pages/dashboard/Login.jsx
    <Box
      component="form"
      sx={{
        maxWidth: '500px',
        // margin: 'auto',
        padding: '20px',
        borderRadius: '8px',
        boxShadow: '0 4px 8px rgba(0,0,0,0.1)',
        backgroundColor: 'white',
        marginX: 'auto',
      }}
    >
      <Typography variant="h5" component="div" sx={{ mb: 2 }}>
        Login Form
      </Typography>
      <TextField
        fullWidth
        label="Username"

        margin="normal"
      />
      <TextField
        fullWidth
        type="password"
        label="Password"
        margin="normal"
        sx={{ mt: 2 }}
      />
      <Button type="submit" variant="contained" color="primary" fullWidth sx={{ mt: 2 }}>
        Login
      </Button>
      <Box sx={{ mt: 2, textAlign: 'center' }}>
        <Link href="#" variant="body2">
          Forgot Password?
        </Link>
        <Box mt={1}>
          <Link href="#" variant="body2">
            Don't have an account? Sign Up
          </Link>
        </Box>
      </Box>
    </Box>
=======
    <div>
      <form onSubmit={handleSubmit}>
        <div>
          <label>
            Username:
            <input type="text" value={username} onChange={(e) => setUsername(e.target.value)} />
          </label>
        </div>
        <div>
          <label>
            Password:
            <input type="password" value={password} onChange={(e) => setPassword(e.target.value)} />
          </label>
        </div>
        <button type="submit">Login</button>
      </form>
      
      {error && <p style={{ color: 'red' }}>{error}</p>}
      
      {userDetails && (
        <div>
          <h2>User Details</h2>
          <p><strong>First Name:</strong> {userDetails.firstName}</p>
          <p><strong>Company Name:</strong> {userDetails.companyName}</p>
          <p><strong>Company ID:</strong> {userDetails.companyId}</p>
          <p><strong>Auth Token:</strong> {userDetails.authToken}</p>
        </div>
      )}
    </div>
>>>>>>> Stashed changes:frontend/src/pages/Login/Presentation/index.jsx
  );
};

export default Login;
