using System.Collections;
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
        for (int i = 0; i < scores.Count; i++)
        {

            if (scores[i].totalScore > first_place.totalScore)
            {
                third_place = second_place;
                second_place = first_place;
                first_place = scores[i];
            }
            if (i > 0 && 
                scores[i].totalScore > second_place.totalScore &&
                scores[i].totalScore < first_place.totalScore)
            {
                third_place = second_place;
                second_place = scores[i];
            }
            if (i > 1 && 
                scores[i].totalScore > third_place.totalScore &&
                scores[i].totalScore < second_place.totalScore)
            {
                third_place = scores[i];
            }
        }

        Debug.Log($"1st place {first_place.playerId} with {first_place.totalScore} pts.");
        Debug.Log($"2nd place {second_place.playerId} with {second_place.totalScore} pts.");
        Debug.Log($"3rd place {third_place.playerId} with {third_place.totalScore} pts.");
        Debug.Log($"Your score: {curr_player.totalScore} pts.");
    }
}
