using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using UnityEngine;
using Websocket.Client;

public class ElevatorCommunicator
{
    GameManager gameManager;

    ElevatorState ElevatorState { get; set; } = ElevatorState.Waiting;

    string relevantElevator = "liftState:1.1.1";

    WebsocketClient socket;

    Queue<Action> jobs = new Queue<Action>();

    public ElevatorCommunicator(GameManager gameManager)
    {
        this.gameManager = gameManager;
        InitalizeWebSocket();
    }

    public void Update()
    {
        while (jobs.Count > 0)
        {
            jobs.Dequeue().Invoke();
        }
    }

    void InitalizeWebSocket()
    {
        var url = new Uri("wss://hack2.myport.guide/");
        socket = new WebsocketClient(url);
        socket.ReconnectTimeout = TimeSpan.FromSeconds(10);
        socket.ReconnectionHappened.Subscribe(info =>
        {
            socket.Send(TestRequest());
            Debug.Log($"Reconnection happened: {info.Type}");
        });
        socket.MessageReceived.Subscribe(message =>
        {
            ProcessMessage(message.Text);
        });
        socket.Start();
        socket.Send(TestRequest());
    }

    string TestRequest()
    {
        var jsonObject = new JObject();
        jsonObject.Add("Method", "SUBSCRIBE");
        jsonObject.Add("asyncId", 1);
        jsonObject.Add("Request-URI", "/topic/liftState");

        return jsonObject.ToString();
    }

    void ProcessMessage(string message)
    {
        ElevatorMessage elevatorMessage = new ElevatorMessage(JObject.Parse(message));
        if (elevatorMessage?.Name == "")
        {
            return;
        }

        if (elevatorMessage.Name == relevantElevator &&
            ElevatorState != elevatorMessage.ElevatorState)
        {
            ElevatorState = elevatorMessage.ElevatorState;

            switch (ElevatorState)
            {
                case ElevatorState.Waiting:
                    jobs.Enqueue(gameManager.ShowLeaderboards);
                    break;
                case ElevatorState.Running:
                    jobs.Enqueue(gameManager.InitializeGame);
                    break;
                    ;
            }
            Debug.Log($"ElevatorState: {ElevatorState}");
        }
    }
}