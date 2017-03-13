using UnityEngine;
using System.Collections;

public class lightkill : MonoBehaviour {
    bool setligt = false;

    public bool Setligt
    {
        get
        {
            return setligt;
        }

        set
        {
            setligt = value;
        }
    }

    // Use this for initialization
    void OnTriggerEnter(Collider en)
    {if (en.tag == "Player")
        {
            setligt = true;
        }

    }
    void OnTriggerExit(Collider en)
    {
        if (en.tag == "Player")
        {
            setligt = false;
        }
    }


    }
