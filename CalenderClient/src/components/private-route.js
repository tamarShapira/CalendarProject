import { useEffect, useState } from "react";
import { Navigate } from "react-router-dom";
import AuthService from "../services/AuthService"
import { useDispatch, useSelector } from "react-redux";
import { getAuthorizedUser } from "../store/actions/auth-actions";

const PrivateRoute = ({ Component }) => {

    const dispatch = useDispatch();
    const { user } = useSelector(state => state.user);
    const [isAuthenticated, setIsAuthenticated] = useState(AuthService.getToken() != undefined);

    useEffect(() => {
        if(isAuthenticated && !user) {
            dispatch(getAuthorizedUser());
        }
    }, [isAuthenticated]);


    // Your authentication logic goes here...

    return isAuthenticated ? <Component /> : <Navigate to="/login" />;
};
export default PrivateRoute;