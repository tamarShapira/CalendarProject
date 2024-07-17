import { enqueueSnackbar } from 'notistack';
import CalendarService from '../../services/CalendarService';
import { SET_CALENDAR_USERS, SET_CURRENT_CALENDAR, SET_USER_CALENDARS, REMOVE_CALENDAR, ADD_CALENDAR, SET_CALENDAR_EVENTS } from '../types/calendar-types';
import { HttpStatusCode } from 'axios';
import EventService from '../../services/EventService';
import router from '../../router';

export function addNewCalendar(calendar) {
  return {
    type: ADD_CALENDAR,
    payload: calendar
  }
}

export function setCalendars(calendars) {
  return {
    type: SET_USER_CALENDARS,
    payload: calendars
  }
}

export function setCurrentCalendar(calendarId) {
  return {
    type: SET_CURRENT_CALENDAR,
    payload: calendarId
  }
}

export function setCalendarUsers(calendarId, users) {
  return {
    type: SET_CALENDAR_USERS,
    payload: { calendarId, users }
  }
}
export function setCalendarEvents(events) {
  return {
    type: SET_CALENDAR_EVENTS,
    payload: events
  }
}
export function removeCalendar() {
  return {
    type: REMOVE_CALENDAR
  }
}

export const getCalendars = () => async dispatch => {
  try {
    const response = await CalendarService.getCalendars();
    const { data } = response;
    if (data) {
      dispatch(setCalendars(data))
    }
  }
  catch (error) {
    enqueueSnackbar(`error: ${error}`, { variant: "error" });
  }
}

export const getCalendarUsers = (calendarId) => async dispatch => {
  try {
    debugger
    const response = await CalendarService.getCalendarUsers(calendarId);
    const { data } = response;
    console.log(data);
    if (data) {
      dispatch(setCalendarUsers(calendarId, data))
    }
  }
  catch (error) {
    enqueueSnackbar(`error: ${error}`, { variant: "error" });
  }
}
export const getCalendarEvents = (calendarId) => async dispatch => {
  try {
    const response = await EventService.getEvents();
    const { data } = response;
    const calendarEventsData = []
    data.map((event) => {
      if (event.calendarId === calendarId)
        calendarEventsData.push(event)
    })
    if (data) {
      dispatch(setCalendarEvents(calendarEventsData))
    }
  }
  catch (error) {
    enqueueSnackbar(`error: ${error}`, { variant: "error" });
  }
}
export const addCalendar = (data) => async dispatch => {
  try {
    const response = await CalendarService.addCalendar(data);

    if (response?.status === HttpStatusCode.Ok) {
      dispatch(addNewCalendar(response.data))
      enqueueSnackbar("הלוח נוצר בהצלחה", { variant: "success" });
      //const siteUser=useSelector(state=>state.user)
      // dispatch(setCurrentUser(siteUser))
      router.navigate('/selectAction');

    }
    else {
      enqueueSnackbar(`error: ${response.message}`, { variant: "error" });
    }
  }
  catch (error) {
    if (error?.response?.status === 400) {
      enqueueSnackbar(`${error?.response?.data?.message}`, { variant: "error" });
    }
    else {
      enqueueSnackbar(`An unexpected error has occurred`, { variant: "error" });
    }
  }

}
