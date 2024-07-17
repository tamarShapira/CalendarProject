import axios from 'axios';
import { API_URL } from '../config';

const baseUrl = `${API_URL}/User`;

const UserService = {
  setEditDetails: function (data) {
    return axios.put(baseUrl + '/Put', data);
  },
  getCurrentUser: function (tz) {
    return axios.get(baseUrl + `/GetByTz`, { params: { tz } });
  },
}

export default UserService;