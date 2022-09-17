import { React, useState } from "react";
import WC from "./WC";
import Elevator from "./Elevator";
import Workspace from "./Workspace";
import Kitchen from "./Kitchen";
export default function Colleague({
  setIsHovered,
  imagePath,
  tableLocationX,
  tableLocationY,
  location,
  description,
  firstName,
}) {
  const [isHoveredLocal, setIsHoveredLocal] = useState(false);
  return (
    <div>
      {!isHoveredLocal ? (
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
          height: isHoveredLocal ? "5vw" : "4vw",
          width: isHoveredLocal ? "5vw" : "4vw",
          borderRadius: isHoveredLocal ? "5vw" : "4vw"
        }}
        onMouseOut={() => {
          setIsHovered(false);
          setIsHoveredLocal(false);
        }}
        onMouseOver={() => {
          setIsHovered(true);
          setIsHoveredLocal(true);
        }}
      />
      {isHoveredLocal && (
        <div
          style={{
            width: "26vw",
            height: "100vh"
          }}
        >
          <p
            style={{
              color: "white",
              fontSize: "2vw",
              position: "absolute",
              left: "3vw",
              bottom: "16vh"
            }}
          >
           Hi, I am {firstName}!
          </p>
          <p
            style={{
              color: "white",
              fontSize: "1.5vw",
              position: "absolute",
              left: "3vw",
              bottom: "8vh"
            }}
          >
            I am in the {location}.
          </p>
          <p
            style={{
              color: "white",
              fontSize: "1.5vw",
              position: "absolute",
              left: "3vw",
              bottom: "2vh"
            }}
          >
            {description}
          </p>
        </div>
      )}
    </div>
  );
}
