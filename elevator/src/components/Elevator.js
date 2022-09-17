import { React } from "react";
import logo from "../assets/schindlerlogo.png";
export default function Elevator({}) {
  
  return (
    <div
      style={{
        backgroundColor: "white",
        width: "100px",
        height: "120px",
        position: "absolute",
        right: "20px",
        zIndex: "4",
        border: "2px solid",
        borderRadius: "10px",
        borderColor: "red",
        bottom: "20px",
        padding: "5px",
        alignContent: "center"
      }}
    >
      <img
        src={logo}
        style={{
          width: 92,
          height: 80
        }}
      />
    </div>
  );
}
