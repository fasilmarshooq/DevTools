import React, { Component } from "react";
import { Switch, Route, Redirect } from "react-router-dom";
import NavBar from "./NavBar";
import DashBoard from "./DashBoard";
import NotFound from "./NotFound";
import FileUtilities from "./FileUtils/FileUtilities";

class Body extends Component {
  render() {
    return (
      <React.Fragment>
        <NavBar />
        <main className="container">
          <Switch>
            <Route path="/FileUtilities" component={FileUtilities} />
            <Route path="/DashBoard" component={DashBoard} />
            <Route path="/not-found" component={NotFound} />
            <Redirect from="/" exact to="/DashBoard" />
            <Redirect from="/*" exact to="/DashBoard" />
            <Redirect to="/not-found" />
          </Switch>
        </main>
        <div style={{ position: "absolute", right: 1, bottom: 0 }}>
          <p className="text-secondary">
            <i className="fa fa-code" aria-hidden="true">
              ..Fasil
            </i>
          </p>
        </div>
      </React.Fragment>
    );
  }
}

export default Body;
