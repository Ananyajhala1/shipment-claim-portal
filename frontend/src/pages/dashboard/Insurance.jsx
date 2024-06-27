import React from 'react';
import { FormControl, InputLabel, TextField, Select, MenuItem } from '@mui/material';
import TopPart from '../components/CarrierComponent/Topbar';

const Insurance = () => {
    return (
        <div>
            <TopPart props={"New Insurance"} />

            <div style={{ display: 'grid', gridTemplateColumns: '1fr 1fr 1fr', gap: '16px', marginTop: '16px' }}>
                <FormControl variant="outlined" fullWidth>
                    <InputLabel htmlFor="insurance-code-input">Insurance Code</InputLabel>
                    <TextField
                        id="insurance-code-input"
                        variant="outlined"
                        label="Insurance Code"
                        fullWidth
                    />
                </FormControl>
                <FormControl variant="outlined" fullWidth>
                    <InputLabel htmlFor="insurance-name-input">Insurance Name</InputLabel>
                    <TextField
                        id="insurance-name-input"
                        variant="outlined"
                        label="Insurance Name"
                        fullWidth
                    />
                </FormControl>
                <FormControl variant="outlined" fullWidth>
                    <InputLabel htmlFor="corporate-input">Corporate</InputLabel>
                    <TextField
                        id="corporate-input"
                        variant="outlined"
                        label="Corporate"
                        fullWidth
                    />
                </FormControl>
            </div>

            <div style={{ display: 'grid', gridTemplateColumns: '1fr', gap: '16px', marginTop: '16px' }}>
                <FormControl variant="outlined" fullWidth>
                    <InputLabel htmlFor="policy-number-input">Policy Number</InputLabel>
                    <TextField
                        id="policy-number-input"
                        variant="outlined"
                        label="Policy Number"
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
            </div>

            <div style={{ display: 'grid', gridTemplateColumns: '1fr 1fr 1fr', gap: '16px', marginTop: '16px' }}>
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
                <FormControl variant="outlined" fullWidth>
                    <InputLabel id="country-select-label">Country</InputLabel>
                    <Select
                        labelId="country-select-label"
                        id="country-select"
                        label="Country"
                        fullWidth
                    >
                        <MenuItem value="USA">USA</MenuItem>
                        <MenuItem value="India">India</MenuItem>
                        <MenuItem value="Russia">Russia</MenuItem>
                    </Select>
                </FormControl>
            </div>

            <div style={{ display: 'grid', gridTemplateColumns: '1fr 1fr 1fr', gap: '16px', marginTop: '16px' }}>
                <FormControl variant="outlined" fullWidth>
                    <InputLabel htmlFor="phone-input">Phone</InputLabel>
                    <TextField
                        id="phone-input"
                        variant="outlined"
                        label="Phone"
                        fullWidth
                    />
                </FormControl>
                <FormControl variant="outlined" fullWidth>
                    <InputLabel htmlFor="ext-input">Ext</InputLabel>
                    <TextField
                        id="ext-input"
                        variant="outlined"
                        label="Ext"
                        fullWidth
                    />
                </FormControl>
                <FormControl variant="outlined" fullWidth>
                    <InputLabel htmlFor="fax-input">Fax</InputLabel>
                    <TextField
                        id="fax-input"
                        variant="outlined"
                        label="Fax"
                        fullWidth
                    />
                </FormControl>
            </div>

            <div style={{ display: 'grid', gridTemplateColumns: '1fr', gap: '16px', marginTop: '16px' }}>
                <FormControl variant="outlined" fullWidth>
                    <InputLabel htmlFor="email-input">Email Address</InputLabel>
                    <TextField
                        id="email-input"
                        variant="outlined"
                        label="Email Address"
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

export default Insurance;
