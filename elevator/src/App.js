import blueprint from "./assets/floor_plan_1.png";
import logo from "./assets/schindlerlogo.png";
import "./App.css";
import Colleague from "./components/Colleague";
import Elevator from "./components/Elevator";

function App() {
  var people = require("./assets/people.json");
  return (
    <div>
      {" "}
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
          backgroundColor: "white",
          width: "120px",
          height: "95vh",
          position: "absolute",
          right: "10px",
          zIndex: "3",
          border: "2px solid",
          borderColor: "red",
          borderRadius: "10px",
          padding: "5px",
          alignContent: "center"
        }}
      ></div>
      <div
        style={{
          backgroundColor: "white",
          width: "100px",
          height: "100px",
          position: "absolute",
          right: "20px",
          zIndex: "4",
          border: "2px solid",
          borderColor: "red",
          padding: "5px",
          alignContent: "center"
        }}
      >
        <img
          src={logo}
          style={{
            width: 92,
            height: 80,
            
          }}
        />
      </div>
    </div>
  );
}

export default App;
