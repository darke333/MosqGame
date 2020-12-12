using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;

public class AfterInteract : MonoBehaviour {

    float time;
    public int speed;
    public GameObject BiteArea;
    public GameObject Target;
    public GameObject Pers;
    bool Stop = true;
    bool Pouse = false;
    public bool IsEscaping;
    void Start()
    {
        BiteArea = GameObject.Find("BiteAreaBorder");
        Target = GameObject.Find("Player");
        IsEscaping = false;
    }

    void Update()
    {
        if (!Stop && !Pouse)
        {
            ContinueMoving();
        }        
    }

    public void Change()
    {
        Stop = true;
        this.gameObject.tag = "Hurted";
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        if (gameObject.GetComponent<Bezier>() != null)
        {
            gameObject.GetComponent<Bezier>().Interacting = true;
        }        
    }

    public void CallAfterTime()
    {
        Pers.SendMessage("PlayOKl");
        Invoke("ChangeBool", 0.7f);
        //gameObject.GetComponent<Rigidbody>().useGravity = true;
    }

    public void ChangeBool()
    {
        //gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        Stop = false;
        this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        this.gameObject.tag = "enemy";
    }

    public void ContinueMoving()
    {        
        if (!BiteArea.GetComponent<Collider>().bounds.Contains(this.gameObject.transform.position) && !IsEscaping)
        {
            Vector3 position = Target.GetComponent<Transform>().position; ;
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, position, speed * Time.deltaTime);
        }
        else
        {
            Stop = true;
        }
        
    }

    public void StopInteract()
    {
        InteractionBehaviour Inter = gameObject.GetComponent<InteractionBehaviour>();
        Inter.ignoreContact = true;
        Inter.ignoreGrasping = true;
        Pouse = true;
    }

    public void ResumeInteract()
    {
        InteractionBehaviour Inter = gameObject.GetComponent<InteractionBehaviour>();
        Inter.ignoreContact = false;
        Inter.ignoreGrasping = false;
        Pouse = false;
    }

    public void killit()
    {
        Destroy(this);
    }



}
