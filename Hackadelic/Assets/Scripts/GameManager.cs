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
        
        LeaderboardManager.gameObject.SetActive(false);
    }

    public void ShowLeaderboards()
    {
        GameState.GameProgression = GameProgression.ShowingLeaderboards;
        MapManager.gameObject.SetActive(false);
        if (GameState.Points > 0)
        {
            LeaderboardService.AppendToLeardboard(new Score()
            {
                    PlayerId = 0,
                    TotalScore = GameState.Points,
                    TotalTime = GameState.Time,
                    RelativeScore = GameState.Points / GameState.Time,
                    Timestamp = DateTime.Today.ToOADate()
            });
        }

        LeaderboardManager.gameObject.SetActive(true);
        LeaderboardManager.InitializeLeaderboard(LeaderboardService.scores);
        LeaderboardManager.DrawScoreBars();
        StartCoroutine(LeaderboardManager.DrawPlayerBar());
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
        // ShowLeaderboards();
    }

    void Update()
    {
        ElevatorCommunicator.Update();
        if (GameState.GameProgression == GameProgression.RunningGame)
        {
            GameState.Time += Time.deltaTime;
        }

        if (Input.GetKeyUp("f"))
        {
            if (GameState.GameProgression == GameProgression.RunningGame)
            {
                ShowLeaderboards();
            }
            else if (GameState.GameProgression == GameProgression.ShowingLeaderboards)
            {
                InitializeGame();
            }
        }
    }

    void StopGame()
    {
        GameState.GameProgression = GameProgression.Idle;
        LeaderboardManager.gameObject.SetActive(false);
    }
}
