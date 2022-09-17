using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject PersonPinPrefab;

    public void InitializeMap()
    {
        var people = GameManager.PeopleService.GetAllPeople();
        foreach(var person in people)
        {
            var personPin = Instantiate(PersonPinPrefab, transform);
            var personPinCompontent = personPin.GetComponent<PersonPin>();
            personPinCompontent.Initialize(person);
        }

    }

    public string Test()
    {
        return "This is a test message.";
    }
}
