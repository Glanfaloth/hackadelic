using Newtonsoft.Json.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Objects
    public MapManager MapManager;

    // States
    public static GameState GameState;

    //Services
    public static PeopleService PeopleService;

    void Awake()
    {
        GameState = new GameState()
        {
            GameProgression = GameProgression.Idle
        };
        PeopleService = new PeopleService();
    }

    void Start()
    {
        InitializeGame();
    }

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

        MapManager.gameObject.SetActive(false);
        MapManager.InitializeMap();

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
