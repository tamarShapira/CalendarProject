import userReducer from './user-reducer'
import calendarReducer from './calendar-reducer';
import eventReducer from './event-reducer';
import { combineReducers } from 'redux';

const rootReducer = combineReducers({
    user: userReducer,
    calendar: calendarReducer,
    event:eventReducer,
})

export default rootReducer;