import React from "react";
import { useDispatch, useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";
import { logout, selectUser } from "../features/userSlice";

const Logout = () => {

  const user = useSelector(selectUser);
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const handleLogout = (e) => {
    e.preventDefault();
    dispatch(logout());
    navigate('/');
  };

    return (
        <div className="logout">
          <h1>
            Welcome <span className="user_name">{user.name}</span>
          </h1>{""}
          <button className="logout_button" onClick={(e) => handleLogout(e)}>
            Logout
          </button>
        </div>
    );
};
export default Logout;