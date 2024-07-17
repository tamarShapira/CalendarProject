import { Box, Typography } from "@mui/material";
import React from "react";

const PageNotFound = () => {

    return (
        <Box
            sx={{
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'center',
                minHeight: '100vh',
                backgroundColor: "white",
                flexDirection: "column"
            }}
        >
           
            <Typography variant="h1" style={{ color: '#FF5733' }}>
                404 
            </Typography>
             <Typography variant="h3" style={{ color: 'black' }}>
                page not found 
            </Typography>
           
        </Box>
    )
}
export default PageNotFound;