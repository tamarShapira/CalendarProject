import React, { useEffect, useState } from "react";
import { useSelector, useDispatch } from "react-redux";
import { getAllEvents } from '../../store/actions/event-actions';
import { getCalendarEvents, getCalendarUsers } from "../../store/actions/calendar-actions";
import UserView from "./user-view";

const FamilySettings = () => {
    const dispatch = useDispatch();
    const siteUser = useSelector(state => state.user);
    const { calendars } = useSelector(state => state.calendar);
    const [activeCalendar, setActiveCalendar] = useState();
    const [users, setUsers] = useState([]);
    const [currentUser, setCurrentUser] = useState({});
    const currentCalendar = calendars.find(calendar => calendar.active);

    useEffect(() => {
        dispatch(getCalendarUsers(currentCalendar.id));
        dispatch(getCalendarEvents(currentCalendar.id));
        dispatch(getAllEvents());
    
      }, [])
    useEffect(() => {
        setActiveCalendar(calendars?.find(cal => cal.active));
        console.log("calendars: ",calendars);
    }, [calendars])

    useEffect(() => {
        if (activeCalendar) {
            if (!activeCalendar.users || !activeCalendar.users.length) {
                dispatch(getCalendarUsers(activeCalendar.id));            
                dispatch(getCalendarEvents(activeCalendar.id));            
            }
            setUsers(activeCalendar.users);         
        }
        // Fetch users if active calendar is available but users array is empty or undefined
    }, [activeCalendar, dispatch]);

    useEffect(() => {
        if (users && users.length > 0) {
            setCurrentUser(users.find(u => u.siteUserId === siteUser.user.id))
            console.log("users from family-settings: ",users);
        }
    }, [users, siteUser])

    return (
        <>
            {currentUser && <UserView user={currentUser} />}
        </>
    );
}

export default FamilySettings;
