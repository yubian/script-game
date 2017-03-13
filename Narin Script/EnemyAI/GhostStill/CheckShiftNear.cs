using UnityEngine;
using System.Collections;
public class CheckShiftNear : MonoBehaviour {
    public GhostStill ghos;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider en)
    {
        if (en.tag == "Player")
        {
            ghos.setGhostawake(true);
        }
    }
}
