import blueprint from "../assets/floor_plan_1.png";
import wc from "../assets/wc.png";
import elevator from "../assets/elevator.png";
import workspace from "../assets/workspace.png";
import kitchen from "../assets/kitchen.png";
import { useState } from "react";
import "../App.css";
import Colleague from "./Colleague";
import Elevator from "./Elevator";

function Game() {
  var people = require("../assets/people.json");
  const [step, setStep] = useState(0);
  return (
    <div>
      <img
        src={blueprint}
        style={{
          zIndex: "1",
          width: "100%",
          height: undefined,
          position: "fixed"
        }}
        alt="logo"
      />
      <div
        style={{
          zIndex: "1",
          width: "100vw",
          height: "100vh",
          position: "fixed",
          backgroundColor: "rgba(0, 0, 0, 0.4)"
        }}
      ></div>
      <div
        style={{
          zIndex: "4",
          position: "absolute"
        }}
      >
        {people.people.map((person, index) => (
          <Colleague
            key={index}
            peopleId={person.peopleId}
            firstName={person.firstName}
            lastName={person.lastName}
            description={person.description}
            imagePath={person.imagePath}
            floorNumber={person.floorNumber}
            tableLocationX={person.tableLocationX}
            tableLocationY={person.tableLocationY}
          />
        ))}
      </div>
      <div
        style={{
          backgroundColor: "cyan",
          opacity: "0.4",
          width: "120px",
          height: "95vh",
          position: "absolute",
          right: "10px",
          zIndex: "3",
          border: "5px solid",
          borderColor: "black",
          borderRadius: "10px",
          marginTop: "10px",
          padding: "5px",
          alignContent: "center"
        }}
      ></div>
      <img
        src={elevator}
        id={"elevator"}
        style={{
          zIndex: "3",
          position: "absolute",
          width: "6vw",
          left: "54vw",
          top: "30vh"
        }}
      />
      <img
        src={kitchen}
        id={"kitchen"}
        style={{
          zIndex: "3",
          position: "absolute",
          width: "15vw",
          left: "27vw",
          top: "46vh",
        }}
      />
      <img
        src={workspace}
        id={"workspace"}
        style={{
          zIndex: "3",
          position: "absolute",
          width: "11vw",
          left: "51vw",
          top: "65vh"
        }}
      />
      <img
        src={wc}
        id={"wc"}
        style={{
          zIndex: "3",
          position: "absolute",
          width: "19vw",
          left: "25.5vw",
          top: "14vh"
        }}
      />
      <Elevator />
    </div>
  );
}

export default Game;
