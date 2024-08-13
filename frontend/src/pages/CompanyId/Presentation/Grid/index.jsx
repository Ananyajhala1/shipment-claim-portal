import React from 'react';
import { Link } from 'react-router-dom';

export const Show = ({ users }) => {

    return (
        <div>
            {users.map((user) => (
                <div key={user.companyTypeId}>
                    <span>{user.companyType1}</span>
                </div>
            ))}
        </div>
    );
};
