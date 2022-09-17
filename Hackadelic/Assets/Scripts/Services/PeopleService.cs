using Newtonsoft.Json.Linq;
using System.Linq;
using UnityEngine;

public class PeopleService : Service
{
    Person[] people;

    public PeopleService() : base("people.json")
    {
        var jObject = JObject.Parse(FileContent);
        var jArray = (JArray)jObject["people"];
        people = jArray.ToObject<Person[]>();
    }

    public Person GetPerson(int peopleId)
    {
        return people.Single(person => person.PeopleId == peopleId);
    }

    public Person GetRandomPerson()
    {
        // Apparently maxRange is inclusive (according to the docs) but testing
        // seemed to prove differently.
        int randPersonId = Random.Range(1, people.Length+1);
        return people.Single(person => person.PeopleId == randPersonId);
    }
}
