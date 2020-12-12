using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour {

    bool IsEcape;
    GameObject EscapePoint;
    GameObject DeletePoint;
    bool secondpath;
    public bool stop;
    bool ThirdWave;
    GameObject Boss;
    // Use this for initialization
    void Start ()
    {
        stop = false;
        IsEcape = false;
        EscapePoint = GameObject.Find("CaveEscape (1)");
        DeletePoint = GameObject.Find("CaveEscape");
        secondpath = false;
        ThirdWave = GameObject.Find("Controller").GetComponent<StarMenu>().ThirdWaveStarted;
        if (ThirdWave)
        {
            Boss = GameObject.Find("Boss(Clone)").transform.Find("BossEnemy").gameObject;
        }       

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!stop)
        {
            if (IsEcape)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, EscapePoint.transform.position, Time.deltaTime);
            }
            if (gameObject.transform.position == EscapePoint.transform.position)
            {
                if (secondpath)
                {
                    if (ThirdWave)
                    {
                        Boss.GetComponent<BossFight>().DestrCount--;
                    }
                    else
                    {
                        GameObject.Find("Controller").GetComponent<StarMenu>().DestrCount--;
                    }                    
                    Destroy(gameObject.transform.root.gameObject);
                }
                secondpath = true;
                EscapePoint = DeletePoint;
            }
        }

    }

    public void StartEcape()
    {
        IsEcape = true;
        gameObject.GetComponent<AfterInteract>().IsEscaping = true;
    }

}
