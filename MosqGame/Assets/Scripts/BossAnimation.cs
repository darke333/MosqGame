using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimation : MonoBehaviour {

    GameObject Player;
    Animator anim;
    bool StartEsqape;
    public GameObject BossObj;
    public bool IsNotMoving;

    // Use this for initialization
    void Start ()
    {
        Player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
        StartEsqape = false;
        //BossObj = gameObject.transform.root.Find("BossEnemy").gameObject;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Fly"))
        {
            IsNotMoving = true;
        }
        else
        {
            IsNotMoving = false;
        }
    }

    public void PlayAtack()
    {
        anim.Play("attack");
    }

    public void PlayHit()
    {
        anim.Play("Hit_Reaction");
    }

    public void PlayUp()
    {
        anim.Play("Up_To_Sky");
        BossObj.GetComponent<BossFight>().IfMoveUp = true;
    }

    public void StartDown()
    {
        BossObj.GetComponent<BossFight>().IfMoveUp = false;
        BossObj.GetComponent<BossFight>().IfAttack = true;
    }

    public void HitAndEsq()
    {
        BossObj.GetComponent<BossFight>().IfEsq = true;
        Player.SendMessage("TakeBossDamage");
    }

    




}
