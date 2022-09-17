using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject PersonPinPrefab;

    Person[] people;

    Person chosenPerson;

    float inputFreeze = 0f;

    public void InitializeMap()
    {
        people = GameManager.PeopleService.GetAllPeople();

        foreach (Person person in people)
        {
            var personPin = Instantiate(PersonPinPrefab, transform);
            var personPinComponent = personPin.GetComponent<PersonPin>();
            personPinComponent.Initialize(person, this);
        }

        NextPerson(null);
    }

    public void NextPerson(Person person)
    {
        if (inputFreeze > 0f)
        {
            return;
        }

        Debug.Log("NextPerson called");

        if (person != null && person.PeopleId == chosenPerson.PeopleId)
        {
            GameManager.GameState.Points += 1000;
            Debug.Log($"Points received! Current points: {GameManager.GameState.Points}");
        }
        else
        {
            Debug.Log("Initialization or wrong person...");
        }

        person = people[Random.Range(0, people.Length)];

        chosenPerson = person;
        inputFreeze = 0.5f;
    }


    void Update()
    {
        inputFreeze -= Time.deltaTime;
    }
}
