import { React, useState } from "react";
import WC from "./WC";
import Elevator from "./Elevator";
import Workspace from "./Workspace";
import Kitchen from "./Kitchen";
export default function Colleague({
  imagePath,
  tableLocationX,
  tableLocationY,
  location
}) {
  const [isHovered, setIsHovered] = useState(false);
  return (
    <div>
      {!isHovered ? (
        <></>
      ) : location == "elevator" ? (
        <Elevator />
      ) : location == "kitchen" ? (
        <Kitchen />
      ) : location == "workspace" ? (
        <Workspace />
      ) : location == "wc" ? (
        <WC />
      ) : (
        location == "wc"
      )}
      <img
        src={require(`../assets/${imagePath}`)}
        style={{
          left: `${tableLocationX}vw`,
          top: `${tableLocationY}vh`,
          position: "absolute",
          height: isHovered ? "5vw" : "4vw",
          width: isHovered ? "5vw" : "4vw",
          borderRadius: isHovered ? "5vw" : "4vw"
        }}
        onMouseOut={() => setIsHovered(false)}
        onMouseOver={() => setIsHovered(true)}
        onClick={() => {}}
      />
    </div>
  );
}
