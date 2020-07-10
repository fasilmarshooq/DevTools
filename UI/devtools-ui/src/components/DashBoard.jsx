import React, { Component } from "react";
import TestAutomationStatusChartArea from "./TestAutomationStatusChartArea";
import ListGroup from "./common/ListGroup";

class DashBoard extends Component {
  state = {
    listGroupItems: [],
    CurrentListGroupItem: "",
    CurrentListGroupUrl: "",
    CurrentListGroupRunName: "",
  };

  componentDidMount() {
    const CurrentListGroup = window.DashBoardListGroup.filter(
      (x) => x.Default === "True"
    );
    const CurrentListGroupItem = CurrentListGroup[0].item;
    const CurrentListGroupUrl = CurrentListGroup[0].url;
    const CurrentListGroupRunName = CurrentListGroup[0].RunName;
    this.setState({
      listGroupItems: window.DashBoardListGroup,
      CurrentListGroupItem,
      CurrentListGroupUrl,
      CurrentListGroupRunName,
    });
  }
  handleListGroupItemChange = (item) => {
    const CurrentListGroupItem = item;
    const CurrentListGroup = window.DashBoardListGroup.filter(
      (x) => x.item === item
    );
    const CurrentListGroupUrl = CurrentListGroup[0].url;
    const CurrentListGroupRunName = CurrentListGroup[0].RunName;
    this.setState({
      CurrentListGroupItem,
      CurrentListGroupUrl,
      CurrentListGroupRunName,
    });
  };

  render() {
    const {
      listGroupItems,
      CurrentListGroupItem,
      CurrentListGroupUrl,
      CurrentListGroupRunName,
    } = this.state;
    return (
      <React.Fragment>
        <div className="d-flex bd-highlight ml-n5 mt-3">
          <div className="ml-1" style={{ position: "absolute", left: 0 }}>
            <ListGroup
              items={listGroupItems}
              currentItem={CurrentListGroupItem}
              onItemChange={this.handleListGroupItemChange}
            />
          </div>
          <div style={{ position: "absolute", left: 280 }}>
            <TestAutomationStatusChartArea
              Url={CurrentListGroupUrl}
              RunName={CurrentListGroupRunName}
            />
          </div>
        </div>
      </React.Fragment>
    );
  }
}

export default DashBoard;
