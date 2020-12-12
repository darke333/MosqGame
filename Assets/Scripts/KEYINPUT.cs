using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KEYINPUT : MonoBehaviour {

    public GameObject Text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(vKey))
            {
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

    void VRInput()
    {
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(vKey))
            {
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
        if(key.ToString() == "Q" ||
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

}
