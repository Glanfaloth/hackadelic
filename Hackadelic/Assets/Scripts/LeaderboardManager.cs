using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    List<Score> sorted_scores;
    Score playerScore;
    Vector3[] BasePositions = new Vector3[]{
        new Vector3(-12.0f, 0.0f, 0.0f),
        new Vector3(-4.0f, 0.0f, 0.0f),
        new Vector3(4.0f, 0.0f, 0.0f),
        new Vector3(12.0f, 0.0f, 0.0f),
    };
    Vector3 barBaseScale = new Vector3(2.0f, 0.0f, 1.0f);
    Vector3 e_y = new Vector3(0.0f, 1.0f, 0.0f);

    public void InitializeLeaderboard(List<Score> scores)
    {
        Score first_place = new Score();
        Score second_place = new Score();
        Score third_place = new Score();
        Score curr_player = scores[scores.Count - 1]; // curr player should always be appended last
        playerScore = curr_player;
        sorted_scores = scores.OrderByDescending(x => x.RelativeScore).ToList();

        Debug.Log($"1st place {sorted_scores[0].PlayerId} with {sorted_scores[0].RelativeScore} pts.");
        Debug.Log($"2nd place {sorted_scores[1].PlayerId} with {sorted_scores[1].RelativeScore} pts.");
        Debug.Log($"3rd place {sorted_scores[2].PlayerId} with {sorted_scores[2].RelativeScore} pts.");
        Debug.Log($"Your score: {curr_player.RelativeScore} pts.");
    }

    public void DrawScoreBars()
    {
        string[] barNames = new string[]{"ScoreFirst", "ScoreSecond", "ScoreThird"};
        
        for (int i = 0; i < barNames.Length; i++)
        {
            GameObject currentBar = transform.Find(barNames[i]).gameObject;
            float barScale = 16.0f * (float)sorted_scores[i].RelativeScore / (float)sorted_scores[0].RelativeScore;
            currentBar.transform.localScale = barBaseScale + barScale * e_y;
            currentBar.transform.localPosition = BasePositions[i] + (0.5f * barScale - 8.0f) * e_y;
        }
        
    }

    public IEnumerator DrawPlayerBar()
    {
        for (float j = 0; j < 1.0f; j += 0.002f)
        {
            GameObject playerBar = transform.Find("ScorePlayer").gameObject;
            float barScalePlayer = j * 16.0f * (float)playerScore.RelativeScore / (float)sorted_scores[0].RelativeScore;
            playerBar.transform.localScale = barBaseScale + barScalePlayer * e_y;
            playerBar.transform.localPosition = BasePositions[3] + (0.5f * barScalePlayer - 8.0f) * e_y;
            yield return null;
        }

    }
}
