import React from "react";
import DynamicTableRenderRow from "./DynamicTableRenderRow";
import { toast } from "react-toastify";

function getKeys(data) {
  return Object.keys(data[0]);
}

function getHeader(data) {
  var keys = getKeys(data);
  return keys.map((key) => {
    return <th key={key}>{key.toUpperCase()}</th>;
  });
}

function getRowsData(data) {
  var keys = getKeys(data);
  return data.map((row, index) => {
    return (
      <tr onClick={() => toast.info("yahooo")} key={index}>
        <DynamicTableRenderRow key={index} data={row} keys={keys} />
      </tr>
    );
  });
}

const DynamicTable = ({ data }) => {
  return (
    <div>
      <table className="table table-hover">
        <thead>
          <tr>{getHeader(data)}</tr>
        </thead>
        <tbody>{getRowsData(data)}</tbody>
      </table>
    </div>
  );
};

export default DynamicTable;
