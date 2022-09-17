using System;
using UnityEngine;
using Websocket.Client;

public class WebsocketScript : MonoBehaviour
{
    WebsocketClient client;
    void Start()
    {
        // var url = new Uri("wss://hack2.myport.guide/");
        var url = new Uri("wss://demo.piesocket.com/v3/channel_1?api_key=VCXCEuvhGcBDP7XhiJJUDvR1e1D3eiVjgZ9VRiaV&notify_self");
        client = new WebsocketClient(url);
        client.MessageReceived.Subscribe(message => Debug.Log($"Message received: {message}"));
        client.Start();
        client.Send("Hallo");
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
