import axios from 'axios';
import { API_URL } from '../config';
import AuthService from './AuthService';

const baseUrl = `${API_URL}/Calendar`;

const CalendarService = {
  addCalendar: function(data) {
    return axios.post(baseUrl, { ...data });
  },
  getCalendars: function() {
    return axios.get(baseUrl, { headers: AuthService.authHeader()});
  },
  getCalendarUsers: function (calendarId) {
    return axios.get(baseUrl + '/users' , { headers: AuthService.authHeader(), params: { calendarId } });
  }
}

export default CalendarService;