import AuthService from '../../services/AuthService';
import { SET_CURRENT_USER, REGISTER_SUCCESS, LOGOUT } from '../types/user-types';
import { enqueueSnackbar } from 'notistack';
import { HttpStatusCode } from 'axios';
import router from '../../router';
import { removeCalendar } from './calendar-actions';

export function setCurrentUser(user) {
  return {
    type: SET_CURRENT_USER,
    payload: user
  }
}

export function registerSuccess() {
  return {
    type: REGISTER_SUCCESS
  }
}

export function logoutUser() {
  return {
    type: LOGOUT
  }
}

/**
 * Login user action
 */

export const login = (tz, password) => async dispatch => {

  try {
    const response = await AuthService.login(tz, password);
    if (response.data) {
      const { siteUser, token } = response.data;
      dispatch(setCurrentUser(siteUser))
      AuthService.saveToken(token);
      router.navigate('/selectAction');
    }
  }
  catch (error) {
    console.log(error?.response?.data?.message)
    if (error?.response?.status === 400) {
      enqueueSnackbar(`${error?.response?.data?.message}`, { variant: "error" });
    }
    else {
      enqueueSnackbar(`An unexpected error has occurred`, { variant: "error" });
    }
  }
}

export const getAuthorizedUser = () => async dispatch => {
  try {
    const response = await AuthService.getUser();
    if (response.data) {
      dispatch(setCurrentUser(response.data))
      console.log("response.data: ", response.data)
      return response.data.password;
    }
    else {
      dispatch(logout);
    }
  }
  catch (error) {
    dispatch(logout);
  }

}

/**
 * Logout action
 */
export const logout = () => dispatch => {
  AuthService.logout();
  dispatch(logoutUser());
  dispatch(removeCalendar());
  router.navigate('/');
}

/**
 * Register user action
 */
export const register = (data) => async dispatch => {
  try {
    const response = await AuthService.register(data);
    console.log(response);
    if (response?.status === HttpStatusCode.Ok) {
      dispatch(registerSuccess())
      if (data.IsAdmin) {
        router.navigate('/login');
        enqueueSnackbar(`נרשמת בהצלחה`, { variant: "success" })
      }
      else
      enqueueSnackbar(`משתמש נוסף בהצלחה`, { variant: "success" })
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