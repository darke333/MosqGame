using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMosqMoving : MonoBehaviour {

    float timeCounter = 0;
    float Distance;
    float YDistance;
    float CountPi;
    float RadiusCount;
    float Xradius;
    float Yradius;
    float Zradius;
    bool flag;
    public float Xdifference;
    public float Zdifference;
    public float Ydifference;
    public GameObject BiteAreaBorder;

    // Use this for initialization
    void Start ()
    {
        Distance = 5;
        CountPi = 0;
        Xradius = Random.Range(0.5f, 0.8f);
        Yradius = Random.Range(0.2f, 0.5f);
        Zradius = Random.Range(0.5f , 0.8f);
        flag = true;
        RadiusCount = Zradius;
        Xdifference = 0;
        Zdifference = 0;
        Ydifference = 0;
        YDistance = 1f;
        BiteAreaBorder = GameObject.Find("BiteAreaBorder");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!BiteAreaBorder.GetComponent<Collider>().bounds.Contains(gameObject.transform.position))
        {
            Motion();
        }
        else
        {
            Destroy(this);
        }

    }

    void Motion()
    {
        if (transform.position.z <= Distance - RadiusCount + 0.0001)
        {
            CountPi++;
            Zdifference = Distance - transform.position.z - RadiusCount;
            RadiusCount += 2 * Zradius;
            Xdifference += transform.position.x;
            Ydifference += YDistance - transform.position.y;
            if (flag)
            {
                flag = false;
            }
            else
            {
                flag = true;
            }
            Xradius = Random.Range(0.5f, 0.8f);
            Yradius = Random.Range(0.2f, 0.5f);
            Zradius = Random.Range(0.5f, 0.8f);

        }
        if (flag)
        {
            timeCounter += Time.deltaTime;
            float x = Mathf.Cos((timeCounter)) * Xradius + Xdifference;
            float y = Mathf.Cos((timeCounter)) * Yradius + Ydifference + YDistance;
            float z = Mathf.Sin(timeCounter) * Zradius + Distance - (RadiusCount - Zradius - Zdifference);
            transform.position = new Vector3(x, y, z);

        }
        else
        {
            timeCounter += Time.deltaTime;
            float x = Mathf.Cos((timeCounter)) * Xradius + Xdifference;
            float y = Mathf.Cos((timeCounter)) * Yradius + Ydifference + YDistance;
            float z = -Mathf.Sin((timeCounter)) * Zradius + Distance - (RadiusCount - Zdifference - Zradius);
            transform.position = new Vector3(x, y, z);
        }
    }
}
