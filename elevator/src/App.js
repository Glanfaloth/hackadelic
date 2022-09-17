import blueprint from "./assets/floor_plan_1.png";
import "./App.css";
import Colleague from "./components/Colleague";

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
    </div>
  );
}

export default App;
