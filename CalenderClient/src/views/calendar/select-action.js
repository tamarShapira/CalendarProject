import * as React from 'react';
import { useState, useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import { Link } from 'react-router-dom';
import { addCalendar, getCalendars } from '../../store/actions/calendar-actions';
import Navbar from '../home/navbar';
import loginImage from '../../assets/Employee checking date of important event.jpg';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import Grid from '@mui/material/Grid';

const SelectAction = () => {

    const dispatch = useDispatch();
    const [groupNameValue, setGroupNameValue] = useState('');
    const [showButton, setShowButton] = useState(false);
    const userCalendars = useSelector(state => state.user.user.calendars)
    const siteUser = useSelector(state => state.user);

    const createCalendar = () => {
        const data = {
            DirectorId: siteUser.user.id,
            GroupName: groupNameValue
        }
        dispatch(addCalendar(data))
    }
    useEffect(() => {
        dispatch(getCalendars())       
    }, [])

    return (
        <>
            <Navbar></Navbar>
            <Grid container component="main"
                sx={{
                    height: '100vh',

                }}>
                <Grid item xs={false} sm={4} md={7}
                    sx={{
                        backgroundImage: `url("${loginImage}")`,
                        backgroundRepeat: 'no-repeat',
                        backgroundSize: 'cover',
                        backgroundPosition: 'center',
                    }}
                />
                <Grid sx={{
                    my: 4,
                    mx: 25,
                    display: 'flex',
                    flexDirection: 'column',
                    alignItems: 'center',
                }}>
                    <Grid item >
                        <h2>בחר את האפשרות הרצויה:</h2>
                    </Grid >

                    {!showButton ?
                        <Grid item  >
                            <Button
                                component={Link}
                                to={"/selectCalendar"}
                                disabled={userCalendars.length > 0 ? false : true}
                                variant="outlined"
                                sx={{ mt: 3, mb: 2 }}
                            >
                                כניסה ללוח קיים
                            </Button>
                        </Grid>
                    :<Grid item>
                    <TextField
                        margin="normal"
                        required
                        id="groupName"
                        label="בחר שם ללוח"
                        name="groupName"
                        autoComplete="groupName"
                        onChange={(e) => setGroupNameValue(e.target.value)}
                    /></Grid>}
                    <Grid item>
                        <Button
                            onClick={() => {
                                setShowButton(true)
                            }
                            }
                            variant="contained"
                            sx={{ mt: 3, mb: 2 }}
                        >
                            צור לוח חדש
                        </Button>
                    </Grid>
                    {groupNameValue &&
                        <Grid item>
                            <Button
                                onClick={() => { createCalendar() }}
                                variant="contained"
                                sx={{ mt: 3, mb: 2 }}
                                type='submit'>צור</Button>
                        </Grid>}
                </Grid>
            </Grid>
        </>
    );
}
export default SelectAction;