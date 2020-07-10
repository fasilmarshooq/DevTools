import React from "react";
import TimeCard from "./TimeCard";

const TestAutomationStatusChartTimeCards = ({ chartData }) => {
  return (
    <div className="Container ml-5 mt-1">
      <div className="mb-4">
        <TimeCard
          CardText={chartData.AverageTimeTaken && "Average Time Taken"}
          CardValue={chartData.AverageTimeTaken}
          CardValueUnits={chartData.AverageTimeTaken && "Hrs"}
        />
      </div>
      <div className="mb-4">
        <TimeCard
          CardText={
            chartData.TimeTakenForLastExecution &&
            "Time Taken For Last Execution"
          }
          CardValue={chartData.TimeTakenForLastExecution}
          CardValueUnits={chartData.TimeTakenForLastExecution && "Hrs"}
        />
      </div>
      <div className="mb-4">
        <TimeCard
          CardText={chartData.TimeTakenForLastExecution && "Average Failures"}
          CardValue={chartData.AverageFailures}
        />
      </div>
    </div>
  );
};

export default TestAutomationStatusChartTimeCards;
