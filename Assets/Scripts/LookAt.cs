using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

    public Transform Target;
    bool IsEsc;

    void Start()
    {
        Target = GameObject.Find("Player").GetComponent<Transform>();
        IsEsc = false;
    }
	// Update is called once per frame
	void Update ()
    {

        if (IsEsc)
        {
            Quaternion neededRotation = Quaternion.LookRotation(Target.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, neededRotation, Time.deltaTime);
        }
        else
        {
            Target = GameObject.Find("Player").transform;
            transform.LookAt(Target);
        }

    }

    public void ChangeTarget()
    {
        IsEsc = true;
        Target = GameObject.Find("CaveEscape").GetComponent<Transform>();        
    }
}
