using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAtack : MonoBehaviour {

    public Animator anim;
    public GameObject Moving;
    public GameObject BiteArea;
    bool stop;
    bool PlayAnim;
    bool Playing;
    GameObject player;
    float TimeCount;
    bool hurted;


    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
        BiteArea = GameObject.Find("BiteArea");
        stop = false;
        Playing = false;
        TimeCount = 4.6f;        
        Moving = gameObject.transform.root.Find("MovingSphere").gameObject;
}
	
	// Update is called once per frame
	void Update ()
    {
        if(Moving.tag == "Hurted")
        {
            hurted = true;
        }
        else
        {
            hurted = false;
        }
        if (PlayAnim && !stop)
        {
            anim.Play("attack");
            PlayAnim = false;
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("attack") && TimeCount > 0 )
        {
            TimeCount -= Time.deltaTime;
        }
        if (TimeCount <= 0)
        {
            Moving.tag = "Untagged";
            TimeCount = 1000000;
            var player = GameObject.Find("Player");
            player.SendMessage("TakeDamage", Moving);
            gameObject.transform.Find("Комарик").SendMessage("ChangeColor");
            anim.Play("HardFly");
        }
    }

    public void PlayOKl()
    {
        anim.Play("Oh");
    }

    public void StopAn()
    {
        stop = true;
        anim.enabled = false;
    }

    public void ResumeAn()
    {
        stop = false;
        anim.enabled = true;
    }

    public void StartAnimation()
    {
        PlayAnim = true;
    }

    public void EndAnimation()
    {
        PlayAnim = false;
    }

}
