import { HttpStatusCode } from "axios";
import FileService from "../../services/FileService";
import { enqueueSnackbar } from 'notistack';
import { SET_IMAGE_URL } from "../types/file-types";


export function getSiteUserImage(siteUserId) {
    return {
      type: SET_IMAGE_URL,
      payload: siteUserId
    }
  }

export const uploadFile = (file,siteUserId) => async dispatch => {
    debugger
    const formData = new FormData();
    formData.append("formFile", file);
    formData.append("fileName", file.name);
    try {
        const response = await FileService.saveImage(formData);
        if (response.status == HttpStatusCode.Created) {
            const variant = "success"
            await FileService.getImageUrl(siteUserId)
            enqueueSnackbar('התמונה נשמרה בהצלחה!', { variant });
        }
    }
    catch (error) {
        const variant = "error"
        enqueueSnackbar('error', { variant });
    }
}