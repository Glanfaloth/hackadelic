import { React, useState } from "react";

export default function Colleague({
  imagePath,
  tableLocationX,
  tableLocationY
}) {
  const [isHovered, setIsHovered] = useState(false);
  return (
    <div>
      <img
        src={require(`../assets/${imagePath}`)}
        style={{
          left: `${tableLocationX}vw`,
          top: `${tableLocationY}vh`,
          position: "absolute",
          height: isHovered ? "5vw" : "4vw",
          width: isHovered ? "5vw" : "4vw",
          borderRadius: isHovered ? "5vw" : "4vw"
        }}
        onMouseOut={() => setIsHovered(false)}
        onMouseOver={() => setIsHovered(true)}
        onClick={() => {}}
      />
    </div>
  );
}
