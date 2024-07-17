import { configureStore, applyMiddleware } from '@reduxjs/toolkit';
import  { thunk } from 'redux-thunk';
import rootReducer from './reducers/index';

const initialState = {}

const store = configureStore({
        initialState,
        reducer: rootReducer,
    },
    applyMiddleware(thunk)
)
  
export default store;