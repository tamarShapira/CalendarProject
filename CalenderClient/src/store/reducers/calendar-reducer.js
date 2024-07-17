import { SET_CALENDAR_USERS, SET_CURRENT_CALENDAR, SET_USER_CALENDARS ,REMOVE_CALENDAR,SET_CALENDAR_EVENTS} from "../types/calendar-types";

const initialState = {
  calendars: []
}

const calendarReducer = (state = initialState, action) => {
  const { type, payload } = action;

  switch (type) {
    case SET_USER_CALENDARS:
      return {
        ...state,
        calendars: payload
      };
    
    case SET_CURRENT_CALENDAR:
      return {
        ...state,
        calendars: state.calendars.map(calendar => ({
          ...calendar,
          active: calendar.id === payload? true : false
        }))
      };
    case SET_CALENDAR_USERS:
      return {
        ...state,
        calendars: state.calendars.map(calendar => ({
          ...calendar,
          users: calendar.id === payload.calendarId ? payload.users : calendar.users
        }))
      };
      case SET_CALENDAR_EVENTS:
      return {
        ...state,
        calendars: state.calendars.map(calendar => ({
          ...calendar,
          events:payload 
        }))
      };
      case  REMOVE_CALENDAR:
      return{
        calendars:[]
      }
    default:
      return state;
  }
}

export default calendarReducer;
