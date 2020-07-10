import React from "react";

const InputFile = ({ name, onChange, selectedFileName }) => {
  return (
    <React.Fragment>
      <input
        type="file"
        name={name}
        className="custom-file-input"
        id={name}
        onChange={onChange}
      />
      <label className="custom-file-label" htmlFor={name}>
        {selectedFileName}
      </label>
    </React.Fragment>
  );
};

export default InputFile;
