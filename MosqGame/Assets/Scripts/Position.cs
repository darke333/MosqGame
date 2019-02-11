using Leap;
using Leap.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour {

    HandModel hand_model;
    Hand leap_hand;
    public Vector lefthandCenter;
    public Vector rightthandCenter;
    public Vector3 Center;
    public bool IsR;
    public bool IsL;

    // Use this for initialization
    void Start ()
    {
        hand_model = gameObject.GetComponent<HandModel>();
        
        
        leap_hand = hand_model.GetLeapHand();
        

    }
	
	// Update is called once per frame
	void Update ()
    {
        Center = hand_model.GetPalmNormal();
        //handCenter = leap_hand.PalmPosition;
        IsR = leap_hand.IsRight;
        IsL = leap_hand.IsLeft;
        lefthandCenter= Hands.Left.PalmPosition;
        rightthandCenter = Hands.Right.PalmPosition;
        if (leap_hand.IsLeft)
        {
            //lefthandCenter = leap_hand.PalmPosition;
        }
        if (leap_hand.IsRight)
        {
            //rightthandCenter = leap_hand.PalmPosition;
        }
    }
}
