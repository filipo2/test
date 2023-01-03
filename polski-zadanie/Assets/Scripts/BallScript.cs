using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

    float time;
    float distance;
    float view;
    float initialVelocity;
    float finalVelocity;
    float force;
    float mass = 15f;
    float a;

    ScriptHandler handler;

    public static string goal = null;
    void Start()
    {
        handler = GameObject.Find("ScriptHandler").GetComponent<ScriptHandler>();
    }
    void KickForce(float[] parameters)
    {
        time = parameters[0];
        dist = parameters[1];
        view = parameters[2];
        startV = param[3];
        finalV = param[4];


        a = (finalV - startV) / time;
        force = mass * finalV;
        if (force < 5)
        {
            force = 15;
        }
        else
        {
            force = 28;
        }
        transform.GetComponent<Rigidbody>().AddForce(force * new Vector3(view, 0.2f, 1) * 55);
        Debug.Log(force);
        GoalkeeperBehaviour.force = (int)force;
        handler.SendMessage("Kick next ball", SendMessageOptions.DontRequireReceiver);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            handler.SendMessage("Kick next ball", SendMessageOptions.DontRequireReceiver);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Goal")
        {
            goal = "Goal";
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(50, 50, 200, 100), goal);
    }
}
