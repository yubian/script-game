using UnityEngine;
using System.Collections;
using PlayerCon;
public class ItemEvent : MonoBehaviour {
    public GameObject eventname;
    public GameObject enemy;
    PlayerController player;
	// Use this for initialization
	void Start () {
        name = name + eventname.name;
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider en)
    {
        if (en.name ==enemy.name&& player.getEvent() == true)
        {
            Destroy(gameObject);
        }
    }
}
