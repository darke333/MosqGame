using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour {

    public Vector3 pos;
    public Vector3 CaveExit;
    public Transform[] controlPoints;
    public Vector3[] positions = new Vector3[50];
    GameObject BiteArea;
    float count;
    int j;
    

    // Use this for initialization
    void Start ()
    {
        pos = gameObject.transform.position;
        //CaveExit = GameObject.Find("BossEsq").transform.position;
        count = positions.Length;
        j = 0;
        Vector3 Tplayer = GameObject.Find("Player").transform.position;
        Vector3 Position = GameObject.Find("CenterEyeAnchor").transform.position;
        controlPoints[2].position = new Vector3(Tplayer.x, Tplayer.y, Tplayer.z + 4);
        MakePos();
    }
	
	// Update is called once per frame
	void Update ()
    {
        MovingEnemy();


    }

    Vector3 CalculateQBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        return Mathf.Pow(1 - t, 2) * p0 + 2 * (1 - t) * t * p1 + t * t * p2;
    } 

    void MakePos()
    {
        for (int i = 1; i < count + 1; i++)
        {
            float t = i / (float)count;
            positions[i - 1] = CalculateQBezierPoint(t, controlPoints[0].position, controlPoints[1].position, controlPoints[2].position);
        }
    }

        private void MovingEnemy()
    {
        if (gameObject.transform.position != positions[j])
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, positions[j], Time.deltaTime);
        }
        else
        {
            if (j != 49)
            {
                j++;
            }
            else
            {
                gameObject.transform.Find("Mosquitoes_boss (2)").SendMessage("PlayUp");
                gameObject.GetComponent<BossLookAt>().If = false;
                GetComponent<BossFight>().enabled = true;
                Destroy(this);
            }

        }

    }

}
