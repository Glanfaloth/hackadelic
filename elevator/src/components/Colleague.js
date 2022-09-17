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
          height: isHovered ? 40 : 50,
          width: isHovered ? 40 : 50,
          borderRadius: isHovered ? 40 : 50
        }}
        onMouseOut={() => setIsHovered(true)}
        onMouseOver={() => setIsHovered(false)}
        onClick={()=>{}}
      />
    </div>
  );
}
