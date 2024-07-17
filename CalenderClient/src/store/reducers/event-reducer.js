import { SET_TZ_EVENT_BY_ADD_USER, SET_EVENTS } from "../types/event-types";

const initialState = {
    tzEventByaddUser: null,
    events: []
}

const eventReducer = (state = initialState, action) => {

    switch (action.type) {
        case SET_TZ_EVENT_BY_ADD_USER:
            return {
                tzEventByaddUser: action.payload
            };
        case SET_EVENTS:
            return {
                ...state,
                events: action.payload
            };
        default:
            return state;
    }
}

export default eventReducer;