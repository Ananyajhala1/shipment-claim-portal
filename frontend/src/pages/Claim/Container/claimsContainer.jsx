import React, { useState, useEffect } from 'react';
import ClaimsListContainer from './claimsList';
import ClaimsFormContainer from './form';
import { getClaims, createClaim, updateClaim, deleteClaim } from '../service';

const ClaimsContainer = () => {
  const [claims, setClaims] = useState([]);
  const [currentClaim, setCurrentClaim] = useState(null);

  useEffect(() => {
    fetchClaims();
  }, []);

  const fetchClaims = async () => {
    const data = await getClaims();
    setClaims(data);
  };

  const handleCreate = async (claim) => {
    await createClaim(claim);
    fetchClaims();
  };

  const handleUpdate = async (id, claim) => {
    await updateClaim(id, claim);
    fetchClaims();
    setCurrentClaim(null);
  };

  const handleDelete = async (id) => {
    await deleteClaim(id);
    fetchClaims();
  };

  const handleEdit = (claim) => {
    setCurrentClaim(claim);
  };

  return (
    <div>
      <ClaimsFormContainer
        currentClaim={currentClaim}
        onCreate={handleCreate}
        onUpdate={handleUpdate}
      />
      <ClaimsListContainer
        claims={claims}
        onDelete={handleDelete}
        onEdit={handleEdit}
      />
    </div>
  );
};

export default ClaimsContainer;
