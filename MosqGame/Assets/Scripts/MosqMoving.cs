using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosqMoving : MonoBehaviour
{

    public Transform Moving;
    public Transform position1;
    public Transform position2;
    public Vector3 newPosition;
    public float speed;
    public int WayChoice;
    public int CurrentWayPointNumb;
    public List<Vector3> arr = new List<Vector3>();
    public GameObject BiteArea;
    public bool Stop = false;
    public GameObject MovingSphere;




    // Use this for initialization
    void Start()
    {
        BiteArea = GameObject.Find("BiteAreaBorder");
        MainWay();
        CreateTargets();
        CurrentWayPointNumb = 0;
        newPosition = arr[CurrentWayPointNumb];
        position2 = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(BiteArea != null)
        {
            if (!BiteArea.GetComponent<Collider>().bounds.Contains(Moving.position) && !Stop)
            {

                if (Mathf.Abs(Moving.position.z - arr[CurrentWayPointNumb].z) > 0.01f)
                {
                    Moving.position = Vector3.MoveTowards(Moving.position, arr[CurrentWayPointNumb], speed * Time.deltaTime);
                }
                else
                {
                    if (CurrentWayPointNumb < arr.Count - 1)
                    {
                        CurrentWayPointNumb++;
                        newPosition = arr[CurrentWayPointNumb];
                    }
                }
            }
            else
            {
                if (BiteArea.GetComponent<Collider>().bounds.Contains(Moving.position))
                {
                    //MovingSphere.SendMessage("BeginMoving");
                    Destroy(this);
                }                
            }
        }        
        
    }

    void CreateTargets()
    {
        GameObject floor = GameObject.Find("Terrain");
        //GameObject ForRadius = GameObject.Find("BiteArea");
        //print(ForRadius.GetComponent<SphereCollider>().radius);
        //float radious = BiteArea.GetComponent<SphereCollider>().radius;
        switch (WayChoice)
        {
            case 1:
                for (int i = 1; i < arr.Count + 1; i++)
                {
                    float z;
                    float y;
                    float l = 0;
                    if (i != arr.Count)
                    {
                        z = Random.Range(position1.position.z - 2, position2.position.z + 2);
                        y = Random.Range(position2.position.y - 0.5f, position2.position.y + 0.5f);
                    }
                    else
                    {
                        if (position1.position.z > position2.position.z)
                        {
                            //z = position2.position.z + (Mathf.Abs(radious) / l * Mathf.Abs(arr[arr.Count - 2].z - position2.position.z));

                        }
                        else
                        {
                            //z = position2.position.z - (Mathf.Abs(radious) / l * Mathf.Abs(arr[arr.Count - 2].z - position2.position.z));
                        }
                        z = position2.position.z;
                        y = position2.position.y;
                    }
                    float x;
                    if (position1.position.x > position2.position.x)
                    {
                        if (i == arr.Count)
                        {
                            //l = Mathf.Sqrt(Mathf.Pow((arr[arr.Count - 2].x - position2.position.x), 2) + Mathf.Pow((arr[arr.Count - 2].z - position2.position.z), 2));
                            //x = position2.position.x + (Mathf.Abs(radious) / l * Mathf.Abs(arr[arr.Count - 2].x - position2.position.x));
                            x = position2.position.x;
                                
                        }
                        else
                        {
                            x = position1.position.x - (Mathf.Abs(position1.position.x - position2.position.x) / arr.Count) * i + 1;
                        }
                    }
                    else
                    {
                        if (i == arr.Count)
                        {
                            // l = Mathf.Sqrt(Mathf.Pow((arr[arr.Count - 2].x - position2.position.x), 2) + Mathf.Pow((arr[arr.Count - 2].z - position2.position.z), 2));
                            //x = position2.position.x - (Mathf.Abs(radious) / l * Mathf.Abs(arr[arr.Count - 2].x - position2.position.x));
                            x = position2.position.x;
                        }
                        else
                        {
                            x = position1.position.x + (Mathf.Abs(position1.position.x - position2.position.x) / arr.Count) * i - 1;
                        }
                    }
                    arr[i - 1] = new Vector3(x, y, z);
                }
                break;
            case 2:
                for (int i = 1; i < arr.Count + 1; i++)
                {
                    float x;
                    float z;
                    if (i != arr.Count)
                    {
                        x = Random.Range(position1.position.x - 3, position2.position.x + 4);
                        z = Random.Range(position1.position.z - 3, position2.position.z + 4);
                    }
                    else
                    {
                        x = position2.position.x;
                        z = position2.position.z;
                    }
                    float y;
                    if (position1.position.y > position2.position.y)
                    {
                        y = position1.position.y - (Mathf.Abs(position1.position.y - position2.position.y) / arr.Count) * i + 1;
                    }
                    else
                    {
                        y = position1.position.y + (Mathf.Abs(position1.position.y - position2.position.y) / arr.Count) * i - 1;
                    }
                    arr[i - 1] = new Vector3(x, y, z);
                }
                break;
            case 3:
                for (int i = 1; i < arr.Count + 1; i++)
                {
                    float x;
                    float y;
                    float z;                   
                    float l = 0;
                    if (position1.position.z > position2.position.z)
                    {
                        if (i == arr.Count)
                        {
                            //l = Mathf.Sqrt(Mathf.Pow((arr[arr.Count - 2].z - position2.position.z), 2) + Mathf.Pow((arr[arr.Count - 2].x - position2.position.x), 2));                            
                            //z = position2.position.z + (Mathf.Abs(radious) / l * Mathf.Abs(arr[arr.Count - 2].z - position2.position.z)) ;   
                            z = position2.position.z;
                        }
                        else
                        {
                            z = position1.position.z - (Mathf.Abs(position1.position.z - position2.position.z) / arr.Count) * i + 1;
                        }
                    }
                    else
                    {
                        if (i == arr.Count)
                        {
                            //l = Mathf.Sqrt(Mathf.Pow((arr[arr.Count - 2].z - position2.position.z), 2) + Mathf.Pow((arr[arr.Count - 2].x - position2.position.x), 2));                            
                            //z = position2.position.z - (Mathf.Abs(radious) / l * Mathf.Abs(arr[arr.Count - 2].z - position2.position.z)) ;
                            z = position2.position.z;
                            
                        }
                        else
                        {
                            z = position1.position.z + (Mathf.Abs(position1.position.z - position2.position.z) / arr.Count) * i - 1;
                        }
                    }
                    if (i != arr.Count)
                    {
                        x = Random.Range(position1.position.x - 2, position2.position.x + 2);
                        y = Random.Range(position2.position.y - 0.5f, position2.position.y + 0.5f);

                    }
                    else
                    {
                        if (position1.position.x > position2.position.x)
                        {
                            //x = position2.position.x + (Mathf.Abs(radious) / l * Mathf.Abs(arr[arr.Count - 2].x - position2.position.x)) ;
                            x = position2.position.x;
                        }
                        else
                        {
                            //x = position2.position.x - (Mathf.Abs(radious) / l * Mathf.Abs(arr[arr.Count - 2].x - position2.position.x)) ;
                            x = position2.position.x;
                        }                        
                        y = position2.position.y;
                    }
                    arr[i - 1] = new Vector3(x, y, z);
                }
                break;
        }
    }

    /*void CallNewWayPoint()
    {
        newPosition = arr[CurrentWayPointNumb];
        CurrentWayPointNumb++;
        if (CurrentWayPointNumb < WayPointCount)
        {
            Invoke("CallNewWayPoint", ChangeTime);
        }
    }*/

    void MainWay()
    {
        float max = Mathf.Abs(position1.position.x - position2.position.x);
        WayChoice = 1;
        if (Mathf.Abs(position1.position.y - position2.position.y) > max)
        {
            WayChoice = 2;
            max = Mathf.Abs(position1.position.y - position2.position.y);
        }
        if (Mathf.Abs(position1.position.z - position2.position.z) > max)
        {
            WayChoice = 3;
        }
    }

    public void CallStopMoving()
    {
        Stop = true;
    }

    public void CallResumeMoving()
    {
        Stop = false;
    }

}
