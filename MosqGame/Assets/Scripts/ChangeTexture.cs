using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTexture : MonoBehaviour {

	public Texture Blood;

	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeColor()
    {
        if (gameObject.name == "Шприц")
        {
            gameObject.GetComponent<SkinnedMeshRenderer>().materials[1].mainTexture = Blood;
        }
        else
        {
            gameObject.GetComponent<SkinnedMeshRenderer>().materials[10].mainTexture = Blood;
        }        
    }
}
