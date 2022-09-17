using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using UnityEngine;

using System.Threading;
// using WebSocketSharp;
using Websocket.Client;
using Newtonsoft.Json;



public class ClientScript : MonoBehaviour
{
    public async Task SendMessage()
    {
        // var exitEvent = new ManualResetEvent(false);
        // var url = new Uri("wss://xxx");

        // using (var client = new WebsocketClient(url))
        // {
        //     client.ReconnectTimeout = TimeSpan.FromSeconds(30);
        //     client.ReconnectionHappened.Subscribe(info =>
        //         Log.Information($"Reconnection happened, type: {info.Type}"));

        //     client.MessageReceived.Subscribe(msg => Log.Information($"Message received: {msg}"));
        //     client.Start();

        //     Task.Run(() => client.Send("{ message }"));

        //     exitEvent.WaitOne();
        // }
        try
        {
            var url = new Uri("wss://hack2.myport.guide/");
            
            using (var client = new WebsocketClient(url))
            {
                client.ReconnectTimeout = TimeSpan.FromSeconds(30);
                client.ReconnectionHappened.Subscribe(info =>
                {
                    Debug.Log("Reconnection happened, type: " + info.Type);
                });
                client.MessageReceived.Subscribe(msg =>
                {
                    Debug.Log("Message received: " + msg);    
                    if (msg.ToString().ToLower() == "connected")
                                {
                                    string data = "{\"Method\":\"" + "SUBSCRIBE" + "\", \"Request-URI\":\"/topic/liftState\"}";
                                    client.Send(data);
                                }
                });
                client.Start();
                //Task.Run(() => client.Send("{ message }"));
            }
        }
catch (Exception ex)
  {
      Console.WriteLine("ERROR: " + ex.ToString());
  }
    }

    async Task Start()
    {

        await SendMessage();
    }
}









// public class HttpClientScript : MonoBehaviour
// {
//     HttpClient httpClient = new HttpClient();

//     public async Task SendMessage()
//     {
//         var response = await httpClient.GetAsync(@"https://hack.myport.guide/availability/");

//         // Parse response
//         JObject jResponse = JObject.Parse(await response.Content.ReadAsStringAsync());
//         bool availability = Convert.ToBoolean(jResponse[nameof(availability)]);

//         Debug.Log($"Answer from API: {availability}");
//     }

//     async Task Start()
//     {
//         await SendMessage();
//     }
// }
