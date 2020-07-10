import React from "react";
import { Bar } from "react-chartjs-2";

const TestAutomationStatusChart = ({ data, options, onElementsClick }) => {
  return (
    <Bar
      data={data}
      options={options}
      onElementsClick={(elems) => {
        onElementsClick(elems);
      }}
    />
  );
};

export default TestAutomationStatusChart;
