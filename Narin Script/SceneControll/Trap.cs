using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider player)
    {
        if(player.tag == "Player")
        {
            player.GetComponent<PlayerStatus>().setHP(player.GetComponent<PlayerStatus>().getHP()-1);
        }

    }
}
