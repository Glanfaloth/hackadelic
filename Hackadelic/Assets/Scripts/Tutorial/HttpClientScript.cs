using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using UnityEngine;

public class HttpClientScript : MonoBehaviour
{
    HttpClient httpClient = new HttpClient();

    public async Task SendMessage()
    {
        var response = await httpClient.GetAsync(@"https://hack.myport.guide/availability/");

        // Parse response
        JObject jResponse = JObject.Parse(await response.Content.ReadAsStringAsync());
        bool availability = Convert.ToBoolean(jResponse[nameof(availability)]);

        Debug.Log($"Answer from API: {availability}");
    }

    async Task Start()
    {
        await SendMessage();
    }
}
