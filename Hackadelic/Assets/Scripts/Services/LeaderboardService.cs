using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardService : Service
{
    public List<Score> scores = new List<Score>();

    public LeaderboardService() : base("leaderboard.json")
    {
        var jObject = JObject.Parse(FileContent);
        var jArray = (JArray)jObject["scores"];
        Score[] scores_list = jArray.ToObject<Score[]>();
        for (int i = 0; i < scores_list.Length; i++) {
            scores.Add(scores_list[i]);
        }
        Debug.Log(scores.Count);

    }

    public void AppendToLeardboard(Score score)
    {
        // Debug.Log(scores.Count);
        // scores.Append(score);
        // Debug.Log(scores.Count);


        // var filePath = $"{Application.dataPath}/Database/leaderboard.json";
        // Debug.Log(scores[1].totalTime);
        // string jsonObject = JsonUtility.ToJson(scores);
        // Debug.Log(jsonObject);



    }

}
