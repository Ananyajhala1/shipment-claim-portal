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
  );
};

export default Login;
