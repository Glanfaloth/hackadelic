import { React } from "react";
import kitchen from "../assets/kitchen.png";
export default function Kitchen({}) {
  return (
    <img
      src={kitchen}
      id={"kitchen"}
      style={{
        position: "absolute",
        width: "15vw",
        left: "27vw",
        top: "46vh"
      }}
    />
  );
}
