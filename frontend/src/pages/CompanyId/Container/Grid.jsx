import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Show } from '../Presentation/Grid/index';
import Form from './Form';

export const User = () => {
    const [users, setUsers] = useState([]);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await axios.get('https://localhost:7265/api/CompanyType');
                setUsers(response.data);
            } catch (err) {
                setError(err.message);
            }
        };
        fetchData();
    }, []);

    const [showCarrier, setShowCarrier] = useState(true);
    const [showH1, setShowH1] = useState(false);

    const handleCarrierClick = () => {
        setShowCarrier(true);
        setShowH1(false);
    };

    const handleH1Click = () => {
        setShowCarrier(false);
        setShowH1(true);
    };
    if (error) {
        return <div>Error: {error}</div>;
    }

    if (!users.length) {
        return <div>Loading...</div>;
    }

    return (
        <div className="">
            <div>
                <button onClick={handleCarrierClick}>Form</button>
                <button onClick={handleH1Click}>Grid</button>
            </div>
            {showCarrier && <Form />}
            {showH1 && <Show users={users} />}
        </div>
    );
};
