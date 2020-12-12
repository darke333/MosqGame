using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public bool IsDamaged;
    

    public float damage;
    
    //public float BiteTime;
    //public float TimeLeft;
    


    void OnTriggerStay(Collider enemy)
    {
        if (enemy.tag == "enemy")
        {           
            if (enemy.gameObject.transform.Find("InteractionSphere/Mosquito_melee") != null)
            {
                enemy.gameObject.transform.Find("InteractionSphere/Mosquito_melee").gameObject.SendMessage("StartAnimation");
            }
            else
            {
                enemy.gameObject.transform.Find("InteractionSphere/Mosquito_range").gameObject.SendMessage("StartAnimation");
            }
            
            
        }
    }
}
