import { FormControl, InputLabel, TextField} from '@mui/material';

export default function MiddlePart() {
    return (
        <div style={{marginTop: "10px"}}>
            {/* line 1 */}
            <div style={{ display: 'grid', gridTemplateColumns: '1fr 1fr 1fr', gap: '16px' }}>
                <FormControl variant="outlined" fullWidth>
                    <InputLabel htmlFor="customer-code-input"></InputLabel>
                    <TextField
                    id="customer-code-input"
                    placeholder=""
                    variant="outlined"
                    label="Claimant Name"
                    fullWidth
                    />
                </FormControl>
                <FormControl variant="outlined" fullWidth>
                    <InputLabel htmlFor="company-name-input"></InputLabel>
                    <TextField
                    id="company-name-input"
                    variant="outlined"
                    label="Claimant Email"
                    fullWidth
                    />
                </FormControl>
            </div>
            {/* line 2 */}
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
                <div style={{ display: 'grid', gridTemplateColumns: '2fr 1fr 1fr', gap: '16px'}}>
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
        </div>
    );
}
