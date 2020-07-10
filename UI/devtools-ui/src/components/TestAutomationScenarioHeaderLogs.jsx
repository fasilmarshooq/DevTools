import React, { Component } from "react";
import PopUpModal from "./common/PopUpModal";
import DynamicTable from "./common/DynamicTable";
import Buffer from "./common/Buffer";
import { GetScenarioStatus } from "../services/ScenarioLogService";

class TestAutomationScenarioHeaderLogs extends Component {
  state = {
    data: [],
    ResponseLoaded: false,
  };

  getData = async (RunName) => {
    if (!RunName) return;
    const data = await GetScenarioStatus(RunName);
    this.setState({ data, ResponseLoaded: true });
  };

  componentWillReceiveProps() {
    this.setState({ ResponseLoaded: false });
  }
  render() {
    const { ResponseLoaded, data } = this.state;
    const {
      showModal,
      handleModalClose,
      input,
      handleReportDownload,
    } = this.props;
    let ModalBody;
    if (ResponseLoaded) {
      if (data[0]) {
        ModalBody = <DynamicTable data={data} />;
      } else {
        ModalBody = <p className="text-center">No Failures</p>;
      }
    } else {
      ModalBody = <Buffer size="2" />;
      this.getData(input);
    }
    return (
      <PopUpModal
        show={showModal}
        onHide={handleModalClose}
        modalHeader="Execution Failures"
        modalBody={ModalBody}
        handleModalFooterButtonClick={handleReportDownload}
        modalFooterButtonLabel="Generate Report"
      />
    );
  }
}

export default TestAutomationScenarioHeaderLogs;
