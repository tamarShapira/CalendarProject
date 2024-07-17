import React from "react";
import  { useEffect, useState, useRef } from "react";
import FileService from "../../services/FileService";
import FileUpload from "../../components/file-upload";
import CardMedia from '@mui/material/CardMedia';


const UserImage = ({ imgUrl,id }) => {

    const [imageUrl, setImageUrl] = useState(imgUrl);


    useEffect(() => {
        
        setImageUrl(FileService.getImageUrl(id))
        
    }, [imageUrl])

    return (
        <CardMedia
            sx={{ height: '100vh' }}
            image={imgUrl}
            title="green iguana"
        >
            <FileUpload text={!imageUrl ? "הוספת תמונה" : "עדכון תמונה"} />
        </CardMedia>
    );
}

export default UserImage;