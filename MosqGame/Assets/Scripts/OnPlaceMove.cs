using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlaceMove : MonoBehaviour {

    public bool IsMoving = false;
	GameObject BiteArea;
    Vector3 StartPosition;
    Vector3 MoveTo;
    Vector3 Player;
    bool xORz;
    public float speed;



	// Use this for initialization
	void Start ()
    {
        Player = GameObject.Find("Player").GetComponent<Transform>().position;
        StartPosition = gameObject.GetComponent<Transform>().position;
        if (Mathf.Abs(Player.x - StartPosition.x) < Mathf.Abs(Player.z - StartPosition.z))
        {
            xORz = true;
        }
        else
        {
            xORz = false;
        }
        CreateTarget();
		BiteArea = GameObject.Find ("BiteArea");
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (IsMoving)
        {
            if (BiteArea.GetComponent<Collider>().bounds.Contains(gameObject.GetComponent<Transform>().position))
            {
                if (gameObject.GetComponent<Transform>().position != MoveTo)
                {
                    gameObject.GetComponent<Transform>().position = Vector3.MoveTowards(gameObject.GetComponent<Transform>().position, MoveTo, speed * Time.deltaTime);
                }
                else
                {
                    CreateTarget();
                }
            }
            else
            {
                CreateTarget();
            }
        }
	}

    public void BeginMoving()
    {
        
        //IsMoving = true;
    }

    public void StopMeving()
    {

    }

    void CreateTarget()
    {
        if (xORz)
        {
            float x = StartPosition.x;
            float y = Random.Range(StartPosition.y - 0.1f, StartPosition.y + 0.1f);
            float z = Random.Range(StartPosition.z - 0.1f, StartPosition.z + 0.1f);
            MoveTo = new Vector3(x, y, z);
        }
        else
        {
            float x = Random.Range(StartPosition.x - 0.1f, StartPosition.x + 0.1f);
            float y = Random.Range(StartPosition.y - 0.1f, StartPosition.y + 0.1f);
            float z = StartPosition.z;
            MoveTo = new Vector3(x, y, z);
        }
    }
}
