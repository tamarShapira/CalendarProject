import { styled } from "@mui/material";
import React, { useEffect, useState } from "react";
import Button from '@mui/material/Button';
import CloudUploadIcon from '@mui/icons-material/CloudUpload';
import { uploadFile } from "../store/actions/file-actions";
import { useDispatch,useSelector } from "react-redux";

const VisuallyHiddenInput = styled('input')({
    clip: 'rect(0 0 0 0)',
    clipPath: 'inset(50%)',
    height: 1,
    overflow: 'hidden',
    position: 'absolute',
    bottom: 0,
    left: 0,
    whiteSpace: 'nowrap',
    width: 1,
});

const FileUpload = ({ text }) => {

    const dispatch = useDispatch();
    const [fileData, setFileData] = useState();
    const siteUser = useSelector(state => state.user);

    useEffect(() => {
        if(fileData != undefined) {
            dispatch(uploadFile(fileData,siteUser.user.id));
        }
    },[fileData])

    const handleFileChange = e => {
        setFileData(e.target.files[0]);
    }

    return (
        <Button
            component="label"
            role={undefined}
            variant="contained"
            tabIndex={-1}
            startIcon={<CloudUploadIcon />}
        >
            {text}
            <VisuallyHiddenInput type="file" onChange={handleFileChange} />
        </Button>
    );
}

export default FileUpload;