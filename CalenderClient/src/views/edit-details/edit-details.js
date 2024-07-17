import React, {  useState } from "react";
import { useDispatch, useSelector } from 'react-redux';
import { editDetails } from "../../store/actions/user-action";
import Form from '../../components/form';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';




const EditDetails = () => {
    const dispatch = useDispatch();
    const currentUser = useSelector(state => state.user.user);
    const [userDetails, SetUserDetails] = useState(currentUser)

    const handelChange = (event) => {
        SetUserDetails({
            ...userDetails,
            [event.target.name]: [event.target.value]
        })
    }

    const onSubmit = () => {
        const details = {
            Id: userDetails?.id,
            SiteUserId: userDetails?.SiteUserId,
            TZ: userDetails?.tz,
            FirstName: userDetails?.firstName[0],
            LastName: userDetails?.lastName[0],
            BornDate: userDetails?.BornDate,
            SpouseId: userDetails?.SpouseId,
            FatherId: userDetails?.FatherId,
            MotherId: userDetails?.MotherId,
            PhoneNumber: userDetails?.phoneNumber,
            Email: userDetails?.email,
            SiteUser: userDetails?.SiteUser,
            Spouse: userDetails?.Spouse,
            Father: userDetails?.Father,
            Mother: userDetails?.Mother,
            CalendarUsers: userDetails?.CalendarUsers,
        }
        return details;
    }

    const handleSubmit = async (event) => {
        event.preventDefault();

        dispatch(editDetails(onSubmit()));
    }
    return (
        <Form handleSubmit={handleSubmit}>
            <TextField
                onChange={handelChange}
                margin="normal"
                fullWidth
                id="email"
                label="מייל"
                name={"email"}
                autoComplete="email"
                autoFocus
                value={userDetails?.email}
            />
            <TextField
                onChange={handelChange}
                margin="normal"
                fullWidth
                name={"firstName"}
                label="שם פרטי"
                type="text"
                id="firstName"
                autoComplete="firstName"
                value={userDetails.firstName}
            />
            <TextField
                onChange={handelChange}
                margin="normal"
                fullWidth
                name={"lastName"}
                label="שם משפחה"
                type="text"
                id="last-name"
                autoComplete="last-name"
                value={userDetails?.lastName}
            />
            <TextField
                onChange={handelChange}
                margin="normal"
                fullWidth
                name={"phoneNumber"}
                label="מספר טלפון"
                type="text"
                id="phone"
                autoComplete="phone"
                value={userDetails?.phoneNumber}
            />
            <Button
                type="submit"
                fullWidth
                variant="contained"
                sx={{ mt: 3, mb: 2 }}
            >
                שמור
            </Button>
        </Form>
    )
}

export default EditDetails;