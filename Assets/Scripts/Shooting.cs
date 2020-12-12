using UnityEngine;
using Leap;
using System.Collections;
using Leap.Unity;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    //Drag in the Bullet Emitter from the Component Inspector.
    public GameObject RBullet_Emitter;
    public GameObject LBullet_Emitter;

    //Drag in the Bullet Prefab from the Component Inspector.
    public GameObject bullet;

    //Enter the Speed of the Bullet from the Component Inspector.
    public float Bullet_Forward_Force;

    public float time;
    int bulletsLeft;
    float reloadTime;
    float reloadTimeCount;
    public Text Number;
    public UnityEngine.UI.Image Reloading;
    public GameObject RightFinger;
    public GameObject LeftFinger;
    public bool IsGameStarted;
    public bool IsShooting;
    public bool IsLeftHand;
    public bool IsRightHand;

    // Use this for initialization
    void Start()
    {
        IsGameStarted = false;
        time = 0;
        bulletsLeft = 500000;
        reloadTime = 10;
        reloadTimeCount = 0;
        IsLeftHand = false;
        IsRightHand = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGameStarted)
        {
            ShootingProc();
        }
    }

    void ShootingProc()
    {
        if (time <= 0 && bulletsLeft != 0 && IsShooting)
        {
            Shoot();
            time = 1;
            bulletsLeft--;
            Number.text = "Пули: " + bulletsLeft.ToString();
            if (bulletsLeft == 0)
            {
                Number.text = "Перезарядка";
                reloadTimeCount = 0;
            }
        }
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            time = 0;
        }
        if (bulletsLeft == 0)
        {
            float ratio = reloadTimeCount / reloadTime;
            Reloading.rectTransform.localScale = new Vector3(ratio, 1, 1);            
            if (reloadTimeCount >= 10)
            {
                bulletsLeft = 5;
                Number.text = "Пули: " + bulletsLeft.ToString();
                reloadTimeCount = 0;
            }
            reloadTimeCount += Time.deltaTime;
        }
    }

    public void Shoot()
    {
        if (IsRightHand && bulletsLeft != 0)
        {
            GameObject Temporary_Bullet_Handler;
            Temporary_Bullet_Handler = Instantiate(bullet, RBullet_Emitter.transform.position, RBullet_Emitter.transform.rotation) as GameObject;

            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

            Temporary_RigidBody.AddForce(RightFinger.transform.right * Bullet_Forward_Force);

            Destroy(Temporary_Bullet_Handler, 7.0f);
        }

        if (IsLeftHand && bulletsLeft != 0)
        {
            GameObject Temporary_Bullet_Handler;
            Temporary_Bullet_Handler = Instantiate(bullet, LBullet_Emitter.transform.position, LBullet_Emitter.transform.rotation) as GameObject;

            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

            Temporary_RigidBody.AddForce(-LeftFinger.transform.right * Bullet_Forward_Force);

            Destroy(Temporary_Bullet_Handler, 7.0f);

        }
    }

    public void RestartShoting()
    {
        Number.text = "Пули: " + bulletsLeft.ToString();
        Reloading.rectTransform.localScale = new Vector3(1, 1, 1);
        time = 0;
    }
}

