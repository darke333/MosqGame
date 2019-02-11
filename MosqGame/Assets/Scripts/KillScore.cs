using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillScore : MonoBehaviour {

    public int Score = 0;
    public Text ScoreText;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeScore()
    {
        Score++;
        ScoreText.text = "Счет: " + Score.ToString();
    }

    public void BossKillScore()
    {
        Score += 10;
        ScoreText.text = "Счет: " + Score.ToString();
    }
}
