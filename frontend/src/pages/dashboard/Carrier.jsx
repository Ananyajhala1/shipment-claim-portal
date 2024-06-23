import React from 'react';
import Topbar from '../components/CarrierComponent/Topbar';
import TopPart from '../components/CarrierComponent/topPart';
import MiddlePart from '../components/CarrierComponent/MiddlePart';
import { CheckBox } from '@mui/icons-material';
import BottomPart from '../components/CarrierComponent/BottomPart';

const Carrier = () => {
    return (
        <div>
            <Topbar props={"New Customer"} />
            <div>
                <strong>Customer Primary Information</strong>
                <TopPart />
            </div>
            <div style={{ border: '0.5px solid grey', marginTop: '10px', borderRadius: '4px' }}>
                <div style={{ display: 'grid', gridTemplateColumns: '2fr 1fr', gap: '16px', marginTop: "10px" }}>
                    <strong>Claimant Information</strong>
                    <div>
                        <CheckBox />Same as customer
                        <CheckBox />Same as corporate
                    </div>
                </div>
                <div style={{ margin: "10px" }}>
                    <MiddlePart />
                </div>
            </div>
            <div style={{ border: '0.5px solid grey', marginTop: '10px', borderRadius: '4px' }}>
                <div style={{ display: 'grid', gridTemplateColumns: '2fr 1fr', gap: '16px', marginTop: "10px" }}>
                    <strong>Payee Information</strong>
                    <div>
                        <CheckBox />Same as customer
                        <CheckBox />Same as corporate
                    </div>
                </div>
                <div style={{ margin: "10px" }}>
                    <BottomPart />
                </div>
            </div>
        </div>
    );
}

export default Carrier;
