import { React, useState, useEffect } from "react";
import logo from "../assets/schindlerlogo.png";
export default function ElevatorUI({}) {
  const [height, setHeihgt] = useState(20);
  useEffect(() => {
    const interval = setInterval(() => {
      setHeihgt((e) => Math.min(e + 10, 640));
    }, 1000);
    return () => {
      clearInterval(interval);
    };
  }, []);
  return (
    <div
      style={{
        backgroundColor: "white",
        width: "8vw",
        height: "15vh",
        position: "absolute",
        right: "20px",
        zIndex: "4",
        border: "5px solid",
        borderRadius: "10px",
        borderColor: height < 640 ? "red" : "green",
        bottom: `${height}px`,
        padding: "1vw",
        display: "flex",
        flexDirection: "column",
        alignItems: "center"
      }}
    >
      <img
        src={logo}
        style={{
          width: "5.75vw",
          height: "5vw"
        }}
      />
    </div>
  );
}
