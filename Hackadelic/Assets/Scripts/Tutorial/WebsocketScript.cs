using System;
using UnityEngine;
using Websocket.Client;

public class WebsocketScript : MonoBehaviour
{
    WebsocketClient client;
    void Start()
    {
        var url = new Uri("wss://hack2.myport.guide/");
        client = new WebsocketClient(url);
        client.MessageReceived.Subscribe(message => Debug.Log($"Message received: {message}"));
        client.Start();
        client.Send("{\"Method\":\"SUBSCRIBE\", \"asyncId\": 1, \"Request-URI\":\"/topic/liftState\"}");
    }

    float waitingTime = 2f;

    void Update()
    {
        waitingTime -= Time.deltaTime;
        if (waitingTime < 0f)
        {
            waitingTime = 2f;
        }
    }
}
