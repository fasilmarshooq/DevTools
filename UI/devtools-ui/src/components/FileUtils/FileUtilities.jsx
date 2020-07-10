import React, { Component } from "react";
import InputFile from "./../common/InputFile";
import InputDropDown from "../common/InputDropDown";
import { toast } from "react-toastify";
import {
  handleFileUpload,
  handleDownload,
} from "../../services/FileUtilServices";

class FileUtilities extends Component {
  state = {
    data: {},
    FileUtilEnums: [],
    file: null,
    filename: "Choose file",
  };

  onFileUpload = (event) => {
    this.setState({
      file: event.target.files[0],
      filename: event.target.files[0].name,
    });
  };

  ProcessFile = async () => {
    const { data, file } = this.state;
    if (!data["EnumValue"])
      toast.info("Please Select an option for File Processing");
    else {
      const response = await handleFileUpload(data["EnumValue"], file);
      if (response) {
        handleDownload(response.data.Content, response.data.FileName);
      }
    }
  };

  componentDidMount() {
    const data = { ...this.state.data };
    data["EnumValue"] = "EncryptFile";
    this.setState({ FileUtilEnums: window.FileUtilOptions, data });
  }

  handleDropDownChange = ({ currentTarget }) => {
    const data = { ...this.state.data };
    data[currentTarget.name] = currentTarget.value;
    this.setState({ data });
  };

  render() {
    const { FileUtilEnums, data, filename, file } = this.state;
    return (
      <div
        className="card border-primary bg-light"
        style={{
          height: 260,
          width: 400,
          position: "absolute",
          left: 530,
          top: 150,
        }}
      >
        <h6 className="card-header align-items-center">
          <div className="text-center">
            <h6>File Utilities</h6>
          </div>
        </h6>
        <div className="card-body mt-n4">
          <InputDropDown
            enumValues={FileUtilEnums}
            value={data["EnumValue"]}
            name="EnumValue"
            onChange={this.handleDropDownChange}
          />

          <div className="custom-file">
            <InputFile
              name="File"
              onChange={this.onFileUpload}
              selectedFileName={filename}
            />
            <button
              disabled={!file}
              onClick={this.ProcessFile}
              className="btn btn-primary btn-lg btn-block mt-3"
            >
              Process File
            </button>
          </div>
        </div>
      </div>
    );
  }
}

export default FileUtilities;
