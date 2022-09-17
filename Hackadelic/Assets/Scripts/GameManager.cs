using Newtonsoft.Json.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // States
    public static GameState GameState;

    //Services
    public static PeopleService PeopleService;

    void Awake() {
        GameState = new GameState();
        PeopleService = new PeopleService();
    }

    void Start() {
        var secondPerson = PeopleService.GetPerson(2);
        Debug.Log($"The second person's last name is {secondPerson.LastName}.");

        var randPerson = PeopleService.GetRandomPerson();
        Debug.Log($"The random person's last name is {randPerson.LastName}.");
    }

    void Update() {
        GameState.Time += Time.deltaTime;
    }
}
