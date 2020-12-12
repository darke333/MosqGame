using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour {

    public Image CurrentHealth;
    public GameObject poof;
    public float damage;
    public float hitpoint = 100;
    private float maxHotpoint = 100;
    public GameObject canvas;
    public void Start()
    {
        canvas = GameObject.Find("Canvas");
        UpdetaHealth();
    }

    private void UpdetaHealth()
    {
        float ratio = hitpoint / maxHotpoint;
        CurrentHealth.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    public void TakeBossDamage()
    {
        hitpoint -= damage;
        if (hitpoint == 0)
        {
            Instantiate(poof, gameObject.transform.position, Quaternion.identity);
            GameObject.Find("Controller").SendMessage("BossKillScore");
            canvas.SendMessage("FinishWave");
            hitpoint = 100;
        }
        UpdetaHealth();
    }

}
