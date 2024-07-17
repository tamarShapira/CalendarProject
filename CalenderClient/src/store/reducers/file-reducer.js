import { SET_IMAGE_URL } from "../types/file-types";
const initialState={
    currentSiteUserImage:undefined
}
const fileReducer = (state = initialState, action) => {

    switch (action.type) {
        case SET_IMAGE_URL:
            return {
                currentSiteUserImage: action.payload
            };
        default:
            return state;
    }
}

export default fileReducer;