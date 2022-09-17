using Newtonsoft.Json.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Objects
    public MapManager MapManager;
    public LeaderboardManager LeaderboardManager;

    // Fake Elevator
    public static ElevatorCommunicator ElevatorCommunicator;

    // States
    public static GameState GameState;

    //Services
    public static PeopleService PeopleService;
    public static LeaderboardService LeaderboardService;

    void Awake()
    {
        GameState = new GameState()
        {
            GameProgression = GameProgression.Idle
        };
        PeopleService = new PeopleService();
        LeaderboardService = new LeaderboardService();
    }

    void Start()
    {
        // InitializeGame();
        ShowLeaderboards();
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

        MapManager.gameObject.SetActive(true);
        MapManager.InitializeMap();

    }

    void ShowLeaderboards()
    {
        GameState.GameProgression = GameProgression.ShowingLeaderboards;
        MapManager.gameObject.SetActive(false);
        LeaderboardManager.gameObject.SetActive(true);
        LeaderboardManager.InitializeLeaderboard(LeaderboardService.scores);

    }

    void StopGame()
    {
        GameState.GameProgression = GameProgression.Idle;
        LeaderboardManager.gameObject.SetActive(false);
    }
}
