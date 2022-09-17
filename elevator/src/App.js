
import { useState } from "react";
import "./App.css";
import Game from "./components/Game";

function App() {
  const [step, setStep] = useState(0);
  return (
    <div>
      <Game />
    </div>
  );
}

export default App;
