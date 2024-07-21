import React, { useState } from 'react';
import axios from 'axios';
import Signin from '../Presentation/index';

const Login = () => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [userDetails, setUserDetails] = useState(null);
  const [error, setError] = useState('');

  const handleSubmit = async (e) => {
    e.preventDefault();

    const params = new URLSearchParams({ username, password }).toString();
    const url = `https://localhost:7265/api/Login?${params}`;

    try {
      const response = await axios.post(url);

      if (response.status === 200) {
        const data = response.data;
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
    } catch (err) {
      console.error('Network error:', err);
      setError('Login failed. Please check your username and password.');
      setUserDetails(null);
    }
  };

  return (
    <div>
      <Signin username = {username} setUsername = {setUsername} password={password} setPassword={setPassword} userDetails = {userDetails} error={error} handleSubmit = {handleSubmit}/>
    </div>
  )
};

export default Login;
