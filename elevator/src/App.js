import blueprint from "./assets/floor_plan_1.png";
import "./App.css";

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={blueprint} style={{ width: "100vw" }} alt="logo" />
      </header>
    </div>
  );
}

export default App;
