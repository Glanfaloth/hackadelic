using Newtonsoft.Json.Linq;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Objects
    public MapManager MapManager;
    public LeaderboardManager LeaderboardManager;

    // States
    public static GameState GameState;

    //Services
    public static PeopleService PeopleService;
    public static LeaderboardService LeaderboardService;

    // Elevator
    public static ElevatorCommunicator ElevatorCommunicator;

    public void InitializeGame()
    {
        GameState.GameProgression = GameProgression.RunningGame;
        GameState.Points = 0.0f;
        GameState.Time = 0.0f;

        MapManager.gameObject.SetActive(true);
        MapManager.InitializeMap();

    }

    public void ShowLeaderboards()
    {
        GameState.GameProgression = GameProgression.ShowingLeaderboards;

        MapManager.gameObject.SetActive(false);

        LeaderboardManager.gameObject.SetActive(true);
        LeaderboardManager.InitializeLeaderboard(LeaderboardService.scores);
    }

    void Awake()
    {
        GameState = new GameState()
        {
            GameProgression = GameProgression.Idle
        };

        ElevatorCommunicator = new ElevatorCommunicator(this);

        PeopleService = new PeopleService();
        LeaderboardService = new LeaderboardService();
    }

    void Start()
    {
        InitializeGame();
    }

    void Update()
    {
        ElevatorCommunicator.Update();
        if (GameState.GameProgression == GameProgression.RunningGame)
        {
            GameState.Time += Time.deltaTime;
        }
    }

    void StopGame()
    {
        GameState.GameProgression = GameProgression.Idle;
        LeaderboardManager.gameObject.SetActive(false);
    }
}
