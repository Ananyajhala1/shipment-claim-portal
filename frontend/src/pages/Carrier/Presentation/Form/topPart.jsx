import { FormControl, InputLabel, TextField, Select, MenuItem } from '@mui/material';

export default function TopPart() {
    return (
        <div>
            <div style={{ display: 'grid', gridTemplateColumns: '1fr 1fr 1fr', gap: '16px' }}>
                <FormControl variant="outlined" fullWidth>
                    <InputLabel htmlFor="customer-code-input"></InputLabel>
                    <TextField
                    id="customer-code-input"
                    placeholder=""
                    variant="outlined"
                    label="Carrier Provider Name"
                    fullWidth
                    />
                </FormControl>
                <FormControl variant="outlined" fullWidth>
                    <InputLabel htmlFor="company-name-input"></InputLabel>
                    <TextField
                    id="company-name-input"
                    variant="outlined"
                    label="DBA"
                    fullWidth
                    />
                </FormControl>
            </div>
            <div style={{ display: 'grid', gridTemplateColumns: '1fr 1fr 1fr', gap: '16px', marginTop: '16px' }}>
                <FormControl variant="outlined" fullWidth>
                    <InputLabel htmlFor="customer-code-input"></InputLabel>
                    <TextField
                    id="customer-code-input"
                    placeholder=""
                    variant="outlined"
                    label="Carrier Code/SCAC"
                    fullWidth
                    />
                </FormControl>
                <FormControl variant="outlined" fullWidth>
                    <InputLabel htmlFor="company-name-input"></InputLabel>
                    <TextField
                    id="company-name-input"
                    variant="outlined"
                    label="MC Number"
                    fullWidth
                    />
                </FormControl>
                <FormControl variant="outlined" fullWidth>
                    <InputLabel htmlFor="company-name-input"></InputLabel>
                    <TextField
                    id="company-name-input"
                    variant="outlined"
                    label="DOT Number"
                    fullWidth
                    />
                </FormControl>
            </div>
            <div style={{ display: 'grid', gridTemplateColumns: '1fr 1fr 1fr', gap: '16px', marginTop: '16px' }}>
                <FormControl variant="outlined" fullWidth>
                    <InputLabel htmlFor="name-input"></InputLabel>
                    <TextField
                        id="name-input"
                        variant="outlined"
                        label="Address"
                        fullWidth
                    />
                </FormControl>
                <FormControl variant="outlined" fullWidth>
                    <InputLabel htmlFor="name-input"></InputLabel>
                    <TextField
                        id="name-input"
                        variant="outlined"
                        label="Address Line 2"
                        fullWidth
                    />
                </FormControl>
                <div style={{ display: 'grid', gridTemplateColumns: '2fr 1fr 1fr', gap: '16px',}}>
                    <FormControl variant="outlined" fullWidth>
                        <InputLabel htmlFor="name-input"></InputLabel>
                        <TextField
                            id="name-input"
                            variant="outlined"
                            label="City"
                            fullWidth
                        />
                    </FormControl>
                    <FormControl variant="outlined" fullWidth>
                        <InputLabel htmlFor="name-input"></InputLabel>
                        <TextField
                            id="name-input"
                            variant="outlined"
                            label="State"
                            fullWidth
                        />
                    </FormControl>
                    <FormControl variant="outlined" fullWidth>
                        <InputLabel htmlFor="name-input"></InputLabel>
                        <TextField
                            id="name-input"
                            variant="outlined"
                            label="Zip"
                            fullWidth
                        />
                    </FormControl>
                </div>
            </div>
            <div style={{ display: 'grid', gridTemplateColumns: '1fr 1fr 1fr', gap: '16px', marginTop: "16px" }}>
                <FormControl variant="outlined" fullWidth>
                    <InputLabel htmlFor="customer-code-input"></InputLabel>
                    <TextField
                    id="customer-code-input"
                    placeholder=""
                    variant="outlined"
                    label="Website"
                    fullWidth
                    />
                </FormControl>
            </div>
        </div>
    );
}
