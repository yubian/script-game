using UnityEngine;
using System.Collections;

public class EventMoveEnemy : MonoBehaviour {
    string targetmove;
    float delay;
    float speed;

    public float Delay
    {
        get
        {
            return delay;
        }

        set
        {
            delay = value;
        }
    }

    public float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }

    public string Targetmove
    {
        get
        {
            return targetmove;
        }

        set
        {
            targetmove = value;
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
