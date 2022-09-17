import { React } from "react";
import workspace from "../assets/workspace.png";
export default function Workspace({}) {
  return (
    <img
      src={workspace}
      id={"workspace"}
      style={{
        position: "absolute",
        width: "11vw",
        left: "51vw",
        top: "65vh"
      }}
    />
  );
}
