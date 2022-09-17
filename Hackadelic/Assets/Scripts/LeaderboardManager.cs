using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    public void InitializeLeaderboard(List<Score> scores)
    {
        Score first_place = new Score();
        Score second_place = new Score();
        Score third_place = new Score();
        Score curr_player = scores[scores.Count - 1]; // curr player should always be appended last
        
        List<Score> sorted_scores = scores.OrderByDescending(x => x.relativeScore).ToList();

        Debug.Log($"1st place {sorted_scores[0].playerId} with {sorted_scores[0].relativeScore} pts.");
        Debug.Log($"2nd place {sorted_scores[1].playerId} with {sorted_scores[1].relativeScore} pts.");
        Debug.Log($"3rd place {sorted_scores[2].playerId} with {sorted_scores[2].relativeScore} pts.");
        Debug.Log($"Your score: {curr_player.relativeScore} pts.");
    }
}
