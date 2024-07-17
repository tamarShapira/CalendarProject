import React, { useEffect } from 'react';
import { Link as RouterLink } from 'react-router-dom';
import { useSelector, useDispatch } from 'react-redux';
import loginImage from '../../assets/3884687.jpg';
import { addEvent } from '../../store/actions/event-actions';
import Form from '../../components/form';
import Navbar from "../home/navbar";
import { setTzEvent } from '../../store/actions/event-actions';
import dayjs from 'dayjs';
import { enqueueSnackbar } from 'notistack';
import FormGroup from '@mui/material/FormGroup';
import FormControlLabel from '@mui/material/FormControlLabel';
import Checkbox from '@mui/material/Checkbox';
import TextField from '@mui/material/TextField';
import Link from '@mui/material/Link';
import Grid from '@mui/material/Grid';
import { Button } from '@mui/material';
import { InputLabel, FormControl, Select, MenuItem, Box } from '@mui/material';
import { DemoContainer } from '@mui/x-date-pickers/internals/demo';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import EventIcon from '@mui/icons-material/Event';
import { getCalendarEvents, getCalendarUsers } from '../../store/actions/calendar-actions';

const AddEvent = () => {

  const [eventDate, setEventDate] = React.useState(dayjs());
  const [eventType, setEventType] = React.useState('');
  const [oneTimeEvent, setOneTimeEvent] = React.useState(false)
  const [eventForOne, setEventForOne] = React.useState(false)
  const [tzEventOwner, setTzEventOwner] = React.useState(useSelector(state => state.event.tzEventByaddUser))
  // const tzEvent = useSelector(state => state.event.tzEventByaddUser);

  const currentYear = new Date().getFullYear();
  const { calendars } = useSelector(state => state.calendar);
  const currentCalendar = calendars.find(calendar => calendar.active);

  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(getCalendarUsers(currentCalendar.id));
    if(tzEventOwner&&tzEventOwner[0]==0)
      setTzEventOwner(tzEventOwner.substring(1))
    dispatch(setTzEvent(null));

  },[])

  const handleSubmit = async (event) => {
    event.preventDefault();
    const formData = new FormData(event.target)
    const data = Object.fromEntries(formData.entries())
    if(data.tzOwnerName&&data.tzOwnerName[0]==0)
      data.tzOwnerName= data.tzOwnerName.substring(1)
    const tempData = { EventOwnerName: data.EventOwnerName, GregorianDate:String(data.GregorianDate), tzOwnerName: tzEventOwner?tzEventOwner:data.tzOwnerName }

    try {
      const currentUser = currentCalendar.users.find(user => String(user.tz) === tempData.tzOwnerName);
      if (!currentUser) {
        enqueueSnackbar("המשתמש שניסית להוסיף עבורו אירוע לא קיים בלוח", { variant: "error" });
        return;
      }
      const eventData = { CalendarId: currentCalendar.id, EventOwnerName: data.EventOwnerName, GregorianDate: String(data.GregorianDate), EventType: (eventType === "אירוע מיוחד" ? data.eevent : eventType), EventYear: String(currentYear), OneTimeEvent: oneTimeEvent, UserId: currentUser.id }
      dispatch(addEvent(eventData));
    }
    catch (error) {
      enqueueSnackbar(error)
    }
  }
  const handleDateChange = (e) => {
    setEventDate(e)
  }
  const handleTypeChange = (event) => {
    setEventType(event.target.value);
  };

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
        <Form icon={<EventIcon />} handleSubmit={handleSubmit}>
          <TextField

            margin="normal"
            required
            fullWidth
            id="eventOwnerName"
            label="שם בעל הארוע"
            name="EventOwnerName"
            autoComplete="eventOwnerName"
            autoFocus
            inputProps={{
              pattern: "[A-Za-z ]+",
            }}
          />
          <TextField
            margin="normal"
            required
            fullWidth
            id="tzOwnerName"
            name="tzOwnerName"
            autoComplete="tzOwnerName"
            placeholder={!tzEventOwner ? "תז בעל האירוע" : ""}
            autoFocus
            value={tzEventOwner}
            disabled={tzEventOwner ? true : false}
          />
          <Box sx={{ minWidth: 120 }}>
            <FormControl fullWidth>
              <InputLabel id="demo-simple-select-label">סוג ארוע</InputLabel>
              <Select
                labelId="demo-simple-select-label"
                id="demo-simple-select"

                label="סוג ארוע"
                onChange={handleTypeChange}
                value={eventType}
              >
                <MenuItem value={"יומולדת"}>יום הולדת</MenuItem>
                <MenuItem value={"יום נישואין"}>יום נישואין</MenuItem>
                <MenuItem value={"יום השנה"}>יום השנה</MenuItem>
                <MenuItem value={"אירוע מיוחד"}>ארוע מיוחד</MenuItem>

              </Select>
            </FormControl>

          </Box>
          {eventType === "אירוע מיוחד" && (
            <div>
              <TextField
                margin="normal"
                required
                fullWidth
                id="eevent"
                label="ארוע מיוחד"
                name="eevent"
                autoComplete="eevent"
                autoFocus
                type="text"
              />
              <FormGroup >
                <FormControlLabel control={<Checkbox defaultChecked value={oneTimeEvent} required checked={oneTimeEvent} onChange={() => { setOneTimeEvent(true) }} />} label="ארוע לשנה נוכחית בלבד" />
              </FormGroup>
            </div>

          )}
          <LocalizationProvider dateAdapter={AdapterDayjs}>
            <DemoContainer components={['DatePicker']}>
              <DatePicker
                label="תאריך ארוע"
                fullWidth
                value={eventDate}
                id="date"
                name="GregorianDate"
                autoComplete="date"
                onChange={handleDateChange}
                format="DD/MM/YYYY"
              />
            </DemoContainer>
          </LocalizationProvider>
          <FormGroup >
                <FormControlLabel control={<Checkbox defaultChecked/>} label="האם אתה מעונין שהאירוע יתווסף לכלל הלוחות שברשותך?" />
              </FormGroup>
          <Button
            type="submit"
            fullWidth
            variant="contained"
            sx={{ mt: 3, mb: 2 }}
          >
        
            הוסף ארוע ללוח
          </Button>
          <Link component={RouterLink} to="/add-user" variant="body2">
          <Button
            fullWidth
            variant="outlined"
            sx={{ mt: 3, mb: 2 }}
          >
            {"הוספת בן משפחה"}
          </Button>
        </Link>
        </Form>
      </Grid>
    </>
  );
}

export default AddEvent;
