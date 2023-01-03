using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KickScript : MonoBehaviour {

    GameObject rightFoot;
    GameObject leftFoot;
    GameObject head;
    GameObject ball;

    float posOfFoot;
    Vector3 differenceOfFoot;
    Vector3 angleOfKick;

    float time;
    float timeTaken;
    float maxDistanceofKick;

    List<float> timeList;
    List<float> footPos;
    List<Vector3> angleDetect;
    float angle = 0;

    bool kickStarted = false;

    BallScript bs;

    void Start()
    {
        lF = GameObject.Find("FootLeft");
        rF = GameObject.Find("FootRight");
        ball = GameObject.Find("Ball");
        head = GameObject.Find("HipLeft");
        PositionFoot = new List<float>();
        List_time = new List<float>();
        viewDetect = new List<Vector3>();
        t = 0;
        tTaken = 0;
        maxDistanceofKick = 0;
        bs = GameObject.Find("Ball").GetComponent<BallScript>();
        
    }

    void OnGUI()
    {
        GUI.Label(new Rect(20, 20, 250, 50), leftFoot.transform.position.ToString());
    }
    void Update()
    {
        posOfFoot = Mathf.Floor((leftFoot.transform.position.z - head.transform.position.z) * 100) / 100;
        if (posOfFoot > 0.1 && !kickStarted)
        {
            angleDetect.Add(leftFoot.transform.position);
            kickStarted = true;
            time = 0;
        }
        if (kickStarted)
        {
            DetectKick();
        }  
    }

    void Kick()
    {
        t = t + Time.deltaTime;
        PositionFoot.Add(pos);
        timeList.Add(time);
        
        
        if (pos < -0.4)
        {
            viewDetect.Add(leftFoot.transform.position);
            angleKick = (leftFoot.transform.position - head.transform.position);
            angleKick.Normalize();
            Debug.Log(angleKick);
            GoalkeeperBehaviour.angle = angleKick;
            IsKickStarted = false;
            KickParameters();
        }
    }


    void KickParameters()
    {
        float maxT = 0;
        float minT = 0;
        float maxD = 0;
        float minD = 0;
        float startV = 0;
        float finalV = 0;

        foreach (float t in List_time)
        {
            maxT = Mathf.Max(maxT, t);
            minT = Mathf.Min(minT, t);
        }
        
	foreach (float d in PositionFoot)
        {
            maxD = Mathf.Max(maxD, d);
            minD = Mathf.Min(minD, d);
        }

        timeT = maxT - minT;
        maxDKick = maxD - minD;

        initialVelocity = (maxD / 2) / (maxT / 2);
        finalVelocity = maxDKick / timeT;

        float[] ParametersKick = new float[5];
        ParametersKick[0] = timeT;
        ParametersKick[1] = maxDKick;
        ParametersKick[2] = angleKick.x;
        ParametersKick[3] = startV;
        ParametersKick[4] = finalV;

        GameObject.Find("Ball").SendMessage("KickForce", kickParams, SendMessageOptions.DontRequireReceiver);
    }
}
