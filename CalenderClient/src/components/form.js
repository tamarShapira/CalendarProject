import React from "react";
import { Avatar, Box, Grid, Typography } from "@mui/material";
import Paper from '@mui/material/Paper';


const Form = ({ children, title, icon, handleSubmit }) => {

  return (
    <Grid item xs={12} sm={6} md={5} component={Paper} elevation={6} square>
      <Box
        sx={{
          my: 4,
          mx: 2,
          display: 'flex',
          flexDirection: 'column',
          alignItems: 'center',
        }}
      >
        <Avatar sx={{ m: 1, bgcolor: '#FF5733' }}>
          {icon}
        </Avatar>
        <Typography component="h1" variant="h5"> {title}</Typography>
        <Box component="form" noValidate onSubmit={handleSubmit} sx={{ mt: 1 }}>
          {children}
        </Box>
      </Box>
    </Grid>
  )
}
export default Form;