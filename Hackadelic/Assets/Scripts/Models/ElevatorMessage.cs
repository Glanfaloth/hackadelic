using Newtonsoft.Json.Linq;
using System;
using UnityEngine;

public class ElevatorMessage
{
    public ElevatorMessage(JObject jsonObject)
    {
        try
        {
            if (jsonObject.ContainsKey("type"))
            {
                if (Convert.ToString(jsonObject["type"]) != "topic")
                {
                    return;
                }
            }
            else
            {
                return;
            }

            Name = Convert.ToString(jsonObject["name"]);

            var dataObject = (JObject)jsonObject["data"];

            string movingState = Convert.ToString(dataObject["doorState"]);
            ElevatorState = movingState switch
            {
                "locked" => ElevatorState.Running,
                "locking" => ElevatorState.Running,
                "closed" => ElevatorState.Running,
                _ => ElevatorState.Waiting
            };
        }
        catch { }
    }

    public string Name { get; set; }
    public ElevatorState ElevatorState { get; set; }
}