// RolesContainer.jsx
import React, { useState } from 'react';
import RolesTable from '../presentation/RolesTable'; // Adjust the path if needed

const RolesContainer = () => {
  const [roles, setRoles] = useState([]);
  const [isRoleFormVisible, setIsRoleFormVisible] = useState(false);
  const [formData, setFormData] = useState({
    name: '',
    description: '',
    claims: [],
    permissions: []
  });

  const handleRoleClickOpen = () => {
    setIsRoleFormVisible(!isRoleFormVisible);
    if (isRoleFormVisible) {
      // Clear form when closing
      setFormData({
        name: '',
        description: '',
        claims: [],
        permissions: []
      });
    }
  };

  return (
    <div>
      <RolesTable
        roles={roles}
        setRoles={setRoles}
        isRoleFormVisible={isRoleFormVisible}
        handleRoleClickOpen={handleRoleClickOpen}
        formData={formData}
        setFormData={setFormData}
      />
    </div>
  );
};

export default RolesContainer;
