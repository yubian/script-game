using UnityEngine;
using System.Collections;
using PlayerCon;
public class nonbackCheckShiftNear : MonoBehaviour {
    public GhostStillnonback ghos;
    PlayerController player;
    // Use this for initialization
    float damage = 0;
    void Start () {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerStay(Collider en)
    {
        if (en.tag == "Player")
        {
            player.Checkenemyforanim = true;
            damage += Time.deltaTime;
            if (damage > 5)
            {
                player.setHP(player.getHP() - 1);
                damage = 0;
            }
        }
    }
    void OnTriggerEnter(Collider en)
    {
        if (en.tag == "Player")
        {
            
            ghos.setGhostawake(true);
        }
    }
    void OnTriggerExit(Collider en)
    {
        if (en.tag == "Player")
        {
            player.Checkenemyforanim = false;
            damage = 0;
            ghos.setGhostawake(false);
        }
    }
}
