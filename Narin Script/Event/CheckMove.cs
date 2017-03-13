using UnityEngine;
using System.Collections;
using PlayerCon;
public class CheckMove : MonoBehaviour {
    PlayerController player;
    public GameObject nameevent;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        name = name + nameevent.name;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider en)
    {
        if(en.tag=="Player"&& player.getEvent() == true)
        {
            player.setCount(player.getCount() + 1);
            player.Entimetemp1 = 0;
        }
    }
    void OnTriggerExit(Collider en)
    {
        if (en.tag == "Player" && player.getEvent() == true)
        {
            Destroy(this.gameObject);
        }
    }
}
