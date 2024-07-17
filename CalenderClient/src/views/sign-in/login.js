import * as React from 'react';
import  {useRef } from "react";
import { useDispatch } from 'react-redux';
import { useNavigate, Link as RouterLink } from 'react-router-dom';
import Form from '../../components/form';
import ValidatedTextField from '../../components/validatedTextField';

import { login } from '../../store/actions/auth-actions';
import SignIn from './sign-in';
import { tzValidator } from '../../helpers/validationsHelper';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import Link from '@mui/material/Link';
import Grid from '@mui/material/Grid';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';

export default function Login() {

  const dispatch = useDispatch();
  const navigate = useNavigate();

  const formValid = useRef( {
     tz: '',password: ''} );

  const handleSubmit = (event) => {
    event.preventDefault();

    const data = new FormData(event.target)
    const { tz, password } = Object.fromEntries(data.entries())
    dispatch(login(tz, password));
  };

  return (
    <SignIn>
      <Form title="כניסה" icon={<LockOutlinedIcon />} handleSubmit={handleSubmit}>
        <ValidatedTextField
          margin="normal"
          required
          fullWidth
          id="tz"
          label="שם משתמש"
          name="tz"
          autoComplete="tz"
          autoFocus
          inputProps={{
            maxLength: 9,
            minLength: 9,
          }}
          validator={tzValidator}
          onChange={isValid => (formValid.current.tz = isValid)}
        />
        <TextField
          margin="normal"
          required
          fullWidth
          name="password"
          label="סיסמה"
          type="password"
          id="password"
          autoComplete="current-password"
        />
        <Button
          type="submit"
          fullWidth
          variant="contained"
          sx={{ mt: 3, mb: 2 }}
        >
          כניסה
        </Button>
        <Grid container  justifyContent="space-between">
         
          <Grid item>
            <Link component={RouterLink} to="/register" variant="body2">
              {"אין לך חשבון? הירשם"}
            </Link>
          </Grid>
          <Grid item>
            <Link component={RouterLink} to="/forgotPassword" variant="body2" >
              {"שכחתי סיסמה"}
            </Link>
          </Grid>
        </Grid>
      </Form>
    </SignIn>
  );
}