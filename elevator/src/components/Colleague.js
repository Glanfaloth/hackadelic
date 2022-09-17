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
          left: tableLocationX,
          top: tableLocationY,
          position: "absolute",
          height: isHovered ? 50 : 40,
          width: isHovered ? 50 : 40,
          borderRadius: isHovered ? 50 : 40,
        }}
        onMouseOut={() => setIsHovered(false)}
        onMouseOver={() => setIsHovered(true)}
        onClick={()=>{}}
      />
    </div>
  );
}
