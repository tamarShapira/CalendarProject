import React from "react";
import loginImage from '../../assets/desk-calendar-with-texts-english.jpg';
import { Grid } from "@mui/material";

const SignIn = ({children}) => {
  return (
    <Grid container component="main" sx={{ height: '100vh' }}>
      <Grid
          item
          xs={false}
          sm={4}
          md={7}
          sx={{
            backgroundImage: `url("${loginImage}")`,
            backgroundRepeat: 'no-repeat',
            backgroundSize: 'cover',
            backgroundPosition: 'center',
          }}
        />
        {children}
    </Grid>
  )
}

export default SignIn;