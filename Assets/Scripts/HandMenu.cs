using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMenu : MonoBehaviour {

    bool IsGamePoused = true;
    public GameObject Pouse;
    float time = 1;
    bool IsPouse = false;
    bool IsReset = false;
    bool IsGameGo = false;
    GameObject Mosq;
    public GameObject LeftHand;
    //public GameObject HandUI;
    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (LeftHand.activeInHierarchy)
        {
            //HandUI.SetActive(true);
        }
        else
        {
            //HandUI.SetActive(false);
        }
		if (IsPouse)
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                IsPouse = false;
                PouseProcess();                
            }
        }
        if (IsReset)
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                IsReset = false;
                ResetGamevoid();                
            }
        }
    }


    void PouseProcess()
    {
        if (IsGamePoused)
        {
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                if (enemy.activeInHierarchy)
                {
                    if (enemy.GetComponent<MosqMoving>() != null)
                    {
                        enemy.SendMessage("CallStopMoving");
                    }
                    enemy.SendMessage("CallStopClap");
                }
                enemy.transform.Find("MovingSphere").SendMessage("StopInteract");
                enemy.transform.Find("MovingSphere").tag = "Hurted";
                enemy.transform.Find("MovingSphere").GetComponent<Escape>().stop = true;
                if(enemy.transform.Find("MovingSphere/InteractionSphere/Mosquito_melee") != null)
                {
                    enemy.transform.Find("MovingSphere/InteractionSphere/Mosquito_melee").SendMessage("StopAn");
                }
                if (enemy.transform.Find("MovingSphere/InteractionSphere/Mosquito_range") != null)
                {
                    enemy.transform.Find("MovingSphere/InteractionSphere/Mosquito_range").SendMessage("StopAn");
                }

                //enemy.transform.Find("Mosquito_last_version").SendMessage("StopAn");
            }
            gameObject.SendMessage("StopSpawn");
            Instantiate(Pouse, GameObject.Find("Canvas").transform);

            IsGamePoused = false;
        }
        else
        {
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                if (enemy.activeInHierarchy)
                {
                    if (enemy.GetComponent<MosqMoving>() != null)
                    {
                        enemy.SendMessage("CallResumeMoving");
                    }
                    enemy.SendMessage("CallResumeClap");
                    if (enemy.transform.Find("MovingSphere/InteractionSphere/Mosquito_melee") != null)
                    {
                        enemy.transform.Find("MovingSphere/InteractionSphere/Mosquito_melee").SendMessage("ResumeAn");
                    }
                    if (enemy.transform.Find("MovingSphere/InteractionSphere/Mosquito_range") != null)
                    {
                        enemy.transform.Find("MovingSphere/InteractionSphere/Mosquito_range").SendMessage("ResumeAn");
                    }
                    enemy.transform.Find("MovingSphere").GetComponent<Escape>().stop = false;
                }
            }

            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Hurted"))
            {
                if (enemy.activeInHierarchy)
                {
                    enemy.SendMessage("ResumeInteract");
                    enemy.tag = "enemy";
                }
            }
            gameObject.SendMessage("ResumeSpawn");
            Destroy(GameObject.Find("Pouse(Clone)"));
            IsGamePoused = true;
        }
    }

    public void PauseGame()
    {
        if (IsGameGo)
        {
            IsPouse = true;
        }           
    }

    public void ResetGame()
    {
        if (IsGameGo)
        {
            IsReset = true;
        }
        print("pressed");
    }

    public void ResetGamevoid()
    {
        gameObject.SendMessage("EndGame");
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(enemy);
        }
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Boss"))
        {
            Destroy(enemy.transform.root.gameObject);
        }
        if (!IsGamePoused)
        {
            PouseProcess();
        }        
        IsGameGo = false;
    }

    public void ResetTime()
    {
        IsPouse = false;
        IsReset = false;
        time = 1;
    }

    public void GameStarted()
    {
        IsGameGo = true;
    }

    public void GameEnded()
    {
        IsGameGo = false;
    }

}
