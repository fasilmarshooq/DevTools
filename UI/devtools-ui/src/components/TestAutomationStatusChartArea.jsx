import React, { Component } from "react";
import TestAutomationScenarioHeaderLogs from "./TestAutomationScenarioHeaderLogs";
import TestAutomationStatusChart from "./TestAutomationStatusChart";
import TestAutomationStatusChartTimeCards from "./TestAutomationStatusChartTimeCards";
import Buffer from "./common/Buffer";
import { toast } from "react-toastify";
import { GetChartData } from "../services/ChartServices";
import { handleDownload } from "../services/RegressionReportService";

class TestAutomationStatusChartArea extends Component {
  state = {
    modal: {
      show: false,
      elementLabel: "",
    },
    chartLoaded: false,
    chartData: {},
    RunName: "",
    Url: "",
  };

  getData = async (RunName, Url) => {
    if (!Url || !RunName) return;
    const chartData = await GetChartData(Url, RunName);
    if (!chartData.data)
      toast.info("Aw! No Data present for current selection");
    this.setState({ chartData, chartLoaded: true });
  };
  handleElementClick = (elems) => {
    if (elems[0]) {
      const modal = this.state.modal;
      modal["show"] = true;
      modal["elementLabel"] = elems[0]._model.label;
      this.setState({ modal });
    }
  };
  handlePopUpModalClose = () => {
    const modal = this.state.modal;
    modal["show"] = false;
    modal["elementLabel"] = "";
    this.setState({ modal });
  };

  handleReportDownload = () => {
    handleDownload(this.state.modal.elementLabel);
    this.handlePopUpModalClose();
  };

  handleRefresh = () => {
    this.setState({ chartLoaded: false });
  };

  componentWillReceiveProps() {
    this.setState({ chartLoaded: false });
  }

  render() {
    const { RunName, Url } = this.props;
    const { chartData, chartLoaded, modal } = this.state;
    if (!chartLoaded) this.getData(RunName, Url);

    let BarChart;
    if (chartLoaded) {
      BarChart = (
        <TestAutomationStatusChart
          data={chartData.data}
          options={chartData.options}
          onElementsClick={this.handleElementClick}
        />
      );
    } else {
      BarChart = <Buffer size="5" />;
    }

    return (
      <React.Fragment>
        <div className="d-flex bd-highlight">
          <div className="card border-primary bg-light" style={{ width: 850 }}>
            <h6 className="card-header align-items-center">
              {Url}
              <button
                onClick={this.handleRefresh}
                className="btn btn-outline-light btn-sm float-right"
              >
                <i
                  className="fa fa-refresh"
                  style={{ color: "#292b2c" }}
                  aria-hidden="true"
                />
              </button>
            </h6>
            <div className="card-body align-items-center d-flex justify-content-center">
              {BarChart}
            </div>
          </div>
          <TestAutomationStatusChartTimeCards chartData={chartData} />
        </div>
        <TestAutomationScenarioHeaderLogs
          showModal={modal.show}
          input={modal.elementLabel}
          handleModalClose={this.handlePopUpModalClose}
          handleReportDownload={this.handleReportDownload}
        />
      </React.Fragment>
    );
  }
}

export default TestAutomationStatusChartArea;
