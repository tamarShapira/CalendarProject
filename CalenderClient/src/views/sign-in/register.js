import * as React from 'react';
import { useRef } from "react";
import { Link as RouterLink } from 'react-router-dom';
import { useDispatch } from 'react-redux';
import { enqueueSnackbar } from 'notistack';
import ValidatedTextField from '../../components/validatedTextField';
import Form from '../../components/form';
import { register } from '../../store/actions/auth-actions';
import SignIn from './sign-in';
import { emailValidator, phoneValidator, requiredValidator, tzValidator } from '../../helpers/validationsHelper';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import Link from '@mui/material/Link';
import Grid from '@mui/material/Grid';
import AppRegistrationIcon from '@mui/icons-material/AppRegistration';


const Register = ({ isRegister = true, title = "הרשמה", submitAction }) => {

  const dispatch = useDispatch();

  const formValid = useRef({
    firstName: '', email: '', phoneNumber: '', password: '', tz: '', lastName: ''
  });

  const handleSubmit = async (event) => {
    event.preventDefault();

    const formData = new FormData(event.target)
    const data = Object.fromEntries(formData.entries())
    const registerData = { ...data, IsAdmin: true }
    if (!isRegister) {
      submitAction(data);
    }

    try {
      dispatch(register(registerData));
    }
    catch (error) {
      enqueueSnackbar(error)
    }

  };

  return (
    <SignIn>
      <Form title={title} icon={<AppRegistrationIcon />} handleSubmit={handleSubmit}>
        <ValidatedTextField
          margin="normal"
          required
          fullWidth
          id="firstName"
          label="שם פרטי"
          name="firstName"
          autoComplete="firstName"
          autoFocus
          validator={requiredValidator}
          onChange={isValid => (formValid.current.firstName = isValid)}
        />
        <ValidatedTextField
          margin="normal"
          required
          fullWidth
          id="lastName"
          label="שם משפחה"
          name="lastName"
          autoComplete="lastName"
          autoFocus
          validator={requiredValidator}
          onChange={isValid => (formValid.current.lastName = isValid)}
        />
        <ValidatedTextField
          margin="normal"
          required
          fullWidth
          id="tz"
          label="מספר זהות"
          name="tz"
          autoComplete="tz"
          autoFocus
          type="number"
          inputProps={{
            maxLength: 9,
            minLength: 9,
          }}
          validator={tzValidator}
          onChange={isValid => (formValid.current.tz = isValid)}
        />


        <ValidatedTextField
          margin="normal"
          required
          fullWidth
          id="phoneNumber"
          label="טלפון"
          name="phoneNumber"
          autoComplete="phoneNumber"
          autoFocus
          type="tel"
          inputProps={{
            maxlength: 10,
            minlength: 9,
          }}
          validator={phoneValidator}
          onChange={isValid => (formValid.current.phoneNumber = isValid)}
        />
        <ValidatedTextField
          margin="normal"
          required
          fullWidth
          id="email"
          label="מייל"
          type="email"
          name="email"
          autoComplete="email"
          autoFocus
          validator={emailValidator}
          onChange={isValid => (formValid.current.email = isValid)}
        />
        {isRegister &&
          <ValidatedTextField
            margin="normal"
            required
            fullWidth
            name="password"
            label="סיסמה"
            type="password"
            id="password"
            autoComplete="current-password"
            validator={requiredValidator}
            onChange={isValid => (formValid.current.password = isValid)}
          />
        }
        <Button
          type="submit"
          fullWidth
          variant="contained"
          sx={{ mt: 3, mb: 2 }}
        >
          שמירה
        </Button>
        {isRegister &&
          <Grid container>
            <Grid item>
              <Link component={RouterLink} to="/login" variant="body2">
                {"יש לך חשבון? היכנס"}
              </Link>
            </Grid>
          </Grid>
        }
      </Form>
    </SignIn>
  );
}

export default Register;