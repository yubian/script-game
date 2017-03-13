using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkclick : MonoBehaviour {
    public GameObject main;

    void OnMouseDown()
    {
        main.GetComponent<poscheckitem>().checkitem = false;
        main.GetComponent<poscheckitem>().withnext = true;
       // main.GetComponent<poscheckitem>().cout -= 1;
    }
}
