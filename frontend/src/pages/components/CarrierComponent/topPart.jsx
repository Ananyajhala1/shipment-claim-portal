import React from 'react';
import { FormControl, InputLabel, TextField, Select, MenuItem } from '@mui/material';

export default function TopPart() {
    return (
        <div>
            {/* line 1 */}
            <div style={{ display: 'grid', gridTemplateColumns: '1fr 1fr 1fr', gap: '16px' }}>
                <FormControl variant="outlined" fullWidth>
                    <InputLabel htmlFor="customer-code-input">Customer Code</InputLabel>
                    <TextField
                        id="customer-code-input"
                        placeholder=""
                        variant="outlined"
                        fullWidth
                    />
                </FormControl>
                <FormControl variant="outlined" fullWidth>
                    <InputLabel htmlFor="company-name-input">Company Name</InputLabel>
                    <TextField
                        id="company-name-input"
                        variant="outlined"
                        fullWidth
                    />
                </FormControl>
            </div>
            {/* line 2 */}
            <div style={{ display: 'grid', gridTemplateColumns: '1fr 1fr 1fr', gap: '16px', marginTop: '16px' }}>
                <FormControl variant="outlined" fullWidth>
                    <InputLabel htmlFor="address-input">Address</InputLabel>
                    <TextField
                        id="address-input"
                        variant="outlined"
                        fullWidth
                    />
                </FormControl>
                <FormControl variant="outlined" fullWidth>
                    <InputLabel htmlFor="address-line2-input">Address Line 2</InputLabel>
                    <TextField
                        id="address-line2-input"
                        variant="outlined"
                        fullWidth
                    />
                </FormControl>
                <div style={{ display: 'grid', gridTemplateColumns: '2fr 1fr 1fr', gap: '16px'}}>
                    <FormControl variant="outlined" fullWidth>
                        <InputLabel htmlFor="city-input">City</InputLabel>
                        <TextField
                            id="city-input"
                            variant="outlined"
                            fullWidth
                        />
                    </FormControl>
                    <FormControl variant="outlined" fullWidth>
                        <InputLabel htmlFor="state-input">State</InputLabel>
                        <TextField
                            id="state-input"
                            variant="outlined"
                            fullWidth
                        />
                    </FormControl>
                    <FormControl variant="outlined" fullWidth>
                        <InputLabel htmlFor="zip-input">Zip</InputLabel>
                        <TextField
                            id="zip-input"
                            variant="outlined"
                            fullWidth
                        />
                    </FormControl>
                </div>
            </div>
            {/* line 3 */}
            <div style={{ display: 'grid', gridTemplateColumns: '1fr 1fr 1fr', gap: '16px', marginTop: '16px' }}>
                <div style={{ display: 'grid', gridTemplateColumns: '1fr 2fr 1.5fr', gap: '20px' }}>
                    <FormControl fullWidth>
                        <InputLabel id="country-select-label">Country</InputLabel>
                        <Select
                            labelId="country-select-label"
                            label="Country"
                            fullWidth
                        >
                            <MenuItem value="USA">USA</MenuItem>
                            <MenuItem value="India">India</MenuItem>
                            <MenuItem value="Russia">Russia</MenuItem>
                        </Select>
                    </FormControl>
                    <FormControl variant="outlined" fullWidth>
                        <InputLabel htmlFor="phone-input">Phone</InputLabel>
                        <TextField
                            id="phone-input"
                            variant="outlined"
                            fullWidth
                        />
                    </FormControl>
                    <FormControl variant="outlined" fullWidth>
                        <InputLabel htmlFor="ext-input">Ext</InputLabel>
                        <TextField
                            id="ext-input"
                            variant="outlined"
                            fullWidth
                        />
                    </FormControl>
                </div>
                <FormControl variant="outlined" fullWidth>
                    <InputLabel htmlFor="fax-input">Fax</InputLabel>
                    <TextField
                        id="fax-input"
                        variant="outlined"
                        fullWidth
                    />
                </FormControl>
                <FormControl variant="outlined" fullWidth>
                    <InputLabel htmlFor="email-input">Email Address</InputLabel>
                    <TextField
                        id="email-input"
                        variant="outlined"
                        fullWidth
                    />
                </FormControl>
            </div>
            {/* line 4 */}
            <div style={{ display: 'flex', gap: '16px', marginTop: '16px' }}>
                <FormControl variant="outlined" fullWidth>
                    <InputLabel htmlFor="website-input">Website</InputLabel>
                    <TextField
                        id="website-input"
                        variant="outlined"
                        fullWidth
                    />
                </FormControl>
                <FormControl variant="outlined" fullWidth>
                    <InputLabel htmlFor="sales-rep-input">Sales Rep or Agent</InputLabel>
                    <TextField
                        id="sales-rep-input"
                        variant="outlined"
                        fullWidth
                    />
                </FormControl>
                <FormControl variant="outlined" fullWidth>
                    <InputLabel htmlFor="sales-rep-email-input">Sales Rep or Agent Email</InputLabel>
                    <TextField
                        id="sales-rep-email-input"
                        variant="outlined"
                        fullWidth
                    />
                </FormControl>
            </div>
        </div>
    );
}
