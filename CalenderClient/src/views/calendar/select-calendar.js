import * as React from 'react';
import { useEffect, useState } from "react";
import { useSelector, useDispatch } from "react-redux";
import { Link as RouterLink, Link } from 'react-router-dom';
import { getCalendarEvents, getCalendarUsers, setCurrentCalendar } from "../../store/actions/calendar-actions";
import { getCalendars } from "../../store/actions/calendar-actions";
import Navbar from '../home/navbar';
import Grid from '@mui/material/Grid';
import Box from '@mui/material/Box';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import CalendarMonthIcon from '@mui/icons-material/CalendarMonth';

const SelectCalendar = () => {

    const dispatch = useDispatch();
    const { calendars } = useSelector(state => state.calendar);
    const siteUser = useSelector(state => state.user);
    const [activeCalendar, setActiveCalendar] = useState();
    const [currentUser, setCurrentUser] = useState();
    const [users, setUsers] = useState([]);
    const [userCalendars, setUserCalendars] = useState([]);

    useEffect(() => {
        dispatch(getCalendars());
    }, [])
    useEffect(() => {
        if (!calendars || !calendars.length) {
            dispatch(getCalendars());
        }
    }, [calendars, dispatch])

    useEffect(() => {
        setActiveCalendar(calendars?.find(cal => cal.active));
    }, [calendars])

    useEffect(() => {
        debugger
        if (calendars && calendars.length > 0) {
            calendars.map((calendar) => {
                dispatch(getCalendarUsers(calendar.id))
            })
        }
        if (activeCalendar) {
            if (!activeCalendar.users || !activeCalendar.users.length) {
                dispatch(getCalendarUsers(activeCalendar.id));
                dispatch(getCalendarEvents(activeCalendar.id));
            }
            setUsers(activeCalendar.users);
        }
        // Fetch users if active calendar is available but users array is empty or undefined
    }, []);

    useEffect(() => {
        if (users && users.length > 0) {
            setCurrentUser(users.find(u => u.siteUserId === siteUser.user.id))
        }
    }, [users, siteUser, calendars])

    const setSelectiveCalendar = (calendarId) => {
        dispatch(setCurrentCalendar(calendarId))
    }

    return (
        <>
            <Navbar user={siteUser.user} />
            <Grid container direction="column" spacing={2} alignItems="center">
                <h2>באיזה לוח שנה ברצונך לצפות?</h2>
            </Grid>

            <Grid container rowSpacing={1} columnSpacing={{ xs: 7, sm: 7, md: 7 }} spacing={{ xs: 20, md: 30 }} columns={{ xs: 9, sm: 12, md: 12 }} justifyContent="center" alignItems="center" sx={{ my: 2 }} >
                {calendars.map((calendar) => (
                    <Box sx={{ width: 340, height: 220, border: "1px solid grey", mx: 2, display: "flex", flexDirection: "column", justifyContent: "center", alignItems: "center" }} key={calendar.id} rowSpacing={6} spacing={{ xs: 20, md: 30 }}  >
                        <React.Fragment>
                            <CardContent sx={{display: "flex", flexDirection: "column", justifyContent: "center", alignItems: "center" }} >
                                <Typography sx={{ fontSize: 14 }} color="text.secondary" gutterBottom>
                                    לוח שנה:
                                </Typography>
                                <Typography variant="h5" component="div">
                                    {calendar.groupName}
                                </Typography>
                                {calendar.users?.map((user) => (
                                    calendar.directorId === user.id ? <Typography>(מנהל: {user.firstName} {user.lastName})</Typography> : <></>
                                ))}

                                <CalendarMonthIcon size="large"/>
                            </CardContent>
                            <CardActions>
                                <Link component={RouterLink} to="/home/family/settings" >
                                    <Button size="small"
                                        onClick={() => { setSelectiveCalendar(calendar.id) }}
                                        type="submit"
                                        fullWidth
                                        variant="contained"
                                        sx={{ mt: 3, mb: 2 }}>
                                        לצפיה בלוח
                                    </Button>
                                </Link>
                            </CardActions>
                        </React.Fragment>
                    </Box>
                ))}
            </Grid>
        </>
    );
}
export default SelectCalendar;