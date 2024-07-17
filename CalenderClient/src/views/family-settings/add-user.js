import React from 'react';
import  {useRef } from "react";
import { useDispatch, useSelector } from 'react-redux';
import { Link as RouterLink } from 'react-router-dom';
import Navbar from "../home/navbar";
import {  register } from '../../store/actions/auth-actions';
import ValidatedTextField from '../../components/validatedTextField';
import AuthService from '../../services/AuthService'
import { setTzEvent } from '../../store/actions/event-actions';
import { emailValidator, requiredValidator, tzValidator } from '../../helpers/validationsHelper';
import loginImage from '../../assets/6274.jpg';
import Form from '../../components/form';
import { enqueueSnackbar } from 'notistack';
import Link from '@mui/material/Link';
import Grid from '@mui/material/Grid';
import { Button } from '@mui/material';
import TextField from '@mui/material/TextField';
import { getCalendarEvents, getCalendarUsers, getCalendars } from '../../store/actions/calendar-actions';

const AddUser = () => {

  const dispatch = useDispatch();
  const { calendars } = useSelector(state => state.calendar);
  const currentCalendar = calendars.find(calendar => calendar.active);

  const formValid = useRef({
    firstName: '', email: '',  tz: '', lastName: ''
  });
  
  // useEffect(() => {
   

  // }, [])
  const handleSubmit = async (event) => {
    event.preventDefault();
    const formData = new FormData(event.target)
    const data = Object.fromEntries(formData.entries())
    const response = await AuthService.getUser();
    const userData =  { ...data, IsAdmin: false, CalendarId: currentCalendar.id ,Password:response.data.password}
    try {
      dispatch(register(userData));
     // dispatch(getCalendarUsers(currentCalendar.id));
     // dispatch(getCalendars());
      dispatch(setTzEvent(data.tz));
    }
    catch (error) {
      enqueueSnackbar(error)
    }
  }
  return (
<>
<Navbar></Navbar>
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
      <Form handleSubmit={handleSubmit}>
        <ValidatedTextField
          margin="normal"
          required
          fullWidth
          id="firstName"
          label="שם פרטי"
          name="firstName"
          autoComplete="firstName"
          autoFocus
          inputProps={{
            pattern: "[A-Za-z ]+",
          }}
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
          validator={tzValidator}
          onChange={isValid => (formValid.current.tz = isValid)}
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
          inputProps={{
            type: "email",
          }}
          validator={emailValidator}
          onChange={isValid => (formValid.current.email = isValid)}
        />
        <Button
          type="submit"
          fullWidth
          variant="contained"
          sx={{ mt: 3, mb: 2 }}
        >
          הוסף בן משפחה
        </Button>
        <Link component={RouterLink} to="/add-event" variant="body2">
          <Button
            fullWidth
            variant="outlined"
            sx={{ mt: 3, mb: 2 }}
          >
            {"הוספת אירוע"}
          </Button>
        </Link>
      </Form>
    </Grid>
    </>
  );
}

export default AddUser;
