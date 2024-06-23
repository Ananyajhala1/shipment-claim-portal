import React from 'react';
import { FormControl, InputLabel, TextField } from '@mui/material';
import TopPart from '../components/CarrierComponent/Topbar';

const CapacityProvider = () => {
    return (
        <div>
            <TopPart props={"Add Custom Capacity Provider"} />

            <div style={{ display: 'grid', gridTemplateColumns: '1fr 1fr 1fr', gap: '16px', marginTop: '16px' }}>
                <FormControl variant="outlined" fullWidth>
                    <InputLabel htmlFor="carrier-provider-name-input">Carrier Provider Name</InputLabel>
                    <TextField
                        id="carrier-provider-name-input"
                        variant="outlined"
                        label="Carrier Provider Name"
                        fullWidth
                    />
                </FormControl>
                <FormControl variant="outlined" fullWidth>
                    <InputLabel htmlFor="dba-input">DBA</InputLabel>
                    <TextField
                        id="dba-input"
                        variant="outlined"
                        label="DBA"
                        fullWidth
                    />
                </FormControl>
            </div>

            <div style={{ display: 'grid', gridTemplateColumns: '1fr 1fr 1fr', gap: '16px', marginTop: '16px' }}>
                <FormControl variant="outlined" fullWidth>
                    <InputLabel htmlFor="carrier-code-input">Carrier Code/SCAC</InputLabel>
                    <TextField
                        id="carrier-code-input"
                        variant="outlined"
                        label="Carrier Code/SCAC"
                        fullWidth
                    />
                </FormControl>
                <FormControl variant="outlined" fullWidth>
                    <InputLabel htmlFor="mc-number-input">MC Number</InputLabel>
                    <TextField
                        id="mc-number-input"
                        variant="outlined"
                        label="MC Number"
                        fullWidth
                    />
                </FormControl>
                <FormControl variant="outlined" fullWidth>
                    <InputLabel htmlFor="dot-number-input">DOT Number</InputLabel>
                    <TextField
                        id="dot-number-input"
                        variant="outlined"
                        label="DOT Number"
                        fullWidth
                    />
                </FormControl>
            </div>

            <div style={{ display: 'grid', gridTemplateColumns: '1fr 1fr 1fr', gap: '16px', marginTop: '16px' }}>
                <FormControl variant="outlined" fullWidth>
                    <InputLabel htmlFor="address-input">Address</InputLabel>
                    <TextField
                        id="address-input"
                        variant="outlined"
                        label="Address"
                        fullWidth
                    />
                </FormControl>
                <FormControl variant="outlined" fullWidth>
                    <InputLabel htmlFor="address-line2-input">Address Line 2</InputLabel>
                    <TextField
                        id="address-line2-input"
                        variant="outlined"
                        label="Address Line 2"
                        fullWidth
                    />
                </FormControl>
                <FormControl variant="outlined" fullWidth>
                    <InputLabel htmlFor="city-input">City</InputLabel>
                    <TextField
                        id="city-input"
                        variant="outlined"
                        label="City"
                        fullWidth
                    />
                </FormControl>
                <FormControl variant="outlined" fullWidth>
                    <InputLabel htmlFor="state-input">State</InputLabel>
                    <TextField
                        id="state-input"
                        variant="outlined"
                        label="State"
                        fullWidth
                    />
                </FormControl>
                <FormControl variant="outlined" fullWidth>
                    <InputLabel htmlFor="zip-input">Zip</InputLabel>
                    <TextField
                        id="zip-input"
                        variant="outlined"
                        label="Zip"
                        fullWidth
                    />
                </FormControl>
            </div>

            <div style={{ display: 'grid', gridTemplateColumns: '1fr', gap: '16px', marginTop: '16px' }}>
                <FormControl variant="outlined" fullWidth>
                    <InputLabel htmlFor="website-input">Website</InputLabel>
                    <TextField
                        id="website-input"
                        variant="outlined"
                        label="Website"
                        fullWidth
                    />
                </FormControl>
            </div>

        </div>
    );
};

export default CapacityProvider;
