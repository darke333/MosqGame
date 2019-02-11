using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image CurrentHealth;
    public Text Number;
    public float damage;
    public float hitpoint = 100;
    private float maxHotpoint = 100;
    public GameObject Controller;
    public void Start()
    {
        UpdetaHealth();
    }
    
     public void UpdetaHealth()
    {
        float ratio = hitpoint / maxHotpoint;
        CurrentHealth.rectTransform.localScale = new Vector3(ratio, 1, 1);
        Number.text = (ratio * 100).ToString("0") + '%';
    }

     public void TakeBossDamage()
    {
        hitpoint -= 20;
        if (hitpoint <= 0)
        {
            Controller.GetComponent<StarMenu>().Stop = true;
            GameObject.Find("CenterEyeAnchor").SendMessage("StartDeathProc");
            hitpoint = 100;
        }
        UpdetaHealth();
    }

    private void TakeDamage(GameObject enemy)
    {
        hitpoint -= damage;
        if (hitpoint <= 0)
        {
            Controller.GetComponent<StarMenu>().Stop = true;
            GameObject.Find("CenterEyeAnchor").SendMessage("StartDeathProc");
            hitpoint = 100;
        }
        UpdetaHealth();
        enemy.SendMessage("ChangeTarget");
        enemy.SendMessage("StartEcape");
    }

    public void ResetHealth()
    {
        hitpoint = 100;
        UpdetaHealth();
    }

}
