import React, { useState } from 'react';
import axios from 'axios';
import CompanyTypeForm from '../Presentation/Form/CompanyTypeForm';

function Form() {
  const [companyType1, setCompanyType1] = useState('');

  const handleSubmit = async (event) => {
    event.preventDefault();
    try {
      const response = await axios.post('https://localhost:7265/api/CompanyType', {
        companyType1: companyType1,
      }, {
        headers: {
          'Content-Type': 'application/json',
          'accept': 'text/plain',
        },
      });
      console.log('Server Response:', response.data);
      // Handle success (e.g., showing a success message)
    } catch (error) {
      console.error('Error submitting form:', error);
      // Handle error (e.g., showing an error message)
    }
  };

  return (
    <CompanyTypeForm
      companyType1={companyType1}
      setCompanyType1={setCompanyType1}
      handleSubmit={handleSubmit}
    />
  );
}

export default Form;
