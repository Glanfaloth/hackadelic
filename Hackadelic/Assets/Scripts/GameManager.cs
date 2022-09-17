using Newtonsoft.Json.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // States
    public static GameState GameState;

    //Services
    public static TestService TestService;

    void Awake()
    {
        GameState = new GameState()
        {
            GameProgression = GameProgression.Idle
        };
        TestService = new TestService();
    }

    void Start() { }

    void Update()
    {
        if (GameState.GameProgression == GameProgression.RunningGame)
        {
            GameState.Time += Time.deltaTime;
        }
    }

    void InitializeGame()
    {
        GameState.GameProgression = GameProgression.RunningGame;
        GameState.Points = 0.0f;
        GameState.Time = 0.0f;
    }

    void ShowLeaderboards()
    {
        GameState.GameProgression = GameProgression.ShowingLeaderboards;
    }

    void StopGame()
    {
        GameState.GameProgression = GameProgression.Idle;
    }
}
