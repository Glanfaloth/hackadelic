using Newtonsoft.Json.Linq;
using System.Linq;

public class TestService : Service
{
    Person[] people;

    public TestService() : base("people.json")
    {
        var jObject = JObject.Parse(FileContent);
        var jArray = (JArray)jObject["people"];
        people = jArray.ToObject<Person[]>();
    }

    public Person GetPerson(int peopleId)
    {
        return people.Single(person => person.PeopleId == peopleId);
    }
}
