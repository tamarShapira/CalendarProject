import React, { useState } from 'react';
import SignIn from './sign-in';
import { Button, TextField } from '@mui/material';
import Grid from '@mui/material/Grid';

const ForgotPassword = () => {

    const [email, setEmail] = useState('');

    const handleForgotPassword = async () => {
        try {
            const response = await fetch('YOUR_API_ENDPOINT', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ email }),
            });

            if (response.ok) {
                alert('Password recovery email sent successfully!');
            } else {
                const data = await response.json();
                alert(data.message);
            }
        } catch (error) {
            alert('An error occurred. Please try again later.');
        }
    };

    return (
        <>
            <Grid container component="main" sx={{ height: '100vh', }}>
                <Grid item sm={4} md={7}>
                    <SignIn>
                    </SignIn>
                </Grid>
                <Grid sx={{
                    my: 4,
                    mx: 25,
                    display: 'flex',
                    flexDirection: 'column',
                    alignItems: 'center',
                }}>
                    <Grid item>
                        <h2>שכחתי סיסמה</h2>
                    </Grid>
                    <Grid item>
                        <TextField
                            margin="normal"
                            required
                            label="Enter your email"
                            type="email"
                            placeholder=""
                            value={email}
                            onChange={(e) => setEmail(e.target.value)} />
                    </Grid>
                    <Grid item>
                        <Button
                            onClick={handleForgotPassword}
                            variant="contained"
                        >Send Recovery Email</Button>
                    </Grid>
                </Grid>
            </Grid>
        </>
    );
}
export default ForgotPassword;