import axios from 'axios';
import { API_URL } from '../config';

const baseUrl = `${API_URL}/Event`;

const EventService={
  
    addEvent: function(data) {
      
        return axios.post(baseUrl, { ...data });
      },
  getEvents: function() {
    return axios.get(baseUrl);
  }
}
export default EventService;

