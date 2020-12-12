using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooted : MonoBehaviour
{
    public GameObject poof;
    bool ThirdWave;
    GameObject Boss;

    void Start()
    {
        ThirdWave = GameObject.Find("Controller").GetComponent<StarMenu>().ThirdWaveStarted;
        if (ThirdWave)
        {
            Boss = GameObject.Find("Boss(Clone)").transform.Find("BossEnemy").gameObject;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "enemy")
        {
            if (ThirdWave)
            {
                GameObject.Find("BossEnemy").GetComponent<BossFight>().DestrCount--;
            }
            else
            {
                GameObject.Find("Controller").GetComponent<StarMenu>().DestrCount--;
            }
            col.gameObject.tag = "Hurted";
            Instantiate(poof, col.transform.position, Quaternion.identity);
            GameObject.Find("Controller").SendMessage("ChangeScore");            
            Destroy(col.transform.root.gameObject);
        }
        if (col.gameObject.tag == "Boss")
        {
            GameObject model = col.transform.Find("Mosquitoes_boss (2)").gameObject;
            if (model.GetComponent<BossAnimation>().IsNotMoving && !col.gameObject.GetComponent<BossFight>().IfEsq)
            {
                model.SendMessage("PlayHit");
            }
            col.gameObject.SendMessage("TakeBossDamage");
        }
    }

}
