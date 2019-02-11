using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SavingScore : MonoBehaviour {

    string path;

    /*
    public void AddScore(string name, int score)
    {
        path = Application.dataPath + "/PlayersScore/PlayersScore.json";
        string jsonstring = File.ReadAllText(path);
        ScoreList Scores = JsonUtility.FromJson<ScoreList>(jsonstring);
        Scores.Score.Add(new PlayersScore(name, score));
        string serialized = JsonUtility.ToJson(Scores);
        File.WriteAllText(path, serialized);
    }

    [System.Serializable]
    class ScoreList
    {
        public List<PlayersScore> Score;
    }

    [System.Serializable]
    public class PlayersScore
    {
        public string name;
        public int score;

        public PlayersScore(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
    }

    void CreateNew()
    {
        path = Application.dataPath + "/PlayersScore/PlayersScore.json";
        ScoreList Scores = new ScoreList();
        Scores.Score = new List<PlayersScore>();
        string jsonstring = File.ReadAllText(path);
        Scores = JsonUtility.FromJson<ScoreList>(jsonstring);
        Scores.Score.Add(new PlayersScore("Mike", 10));
        Scores.Score.Add(new PlayersScore("Bill", 7));
        Scores.Score.Add(new PlayersScore("Bob", 4));
        Scores.Score.Add(new PlayersScore("Jack", 12));
        Scores.Score.Add(new PlayersScore("Logan", 17));
        Scores.Score.Add(new PlayersScore("Rose", 6));
        string serialized = JsonUtility.ToJson(Scores);
        File.WriteAllText(path, serialized);
        serialized = File.ReadAllText(path);
        print(serialized);
    }*/
}
