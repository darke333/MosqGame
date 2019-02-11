using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;
using System.IO;

public class StarMenu : MonoBehaviour {

    public int FirstEnemyCount;
    public GameObject enemy;
    public bool Stop = false;
    public float Timer;
    float time;
    int enemycount;
    public GameObject LaunchMenu;
    public GameObject DiffMenu;
    public GameObject secondenemy;
    public ParticleSystem Smoke;
    public GameObject ui;
    public int DestrCount;
    public GameObject SceneCamera;
    public GameObject cutSceneMelee;
    public GameObject cutSceneRange;
    public GameObject Player;
    public GameObject player;
    public GameObject Boss;
    public GameObject PCamera;
    public Transform BossStartPos;
    bool FirstMelee;
    bool FirstRange;
    bool SecondWaveFinish;
    int counthelp;
    int SecondEnemyCount;
    bool IsSpawn = false;
    public bool ThirdWaveStarted;

    // Use this for initialization
    void Start ()
    {
        StartGame();
        PCamera.GetComponent<DeathScreen>().ResetDeathScreen();
        ui.SetActive(false);
        FirstEnemyCount = 1;
        SecondEnemyCount = 0;
        Timer = 4;
        counthelp = 0;
        DestrCount = FirstEnemyCount;
        FirstMelee = false;
        FirstRange = false;
        SecondWaveFinish = false;
        ThirdWaveStarted = false;
        Stop = false;
        //gameObject.SendMessage("CreateNew");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (IsSpawn && !Stop)
        {
            Timer -= Time.deltaTime;
            if (Timer < 0)
            {
                Invoke("Spawn", 0);
                IsSpawn = false;
                Timer = time;
                
            }
        }
        if (DestrCount == 0 && !Stop)
        {
            if (SecondWaveFinish)
            {
                ui.SendMessage("StartWave");
                ThirdWaveStarted = true;
                Instantiate(Boss);
                Stop = true;
            }
            else
            {
                StartSecondWave();
                SecondWaveFinish = true;
            }            
            
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            StartGame();
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            GameObject.Find("LMHeadMountedRig").SendMessage("RegulCamera");
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            gameObject.SendMessage("ResetGamevoid");
        }
    }

    public void Spawn()
    {
        if (SecondEnemyCount == 0)
        {
            SpawnEnemy(MakeMeelePos());
            FirstEnemyCount--;
            if (FirstEnemyCount != 0)
            {
                IsSpawn = true;
            }
        }
        else
        {
            if (counthelp != 0)
            {
                SpawnEnemy(MakeMeelePos());
                FirstEnemyCount--;
                counthelp--;
                if (FirstEnemyCount != 0)
                {
                    IsSpawn = true;
                    //counthelp = 2;
                }
                print(FirstEnemyCount + " melee" );
                print(counthelp+" help");
                //IsSpawn = true;
            }
            else
            {
                SpawnSecondEnemy(MakeRangePos());
                SecondEnemyCount--;
                print(SecondEnemyCount + " range");
                    IsSpawn = true;
                    counthelp = 2;
            }
        }


    }

    Vector3 MakeMeelePos()
    {
        GameObject Player = GameObject.Find("Player");
        float PlayerY = Player.GetComponent<Transform>().position.y;
        float x = Random.Range(-6, 6);
        float z = Mathf.Sqrt(36 - x * x);
        float y = Random.Range(PlayerY, PlayerY + 0.5f);
        return (new Vector3(x, y, z));
    }

    Vector3 MakeRangePos()
    {
        GameObject Player = GameObject.Find("Player");
        float PlayerY = Player.GetComponent<Transform>().position.y;
        float x = Random.Range(-6, 6);
        float z = Mathf.Sqrt(36 - x * x);
        float y = Random.Range(PlayerY, PlayerY + 0.5f);
        return (new Vector3(x, y, z));
    }


    void StartSecondWave()
    {
        ui.SendMessage("StartWave");
        FirstEnemyCount = enemycount * 2;
        print(FirstEnemyCount);
        SecondEnemyCount = enemycount;
        print(SecondEnemyCount);
        DestrCount = FirstEnemyCount + SecondEnemyCount;
        IsSpawn = true;
        counthelp = 0;
    }

    void SpawnEnemy(Vector3 position)
    {
        Instantiate(Smoke, position, Quaternion.identity);
        if (FirstMelee)
        {
            Stop = true;
            Instantiate(enemy, position, Quaternion.identity);
            SceneCamera.GetComponent<CutSceneCamera>().enemes = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                enemy.SetActive(false);
            }
            Player.SetActive(false);
            SceneCamera.SetActive(true);
            cutSceneMelee.SetActive(true);
            FirstMelee = false;
        }
        else
        {
            Instantiate(enemy, position, Quaternion.identity);
        }
    }

    void SpawnSecondEnemy(Vector3 position)
    {
        Instantiate(Smoke, position, Quaternion.identity);
        if (FirstRange)
        {
            Stop = true;
            Instantiate(secondenemy, position, Quaternion.identity);
            SceneCamera.GetComponent<CutSceneCamera>().enemes = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                enemy.SetActive(false);
            }
            Player.SetActive(false);
            SceneCamera.SetActive(true);
            cutSceneRange.SetActive(true);
            FirstRange = false;
        }
        else
        {
            Instantiate(secondenemy, position, Quaternion.identity);
        }
    }

    public void StartGame()
    {
        LaunchMenu.SetActive(false);
        DiffMenu.SetActive(true);
    }

    public void Easy()
    {
        Choise("easy");
    }

    public void Medium()
    {
        Choise("medium");
    }

    public void Hard()
    {
        Choise("hard");
    }

    public void Choise(string choise)
    {
        if(choise == "easy")
        {
            enemycount = 2;
            time = 3;
        }
        else
        {
            if(choise == "medium")
            {
                enemycount = 6;
                time = 2;
            }
            else
            {
                enemycount = 10;
                time = 1;
            }
        }
        Timer = time;
        FirstEnemyCount = enemycount;
        DestrCount = FirstEnemyCount;
        DiffMenu.SetActive(false);
        gameObject.SendMessage("GameStarted");
        LaunchMenu.SetActive(false);
        IsSpawn = true;
        ui.SetActive(true);
        gameObject.GetComponent<Shooting>().IsGameStarted = true;
    }

    public void StopSpawn()
    {
        Stop = true;
    }

    public void ResumeSpawn()
    {
        Stop = false;
    }

    public void EndGame()
    {
        PCamera.GetComponent<DeathScreen>().ResetDeathScreen();
        ui.SendMessage("RestartWaves");
        gameObject.GetComponent<KillScore>().Score = -1;
        Start();
        IsSpawn = false;
        //LaunchMenu.SetActive(true);
        ui.SetActive(false);
        player.GetComponent<HealthBar>().ResetHealth();
        gameObject.SendMessage("ChangeScore");
        gameObject.SendMessage("RestartShoting");


    }
}
