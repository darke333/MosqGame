using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowDestroyImage : MonoBehaviour {


    Color Color;
    public float Change;
    public bool StartChange;
    float time;

    // Use this for initialization
    void Start ()
    {
        Change = 1;
        time = 2;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (time < 0)
        {
            Change -= Time.deltaTime  / 2;
            Color = GetComponent<Image>().color;
            Color.a = Change;
            GetComponent<Image>().color = Color;
            //print(GetComponent<Image>().color.a);
        }
        else
        {
            time -= Time.deltaTime;
        }
	}

    public void StartChangeColor()
    {
        StartChange = true;
    }


}
