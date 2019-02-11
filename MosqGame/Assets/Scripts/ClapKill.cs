using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClapKill : MonoBehaviour {

    public GameObject HandModels;
    public Vector3 position;
    public GameObject ClapSphere;
    public bool Stop = false;
    public ParticleSystem Smoke;
    bool ThirdWave;
    public GameObject Boss;

    // Update is called once per frame
    void Update ()
    {   if (!Stop)
        {
            Vector3 position = HandModels.GetComponent<Clap>().position;
            if (position != Vector3.zero)
            {
                if (ClapSphere.GetComponent<Collider>().bounds.Contains(position))
                {
                    Instantiate(Smoke, position, Quaternion.identity);
                    GameObject.Find("Controller").SendMessage("ChangeScore");
                    if (ThirdWave)
                    {
                        Boss.GetComponent<BossFight>().DestrCount--;
                    }
                    else
                    {
                        GameObject.Find("Controller").GetComponent<StarMenu>().DestrCount--;
                    }
                    Destroy(this.gameObject);                    
                }
            }
        }            
    }

    void Start()
    {

        ThirdWave = GameObject.Find("Controller").GetComponent<StarMenu>().ThirdWaveStarted;
        HandModels = GameObject.Find("HandModels");
        if (ThirdWave)
        {
            Boss = GameObject.Find("Boss(Clone)").transform.Find("BossEnemy").gameObject;
        }
    }

    public void CallStopClap()
    {
        Stop = true;
    }

    public void CallResumeClap()
    {
        Stop = false;
    }
}
