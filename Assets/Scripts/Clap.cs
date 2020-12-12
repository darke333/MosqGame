using Leap;
using UnityEngine;
using Leap.Unity;

public class Clap : MonoBehaviour {

    public Vector3 position;
    public float place;
    public bool check;
    public float Deffetence;
    public Vector RightV;
    public Vector LeftV;
    public GameObject bullet;


    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        check = false;
        position = Vector3.zero;
        //transform.Find("Hand").GetComponent<Transform>();
        GameObject LeftHand = GameObject.Find("LoPoly_Rigged_Hand_Left");
        GameObject RightHand = GameObject.Find("LoPoly_Rigged_Hand_Right");
        //GameObject ClapSphere = GameObject.Find("ClapPlace");
        GameObject Enemy = GameObject.Find("Enemy");        
        if (LeftHand != null && RightHand != null)
        {
            Vector LeftPos = Hands.Left.PalmPosition;
            Vector RightPos = Hands.Right.PalmPosition;
            RightV = Hands.Right.PalmVelocity;
            //print(Hands.Right.Fingers[1].Direction);
            LeftV = Hands.Left.PalmVelocity;
            //LeftPos = GameObject.Find("LoPoly_Rigged_Hand_Left").GetComponent<Position>().lefthandCenter;            
            //RightPos = GameObject.Find("LoPoly_Rigged_Hand_Right").GetComponent<Position>().rightthandCenter;
            Deffetence = Mathf.Abs(LeftPos.x - RightPos.x);
            if (Mathf.Abs(LeftPos.x - RightPos.x) < 0.3 && RightV.x < -0.6f && LeftV.x > 0.6f)
            {
                position = new Vector3(LeftPos.x, LeftPos.y, LeftPos.z);                
            }
        }       
                
    }
}
