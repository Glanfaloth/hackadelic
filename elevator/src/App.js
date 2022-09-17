import blueprint from "./assets/floor_plan_1.png";
import {useState} from "react";
import "./App.css";
import Colleague from "./components/Colleague";
import Elevator from "./components/Elevator";

function App() {
  var people = require("./assets/people.json");
  const [step, setStep] = useState(0);
  return (
    <div>
      <img
        src={blueprint}
        style={{
          zIndex: "1",
          width: "100vw",
          height: "100vh",
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
          zIndex: "3",
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
      <Elevator />
    </div>
  );
}

export default App;
