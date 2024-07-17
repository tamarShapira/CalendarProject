import EventService from "../../services/EventService";
import { SET_TZ_EVENT_BY_ADD_USER, ADD_EVENT, SET_EVENTS } from "../types/event-types";
import { HttpStatusCode } from 'axios';
import { enqueueSnackbar } from 'notistack';
import { getCalendarEvents } from "./calendar-actions";

export function setTzEventByAddUser(tz) {
  return {
    type: SET_TZ_EVENT_BY_ADD_USER,
    payload: tz
  }
}

export function addNewEvent(event) {
  return {
    type: ADD_EVENT,
    payload: event
  }
}
export function setEvents(events) {
  return {
    type: SET_EVENTS,
    payload: events
  }
}
export const setTzEvent = (tz) => dispatch => {
  dispatch(setTzEventByAddUser(tz))
}
export const addEvent = (data) => async dispatch => {

  try {
    const response = await EventService.addEvent(data);
    if (response?.status === HttpStatusCode.Ok) {
      dispatch(addNewEvent(response.data))
      enqueueSnackbar(`האירוע התווסף בהצלחה`, { variant: "success" })
      dispatch(setTzEvent(null))
      dispatch(getCalendarEvents(data.calendarId))

    }
    else {
      enqueueSnackbar(`error: ${response.message}`, { variant: "error" });
    }
  }
  catch (error) {
    enqueueSnackbar(`${error?.response?.data?.message}`, { variant: "error" });
  }

}
export const getAllEvents = () => async dispatch => {
  try {
    const response = await EventService.getEvents();
    const { data } = response;
    if (data) {
      dispatch(setEvents(data))
    }
  }
  catch (error) {
    enqueueSnackbar(`error: ${error}`, { variant: "error" });
  }
}