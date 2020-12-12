using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtCheck : MonoBehaviour {

    public float time;
    public bool first;
    public bool second;
    bool IsLHand;
    bool IsRHand;



    // Use this for initialization
    void Start () {
		
	}
	
	// Checking If Shoting
	void Update ()
    {
        
		if(first && second)
        {
            gameObject.GetComponent<Shooting>().IsShooting = true;
            if (IsRHand)
            {
                gameObject.GetComponent<Shooting>().IsRightHand = true;

            }
            else
            {
                gameObject.GetComponent<Shooting>().IsRightHand = false;
            }
            if (IsLHand)
            {
                gameObject.GetComponent<Shooting>().IsLeftHand = true;
            }
            else
            {
                gameObject.GetComponent<Shooting>().IsLeftHand = false;
            }
        }
        else
        {
            gameObject.GetComponent<Shooting>().IsLeftHand = false;
            gameObject.GetComponent<Shooting>().IsRightHand = false;
            gameObject.GetComponent<Shooting>().IsShooting = false;
            gameObject.GetComponent<Shooting>().time = 0;
        }
	}

    //Start Shoting Position
    public void OnDis()
    {
        first = false;
    }
    public void OnEn()
    {
        first = true;
    }

    //ForLeftHand Seconod Check

    public void LOnEnSecond()
    {
        IsLHand = true;
        second = true;
    }
    public void LOnDisSecond()
    {
        second = false;
        IsLHand = false;
    }

    //ForRightHand Seconod Check
    public void ROnEnSecond()
    {
        IsRHand = true;
        second = true;
    }
    public void ROnDisSecond()
    {
        second = false;
        IsRHand = false;
    }
}
