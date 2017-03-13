using UnityEngine;
using System.Collections;
using PlayerCon;
public class Near : MonoBehaviour {
    PlayerController player;
    MouseController mouse;
    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        mouse = GameObject.FindWithTag("Player").GetComponent<MouseController>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider en)
    {
        if (en.gameObject.name == "Player")
        {
            player.checkbox = "near";
            mouse.setInItem(true);
        }
       
    }
    void OnTriggerExit(Collider en)
    {
         if (en.gameObject.name == "Player")
        {
            player.checkbox = "long";
        }

    }
}
