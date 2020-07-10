import React from "react";

const ListGroup = ({
  currentItem,
  onItemChange,
  items,
  textProperty,
  valueProperty,
}) => {
  return (
    <ul className="list-group" style={{ cursor: "pointer" }}>
      {items.map((item) => (
        <li
          key={item[valueProperty]}
          onClick={() => onItemChange(item[textProperty])}
          className={
            item[textProperty] === currentItem
              ? "list-group-item float-left active"
              : "list-group-item float-left"
          }
        >
          {item[textProperty]}
        </li>
      ))}
    </ul>
  );
};

ListGroup.defaultProps = {
  textProperty: "item",
  valueProperty: "Id",
};

export default ListGroup;
