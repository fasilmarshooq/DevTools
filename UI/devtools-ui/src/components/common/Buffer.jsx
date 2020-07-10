import React from "react";
const Buffer = ({ size }) => {
  return (
    <div className="text-center">
      <i className={`fa fa-spinner fa-pulse fa-${size}x fa-fw`} />
    </div>
  );
};

export default Buffer;
