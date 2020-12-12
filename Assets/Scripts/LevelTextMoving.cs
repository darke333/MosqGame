
using UnityEngine;
using TMPro;

public class LevelTextMoving : MonoBehaviour {


    Vector3 temp;
    public GameObject Text;
    public GameObject Text1;
    public GameObject Text2;
    public GameObject Text3;
    public GameObject Win;
    public GameObject Congr;
    public GameObject UserName;
    bool IsGameStarted;
    public GameObject controller;
    public bool IsGameFinished;
    float speed = 8;
    float time;
    Vector3 StartVector;
    bool EnterPress;
    int Score;

	void Start ()
    {
        IsGameStarted = true;
        IsGameFinished = false;
        time = 0;
        //Instantiate(Text1, gameObject.transform);
        Text = Text1;
        //Image.SetActive(false);
        //IsGameStarted = false;
        //StartVector = Text.transform.localScale;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //VRInput();
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            EnterPress = true;
        }
        WinText();
        if (IsGameStarted)
        {
            if (time == 0)
            {
                if (Text.transform.localScale.x <= 5)
                {
                    temp = Text.transform.localScale;
                    temp.x += Time.deltaTime * speed;
                    temp.y += Time.deltaTime * speed;
                    temp.z += Time.deltaTime * speed;
                    Text.transform.localScale = temp;
                }
                else
                {
                    time += Time.deltaTime;
                }
            }
            else
            {
                time += Time.deltaTime;
                if (time > 2)
                {
                    IsGameStarted = false;
                    time = 0;
                    Text.transform.localScale = StartVector;
                    //Instantiate(Text2, gameObject.transform);
                    if (Text == Text2)
                    {
                        Text = Text3;
                    }
                    if (Text == Text1)
                    {
                        Text = Text2;
                    }

                }
            }
        }

    }

    void WinText()
    {
        if (IsGameFinished)
        {
            if (time == 0)
            {
                if (Text.transform.localScale.x <= 5)
                {
                    temp = Text.transform.localScale;
                    temp.x += Time.deltaTime * speed;
                    temp.y += Time.deltaTime * speed;
                    temp.z += Time.deltaTime * speed;
                    Text.transform.localScale = temp;
                }
                else
                {
                    time += Time.deltaTime;
                }
            }
            else
            {
                time += Time.deltaTime;
                if (time > 2)
                {
                    if(Text != UserName)
                    {
                        Text.transform.localScale = StartVector;
                    }
                    
                    if (Text == Congr)
                    {
                        IsGameFinished = false;
                        GameObject.Find("Controller").SendMessage("ResetGamevoid");
                        //Text = UserName;
                    }
                    if (Text == Win)
                    {
                        Text = Congr;
                    }
                    time = 0;
                }
                if (Text == UserName)
                {

                    VRInput();
                    if (EnterPress == true)
                    {
                        //string name = Text.GetComponent<TMP_InputField>().text;
                        
                        IsGameFinished = false;
                        GameObject.Find("Controller").SendMessage("ResetGamevoid");
                    }
                }
            }
        }
    }

    void VRInput()
    {
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(vKey))
            {
                if(vKey == KeyCode.Delete)
                {
                    name = "";
                    Text.GetComponent<TMP_InputField>().text = name;
                }
                if (check(vKey))
                {
                    print(vKey.ToString());
                    string name = Text.GetComponent<TMP_InputField>().text;
                    name += vKey.ToString();
                    Text.GetComponent<TMP_InputField>().text = name;
                }

            }

        }
    }

    bool check(KeyCode key)
    {
        if (key.ToString() == "Q" ||
            key.ToString() == "W" ||
            key.ToString() == "E" ||
            key.ToString() == "R" ||
            key.ToString() == "T" ||
            key.ToString() == "Y" ||
            key.ToString() == "U" ||
            key.ToString() == "I" ||
            key.ToString() == "O" ||
            key.ToString() == "P" ||
            key.ToString() == "A" ||
            key.ToString() == "S" ||
            key.ToString() == "D" ||
            key.ToString() == "F" ||
            key.ToString() == "G" ||
            key.ToString() == "H" ||
            key.ToString() == "J" ||
            key.ToString() == "K" ||
            key.ToString() == "L" ||
            key.ToString() == "Z" ||
            key.ToString() == "X" ||
            key.ToString() == "C" ||
            key.ToString() == "V" ||
            key.ToString() == "B" ||
            key.ToString() == "N" ||
            key.ToString() == "M"

            )
        {
            return (true);
        }
        else
        {
            return (false);
        }
    }

    public void DeathAttack(GameObject Text1)
    {
        Text = Text1;
        IsGameStarted = true;
    }

    public void StartWave()
    {
        IsGameStarted = true;
    }

    public void FinishWave()
    {
        IsGameStarted = false;
        IsGameFinished = true;
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(enemy);
        }
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Boss"))
        {
            Destroy(enemy.transform.root.gameObject);
        }
        Text = Win;
        EnterPress = false;
        Score = controller.GetComponent<KillScore>().Score;
        string ScoreText = "Ваш счет: " + Score;
        Congr.GetComponent<TextMeshProUGUI>().text = ScoreText;
    }

    public void RestartWaves()
    {
        Text.transform.localScale = StartVector;
        Start();
    }
}
