using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour {

    float playerSpeed;
    public GameObject model;
    public bool IfMoveUp;
    public bool IfAttack;
    public bool IfEsq;
    public Transform ReturnTo;
    GameObject Player;
    GameObject BiteArea;
    GameObject AttackPoint;
    public ParticleSystem Smoke;
    public GameObject enemy;
    public GameObject secondenemy;
    public List<Vector3> positions = new List<Vector3>();
    public int DestrCount;
    bool IsSpawned;


    // Use this for initialization
    void Start ()
    {
        BiteArea = GameObject.Find("BiteAreaBorder");
        Player = GameObject.Find("Player");
        AttackPoint = GameObject.Find("AttackPoint");
        float x = ReturnTo.position.x;
        float y = ReturnTo.position.y;
        float z = ReturnTo.position.z;
        positions.Add(new Vector3(x + 2, y, z));
        positions.Add(new Vector3(x - 2, y, z));
        positions.Add(new Vector3(x + 3, y, z - 1));
        positions.Add(new Vector3(x - 3, y, z - 1));
        IsSpawned = false;
        DestrCount = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (IfMoveUp)
        {
            transform.position += Vector3.up * Time.deltaTime;
        }
        if (IfAttack)
        {
            if (gameObject.transform.position != AttackPoint.transform.position)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, AttackPoint.transform.position, Time.deltaTime * 2);
            }
            else
            {
                model.SendMessage("PlayAtack");
                IfAttack = false;
            }
        }
        if (IfEsq)
        {
            if (gameObject.transform.position != ReturnTo.position)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, ReturnTo.position, Time.deltaTime);
            }
            else
            {
                IfEsq = false;
                SpawnEnemy();
            }
        }
        if (IsSpawned)
        {
            if (DestrCount == 0)
            {
                model.SendMessage("PlayUp");
                IsSpawned = false;
            }
        }
    }

    void SpawnEnemy()
    {
        IsSpawned = true;
        DestrCount = 4;
        for(int i = 0; i < 4; i++)
        {
            if (i < 2)
            {
                SpawnSecondEnemy(positions[i]);
            }
            else
            {
                SpawnFirstEnemy(positions[i]);
            }

        }
    }

    void SpawnSecondEnemy(Vector3 position)
    {
        Instantiate(secondenemy, position, Quaternion.identity);
        Instantiate(Smoke, position, Quaternion.identity);
    }

    void SpawnFirstEnemy(Vector3 position)
    {
        Instantiate(enemy, position, Quaternion.identity);
        Instantiate(Smoke, position, Quaternion.identity);
    }

}
