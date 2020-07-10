import React, { Component } from "react";
import { ToastContainer } from "react-toastify";
import Body from "./components/Body";
import "react-toastify/dist/ReactToastify.css";
import "./App.css";

class App extends Component {
  state = {};

  render() {
    return (
      <React.Fragment>
        <ToastContainer
          position="top-right"
          autoClose={5000}
          hideProgressBar={false}
          newestOnTop={false}
          closeOnClick
          rtl={false}
          pauseOnFocusLoss
          draggable
        />
        <Body />
      </React.Fragment>
    );
  }
}

export default App;
