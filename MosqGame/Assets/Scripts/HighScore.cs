using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour {

    Dictionary<string, int> PlayerScore;

	// Use this for initialization
	void Start ()
    {

		
	}
     void Input()
    {
        if (PlayerScore != null)
            return;

        PlayerScore = new Dictionary<string, int>();
          
    }
	
	public int GetScore(string username)
    {
        Input();

        if (PlayerScore.ContainsKey(username) == false)
            return -1;

        return PlayerScore[username];
    }

    public void SetScore(string username, int score)
    {
        Input();
        if(PlayerScore.ContainsKey(username) == false)
        {
            PlayerScore[username] = new int();
        }
        PlayerScore[username] = score;
    }
    public void ChangeScore(string username, int score)
    {
        Input();
        int currScore = GetScore(username);
        SetScore(username, currScore + score);
    }
}
