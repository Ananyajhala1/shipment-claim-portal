import React, { useState, useEffect } from 'react';
import ClaimsForm from '../Presentation/form';

const ClaimsFormContainer = ({ currentClaim, onCreate, onUpdate }) => {
  const [formData, setFormData] = useState({
    fileDate: '',
    customerId: '',
    carrierId: '',
    insuranceId: ''
  });

  useEffect(() => {
    if (currentClaim) {
      setFormData({
        fileDate: currentClaim.fileDate,
        customerId: currentClaim.customerId,
        carrierId: currentClaim.carrierId,
        insuranceId: currentClaim.insuranceId
      });
    } else {
      setFormData({
        fileDate: '',
        customerId: '',
        carrierId: '',
        insuranceId: ''
      });
    }
  }, [currentClaim]);

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    if (currentClaim) {
      onUpdate(currentClaim.claimId, formData);
    } else {
      onCreate(formData);
    }
  };

  return (
    <ClaimsForm
      formData={formData}
      handleChange={handleChange}
      handleSubmit={handleSubmit}
      isEdit={!!currentClaim}
    />
  );
};

export default ClaimsFormContainer;
