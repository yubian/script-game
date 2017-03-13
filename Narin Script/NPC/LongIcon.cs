using UnityEngine;
using System.Collections;
using PlayerCon;

public class LongIcon : MonoBehaviour {
    MouseController mouse;
    PlayerController player;
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
            player.checkbox = "long";
        }
    }
    void OnTriggerExit(Collider en)
    {
        if (en.gameObject.name == "Player")
        {
            mouse.setInItem(false);

        }

    }
}
