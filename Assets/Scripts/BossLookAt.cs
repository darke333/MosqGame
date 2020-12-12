using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLookAt : MonoBehaviour {


    public bool If;
    Transform Target;
	// Use this for initialization
	void Start ()
    {
        Target = GameObject.Find("Player").transform;
        If = true;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (If)
        {
            Quaternion neededRotation = Quaternion.LookRotation(Target.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, neededRotation, Time.deltaTime);
        }
        else
        {
            transform.LookAt(Target);
        }

    }
}
