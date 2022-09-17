import blueprint from "./assets/floor_plan_1.png";

import "./App.css";
import Colleague from "./components/Colleague";
import Elevator from "./components/Elevator";

function App() {
  var people = require("./assets/people.json");
  const WebSocket = require("ws");
  const ws = new WebSocket(`wss://hack2.myport.guide/`, { // PORT Gateway URL
    rejectUnauthorized: false
});

  ws.onopen = () => {
    console.log("Connected");
    ws.send(
      JSON.stringify({
        Method: "SUBSCRIBE",
        asyncId: 1,
        "Request-URI": "/topic/liftState/"
      })
    );
    ws.send(
      JSON.stringify({
        Method: "POST",
        asyncId: 2,
        "Request-URI": "/publish/",
        "body-json": {
          asyncId: "8c19718674",
          options: {
            destination: {
              destinationFloor: 7,
              destinationZone: "Floor 7"
            }
          },
          target: {
            floor: 1
          }
        }
      })
    );
  };

  ws.onmessage = (msg) => {
    console.log("Message received:", JSON.parse(msg.data));
  };

  ws.onclose = (e) => {
    console.log(e);
  };

  ws.onerror = (e) => {
    console.error(e);
  };

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
