import React from "react";

const DynamicTableRenderRow = (props) => {
  return props.keys.map((key) => {
    return <td key={props.data[key]}>{props.data[key]}</td>;
  });
};

export default DynamicTableRenderRow;
