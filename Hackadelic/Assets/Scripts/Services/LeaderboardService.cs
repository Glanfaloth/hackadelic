using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
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
    }

    public void AppendToLeardboard(Score score)
    {
        scores.Add(score);
        string jsonObject = JsonConvert.SerializeObject(new { scores = scores });
        System.IO.File.WriteAllText(@$"{Application.dataPath}/Database/leaderboard.json", jsonObject);
    }

}
