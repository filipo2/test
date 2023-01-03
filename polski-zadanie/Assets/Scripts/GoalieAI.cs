using UnityEngine;
using System.Collections;

public class GoalkeeperBehaviour : MonoBehaviour {

    Ball ball;
    public static int force
    {
        get;
        set;
    }

    public static Vector3 view
    {
        get;
        set;
    }
    GameObject goalie;
    Vector3 goaliePos;
	void Start () {
        goalkeeper = GameObject.Find("Goalkeeper");
        goalkeeperPos = goalkeeper.transform.position;
        ball = GameObject.Find("Ball").GetComponent<BallScript>();
        force = 0;
	}
	
	// Update is called once per frame
	void Update () {
        switch (force)
        {
            case 0:
                
                break;
            case 15:
                if (view.x < -0.1)
                {
                    transform.GetComponent<Animation>().Play("MinimumLeft");
                }
                else if (view.x > 0.1)
                {
                    transform.GetComponent<Animation>().Play("MinimumRight");
                }
                else
                {
                    transform.GetComponent<Animation>().Play("MinimumCentre");
                }
                force = 0;
                break;
            case 28:
                if (view.x < -0.1)
                {
                    transform.GetComponent<Animation>().Play("MaximumLeft");
                }
                else if (view.x > 0.1)
                {
                    transform.GetComponent<Animation>().Play("MaximumRight");
                }
                else
                {
                    transform.GetComponent<Animation>().Play("MaximumCentre");
                }
                force = 0;
                break;
        }
	}

    void reset()
    {
        goalkeeper.transform.position = goalkeeperPos;
    }
    
}
