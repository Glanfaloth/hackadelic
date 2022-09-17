using Newtonsoft.Json.Linq;

public class TestService : Service
{
    public TestService() : base("people.json") { }

    public JArray GetPeople() {
        var jObject = JObject.Parse(StreamReader.ReadToEnd());
        return (JArray)jObject["people"];
    }
}
