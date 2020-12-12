using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTrigger : MonoBehaviour {

    bool starmov;
    public GameObject Moving;
    GameObject MovEnemy;
    public GameObject Expl;

	// Use this for initialization
	void Start ()
    {
        starmov = false;

	}

    void OnTriggerEnter(Collider enemy)
    {
        if (enemy.tag == "Hurted")
        {
            print("hi");
            enemy.SendMessage("killit");
            MovEnemy = enemy.gameObject;
            starmov = true;
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if (starmov)
        {
            MovEnemy.transform.position = Vector3.MoveTowards(MovEnemy.transform.position, Moving.transform.position, Time.deltaTime * 2);
            if (MovEnemy.transform.position == Moving.transform.position)
            {
                GameObject.Find("Controller").GetComponent<KillScore>().Score += 5;
                Instantiate(Expl, MovEnemy.transform.position, MovEnemy.transform.rotation);
                Destroy(MovEnemy.transform.root.gameObject);
                Destroy(gameObject.transform.root.gameObject);
            }
        }
        
    }
}
