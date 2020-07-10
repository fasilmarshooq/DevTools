import React from "react";
import { Link, NavLink } from "react-router-dom";
import logo from "../contents/images/Odessa_White_RGB.png";

const NavBar = () => {
  return (
    <React.Fragment>
      <nav className="navbar navbar-expand-lg navbar-dark bg-primary border-rounded">
        <div className="collapse navbar-collapse" id="navbarSupportedContent">
          <div className="navbar-nav">
            <Link className="navbar-brand" to="./">
              <img width="100px" height="auto" src={logo} alt="logo" />
            </Link>

            <NavLink className="nav-item nav-link ml-2" to="./DashBoard">
              <i className="fa fa-bar-chart" aria-hidden="true"></i> Dash Board
            </NavLink>
            <NavLink className="nav-item nav-link ml-2" to="./FileUtilities">
              <i className="fa fa-file-text-o" aria-hidden="true"></i> File
              Utilities
            </NavLink>
          </div>
        </div>
      </nav>
    </React.Fragment>
  );
};

export default NavBar;
