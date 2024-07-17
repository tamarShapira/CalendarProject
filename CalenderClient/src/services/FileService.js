import axios from 'axios';
import { API_URL } from '../config';
import AuthService from './AuthService';

const baseUrl = `${API_URL}/File`;

const FileService = {
  getImageUrl: function(siteUserId) {
    return `${baseUrl}/?siteUserId=${siteUserId}`;
  },
  saveImage: function(formData) {
    return axios.post(baseUrl, formData, { headers: AuthService.authHeader() });
  }
}

export default FileService