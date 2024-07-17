import React, { useEffect, useState, useRef } from "react";
import { useSelector, useDispatch } from 'react-redux';
import { Link as RouterLink, Link } from 'react-router-dom';
import FileService from "../../services/FileService";
import UserImage from "./user-image";
import Grid from '@mui/material/Grid';
import CallIcon from '@mui/icons-material/Call';
import EmailIcon from '@mui/icons-material/Email';
import { Button, Divider } from "@mui/material";
import CardActions from '@mui/material/CardActions';
import Typography from '@mui/material/Typography';
import Fab from '@mui/material/Fab';
import GroupAddIcon from '@mui/icons-material/GroupAdd';
import CalendarMonthIcon from '@mui/icons-material/CalendarMonth';
import TextField from '@mui/material/TextField';
import ValidatedTextField from "../../components/validatedTextField";
import { emailValidator, phoneValidator } from "../../helpers/validationsHelper";
import { editDetails } from "../../store/actions/user-actions";

const UserView = ({ user }) => {

   // const emptyUser = { firstName: 'אין', lastName: 'מידע' }

    const [imgUrl, setImgUrl] = useState();
    const [label, setLabel] = useState("עדכון פרטים");
    const [dis, setDis] = useState(true);
    const { calendars } = useSelector(state => state.calendar);
    const  currentUser  = useSelector(state => state.user);
    const currentCalendar = calendars.find(calendar => calendar.active);
    const isAdmin = currentCalendar?.directorId === user.id;
    const dispatch = useDispatch();

    const handleLinkClick = (e) => {
        if (!isAdmin) {
            e.preventDefault(); // Prevent navigation if Fab button is disabled
        }
    };

    useEffect(() => {
        if (currentUser) {
            setImgUrl(FileService.getImageUrl(currentUser.user.id))
        }
        console.log("image: ",imgUrl)
    }, [user,imgUrl,dispatch])

    // const getUserById = (userId) => {
    //     if (userId == null || !users || !users.length)
    //         return emptyUser;
    //     return users.find(u => u.id === userId);
    // }
    const editDetailsForUser = (event) => {
        if (label == 'עדכון פרטים') {
            setLabel('שמור');
            setDis(false)
        }
        else {
            handleSubmit(event)
        }
    }
    const handleSubmit = async (event) => {
        event.preventDefault();
        const formData = new FormData(event.target)
        const data = Object.fromEntries(formData.entries())
        const detailsData = {
            Id: user?.id,
            SiteUserId: user?.siteUserId,
            TZ: user?.tz,
            FirstName: user?.firstName,
            LastName: user?.lastName,
            BornDate: user?.bornDate,
            PhoneNumber: data.phoneNumber?data.phoneNumber:user.phoneNumber,
            Email: data.email!==""?data.email:user.email,
            SiteUser: user?.siteUser,
            CalendarUsers: user?.calendarUsers,
        }
        dispatch(editDetails(detailsData))
    }
    return (
        <Grid container spacing={2}>
            <Grid item xs={12}>
            </Grid>
            <Grid item xs={8}>
                <Grid item sx={{ alignItems: 'center' }}>
                    <Typography gutterBottom variant="h5" component="div" >
                        שם משתמש:
                    </Typography>
                    <Typography gutterBottom variant="h3" component="div">
                        {user.firstName} {user.lastName}
                    </Typography>
                    <Divider>
                        <Typography>פרטי יצירת קשר</Typography>
                    </Divider>
                    <form onSubmit={handleSubmit}>
                        <Grid container alignItems="center" spacing={3} sx={{ justifyContent: 'center', padding: 4 }}>
                            <Grid item xs={6}>
                                <Grid container alignItems="center" spacing={1}>
                                    <Grid item>
                                        <CallIcon />
                                    </Grid>
                                    <Grid item>

                                        <TextField
                                            name="phoneNumber"
                                            disabled={dis}
                                            // value={user.phoneNumber}
                                            placeholder={user.phoneNumber}
                                        />


                                    </Grid>
                                </Grid>
                            </Grid>
                            <Grid item xs={6}>
                                <Grid container alignItems="center" spacing={1}>
                                    <Grid item>
                                        <EmailIcon />
                                    </Grid>
                                    <Grid item>
                                        <TextField
                                            name="email"
                                            disabled={dis}
                                           // value={user.email}
                                            placeholder={user.email}
                                        />
                                    </Grid>
                                </Grid>
                            </Grid>
                        </Grid>

                        <Divider>
                           {label==="עדכון פרטים"&& <Button
                                onClick={editDetailsForUser}
                                size="large"
                                variant="outlined" >
                                עדכון פרטים
                            </Button>}
                            {label==="שמור"&& <Button
                               type="submit"
                                size="large" 
                                variant="contained">
                                שמור
                            </Button>}
                        </Divider>
                    </form>
                    <CardActions sx={{ justifyContent: 'center' }}>

                        <Link component={RouterLink} to="/add-user" onClick={handleLinkClick} >
                            <Fab disabled={!isAdmin} color="primary" variant="extended" size="large" sx={{ borderRadius: '50%', width: '105px', height: '105px', mr: 2 }}>
                                <GroupAddIcon sx={{ mr: 1 }} />
                                הוספת בן משפחה
                            </Fab>
                        </Link>
                        <Link component={RouterLink} to="/add-event" onClick={handleLinkClick}>
                            <Fab disabled={!isAdmin} color="primary" variant="extended" size="large" sx={{ borderRadius: '50%', width: '105px', height: '105px', mr: 2 }}>
                                <CalendarMonthIcon />
                                הוספת ארוע
                            </Fab>
                        </Link>
                    </CardActions>
                </Grid>
            </Grid>
            <Grid item xs={4}>
                <Grid item>
                    <UserImage imgUrl={imgUrl} id={currentUser.user.id}/>
                </Grid>
            </Grid>
        </Grid>
    )
}
export default UserView;
