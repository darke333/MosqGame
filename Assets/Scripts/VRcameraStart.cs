using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.VR;
using UnityEngine.XR;

public class VRcameraStart : MonoBehaviour {


    public Transform VRCamHolder; //parent of the cam
    public Transform AttackPoint;
    public float WaitBeforeCompensation = 0.5f;
    Vector3 deltaPos;
    Vector3 tmp;

    // Use this for initialization
    void Start()
    {
        VRCamHolder = gameObject.transform;
        RegulCamera();
        
    }

    public void RegulCamera()
    {
        StartCoroutine(Compensate());
    }

    public IEnumerator Compensate()
    {
        yield return new WaitForSeconds(WaitBeforeCompensation);
        deltaPos = InputTracking.GetLocalPosition(XRNode.Head);
        tmp = Vector3.zero;
        tmp.x = deltaPos.x;
        tmp.y = deltaPos.y * -1f;
        tmp.z = deltaPos.z;
        VRCamHolder.position += tmp;
        AttackPoint.position += tmp;
    }
    
}
