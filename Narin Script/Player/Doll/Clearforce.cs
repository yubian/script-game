using UnityEngine;
using System.Collections;

public class Clearforce : MonoBehaviour {
     BackPackScript backpack;
    // Use this for initialization
    void Start()
    {
        backpack = GameObject.Find("Canvas").GetComponent<BackPackScript>();
    GetComponent<Transform>().localEulerAngles=new Vector3(0, backpack.getMouse(), 0);
    }
    void OnCollisionEnter(Collision en)
    {
        if (en.gameObject.name == "Map")
        {
            GetComponent<ConstantForce>().relativeForce = new Vector3(0,0,0);
        }
    }
}
