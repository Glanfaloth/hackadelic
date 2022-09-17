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
        var secondPerson = TestService.GetPerson(2);
        Debug.Log($"The second person's last name is {secondPerson.LastName}.");
    }

    void Update() {
        GameState.Time += Time.deltaTime;
    }
}
