using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class DeathScreen : MonoBehaviour {

    PostProcessingBehaviour behaviour;
    PostProcessingProfile profile;
    public bool StartDeath;
    float time;
    public GameObject Hands;
    public GameObject DEathText;

    // Use this for initialization
    void Start ()
    {
        time = 0;
        StartDeath = false;
        behaviour = gameObject.GetComponent<PostProcessingBehaviour>();
        profile = behaviour.profile;
        VignetteModel.Settings set = profile.vignette.settings;
        set.intensity = 0;
        profile.vignette.settings = set;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (StartDeath)
        {
            time += Time.deltaTime;
            if (StartDeath && time < 0.99f)
            {
                VignetteModel.Settings set = profile.vignette.settings;
                set.intensity = time;
                profile.vignette.settings = set;
            }
            if (time > 3 && time < 3.99 && StartDeath)
            {
                time += Time.deltaTime;
                VignetteModel.Settings set = profile.vignette.settings;
                set.intensity = 4f - time;
                profile.vignette.settings = set;
                
            }
            if (time > 4)
            {
                GameObject.Find("Controller").SendMessage("EndGame");
                //Hands.SetActive(true);
                StartDeath = false;
                time = 0;
            }

        }
    }

    public void ResetDeathScreen()
    {
        VignetteModel.Settings set = profile.vignette.settings;
        set.intensity = 0;
        profile.vignette.settings = set;
    }

     public void StartDeathProc()
    {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(enemy);
        }
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Boss"))
        {
            Destroy(enemy.transform.root.gameObject);
        }
        GameObject.Find("Canvas").SendMessage("DeathAttack", DEathText);
        //Hands.SetActive(false);
        StartDeath = true;
        //Time.timeScale = 0;
    }
}
