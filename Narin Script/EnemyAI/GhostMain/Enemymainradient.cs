using UnityEngine;
using System.Collections;
using PlayerCon;
public class Enemymainradient : MonoBehaviour {
    PlayerController player;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider en)
    {
        if (en.tag == "Player")
        {
            player.setenemyincamera(true);
        }
    }
    void OnTriggerExit(Collider en)
    {
        if (en.tag == "Player")
        {
            player.setenemyincamera(false);
        }
    }
}
