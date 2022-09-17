import React from "react";

export default function Colleague({
  imagePath,
  tableLocationX,
  tableLocationY
}) {
  return (
    <div>
      <img
        src={require(`../assets/${imagePath}`)}
        style={{
          width: 20,
          height: 20,
          paddingLeft: tableLocationX,
          paddingTop: tableLocationY
        }}
      />
    </div>
  );
}
