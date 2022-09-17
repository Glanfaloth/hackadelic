import { React } from "react";
import elevator from "../assets/elevator.png";
export default function Elevator({}) {
  return (
    <img
      src={elevator}
      id={"elevator"}
      style={{
        position: "absolute",
        width: "6vw",
        left: "54vw",
        top: "30vh"
      }}
    />
  );
}
