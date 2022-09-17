using Newtonsoft.Json.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // States
    public static GameState GameState;

    //Services
    public static TestService TestService;

    void Awake() {
        GameState = new GameState();
        TestService = new TestService();
    }

    void Start() {
        var people = TestService.GetPeople();
        var secondPerson = (JObject)people[1];
        var lastName = secondPerson["lastName"].ToString();
        Debug.Log($"Last name of second person: {lastName}");
    }

    void Update() {
        GameState.Time += Time.deltaTime;
    }
}
