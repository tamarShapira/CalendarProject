import React, { useState } from "react";
import { TextField } from "@mui/material";
export default function ValidatedTextField({isDisabled = false, isRequired, value,name, label, validator, onChange, inputProps = {} }) {
   
    const [error, setError] = useState(false);


    const handleChange = e => {
        const newValue =e.target.value;
        const errorMessage = validator(newValue);
        setError(errorMessage);
        onChange(!errorMessage);
    };

    return (
        <TextField
            margin="normal"
            name={name}
            required={isRequired}
            fullWidth
            label={label}
            value={value}
            onChange={handleChange}
            error={!!error}
            helperText={error}
            inputProps={inputProps ? inputProps : {}}
            disabled = {isDisabled}
        />
    );
}

