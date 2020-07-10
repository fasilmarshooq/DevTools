import React from "react";

const TimeCard = ({ CardText, CardValue, CardValueUnits }) => {
  return (
    <div
      className="card bg-light border-primary"
      style={{ width: 200, height: 150 }}
    >
      <div className="card-body">
        <h6 className="card-title text-center">{CardText}</h6>
        <div className="mt-2">
          <h2 className="card-text text-center">
            {CardValue}
            {CardValueUnits}
          </h2>
        </div>
      </div>
    </div>
  );
};

export default TimeCard;
