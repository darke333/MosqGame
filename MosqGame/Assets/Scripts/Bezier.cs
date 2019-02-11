using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bezier : MonoBehaviour {

    //public LineRenderer lineRenderer;
    //public Transform point1, point2, point3, point4;
    public Transform[] controlPoints;
    public Transform Enemy;
    //private int numPos = 25;
    public Vector3[] positions = new Vector3[100];
    private int i;
    GameObject BiteArea;
    public bool Stop = false;
    private int curveCount = 0;
    private int layerOrder = 0;
    private int SEGMENT_COUNT = 50;
    public bool StartMoving;
    public bool Interacting;






    void Start()
    {
        /*if (!lineRenderer)
        {
            lineRenderer = GetComponent<LineRenderer>();
        }
        //lineRenderer.positionCount = SEGMENT_COUNT;
        lineRenderer.sortingLayerID = layerOrder;*/
        
        BiteArea = GameObject.Find("BiteAreaBorder");
        curveCount = (int)controlPoints.Length / 3;
        i = 0;
        CreateWayPoints();
        Interacting = false;
        DrawCurve();
        if (gameObject.name == "RangeFixed(Clone)")
            StartMoving = false;
        else
            StartMoving = true;
            
    }
    void Update()
    {
        if (StartMoving)
        {
            if (!BiteArea.GetComponent<Collider>().bounds.Contains(Enemy.transform.position) && !Stop && !Interacting)
            {
                MovingEnemy();
            }
            else
            {
                if (BiteArea.GetComponent<Collider>().bounds.Contains(Enemy.transform.position))
                {
                    Destroy(this);
                }
            }
        }
        
        //DrawCurve();
    }

    void DrawCurve()
    {
        for (int j = 0; j < curveCount; j++)
        {
            for (int i = 1; i <= SEGMENT_COUNT; i++)
            {
                float t = i / (float)SEGMENT_COUNT;
                int nodeIndex = j * 3;
                Vector3 pixel = CalculateCubicBezierPoint(t, controlPoints[nodeIndex].position, controlPoints[nodeIndex + 1].position, controlPoints[nodeIndex + 2].position, controlPoints[nodeIndex + 3].position);
                positions[(j * SEGMENT_COUNT) + (i - 1)] = pixel;
                //lineRenderer.positionCount = ((j * SEGMENT_COUNT) + i);
                //lineRenderer.SetPosition((j * SEGMENT_COUNT) + (i - 1), pixel);
            }
        }
        //lineRenderer.SetPositions(positions);
        //positions = lineRenderer.GetPositions();
        //lineRenderer.Get
    }

    Vector3 CalculateCubicBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 p = uuu * p0;
        p += 3 * uu * t * p1;
        p += 3 * u * tt * p2;
        p += ttt * p3;

        return p;
    }

    private void MovingEnemy()
    {
        if (Enemy.position != positions[i])
        {
            Enemy.position = Vector3.MoveTowards(Enemy.position, positions[i], Time.deltaTime);
        }
        else
        {
            if (i != 100)
            {
                i++;
            }

        }

    }

    private void CreateWayPoints()
    {
        controlPoints[0] = Enemy.transform;
        Transform Tplayer = GameObject.Find("Player").transform;
        controlPoints[6] = Tplayer;
        controlPoints[3].position = Vector3.Lerp(controlPoints[0].position, controlPoints[6].position, 0.5f);
        float Ex = Enemy.position.x;
        float Ey = Enemy.position.y;
        float Ez = Enemy.position.z;
        float Px = Tplayer.position.x;
        float Py = Tplayer.position.y;
        float Pz = Tplayer.position.z;
        float ZDiff = Ez - Pz;
        controlPoints[1].position = new Vector3(Ex - 3, Ey - 1f, Ez - ZDiff / 6);
        controlPoints[2].position = new Vector3(Ex + 2, Ey + 1, Ez - ZDiff / 3);
        controlPoints[4].position = new Vector3(Ex - 1.5f, Ey + 1, Ez - ZDiff / 2);
        controlPoints[5].position = new Vector3(Ex + 0.5f, Ey - 1, Ez - ZDiff / 1.5f);
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
