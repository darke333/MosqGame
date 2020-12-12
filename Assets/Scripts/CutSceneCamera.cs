using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneCamera : MonoBehaviour {

    public Transform enemy;
    public Transform Range;
    public GameObject Player;
    float timecounter;
    float timecount;
    public GameObject controller;
    public GameObject[] enemes;
    bool IsFlying;
    Vector3 waypoint;


	// Use this for initialization
	void Start ()
    {
        IsFlying = true;
        timecount = 8f;
        timecounter = 0;
        gameObject.transform.position = Player.transform.position;
        float x = Mathf.Cos(timecounter + Mathf.PI * 1.7f) - 0.45f;
        float z = Mathf.Sin(timecounter + Mathf.PI * 1.7f) + 6;
        waypoint = new Vector3(x, 1.1f, z);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!IsFlying)
        {
            timecount -= Time.deltaTime;
            if (timecount < 0)
            {
                gameObject.transform.position = Vector3.MoveTowards(waypoint, Player.transform.position, Time.deltaTime * 2);
                if (gameObject.transform.position == Player.transform.position)
                {
                    Destroy(enemy.transform.root.gameObject);
                    enemy = Range;
                    Player.SetActive(true);
                    foreach (GameObject Enemy in enemes)
                    {
                        Enemy.SetActive(true);
                    }
                    controller.GetComponent<StarMenu>().Stop = false;
                    timecount = 8f;
                    timecounter = 0;
                    gameObject.SetActive(false);
                }
                
            }
            if (timecount > 2.6f)
            {
                
                timecounter += Time.deltaTime;
                float x = Mathf.Cos(timecounter + Mathf.PI * 1.7f) - 0.45f;
                float z = Mathf.Sin(timecounter + Mathf.PI * 1.7f) + 6;
                transform.position = new Vector3(x, 1.1f, z);
                gameObject.transform.LookAt(enemy);
                //print(transform.position);
            }
            else if(timecount > 0)
            {
                timecounter += Time.deltaTime * 0.5f;
                float x = Mathf.Cos(timecounter + Mathf.PI * 1.7f) - 0.45f;
                float z = Mathf.Sin(timecounter + Mathf.PI * 1.7f) + 6;
                transform.position = new Vector3(x, 1.1f, z);
                gameObject.transform.LookAt(enemy);
            }
        }
        else
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, waypoint,  Time.deltaTime * 2);
            if (gameObject.transform.position == waypoint)
            {
                IsFlying = false;
            }
        }

    }

}
