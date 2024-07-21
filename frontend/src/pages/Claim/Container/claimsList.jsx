import React from 'react';
import ClaimsList from '../Presentation/list';

const ClaimsListContainer = ({ claims, onDelete, onEdit }) => {
  return (
    <ClaimsList
      claims={claims}
      onDelete={onDelete}
      onEdit={onEdit}
    />
  );
};

export default ClaimsListContainer;
