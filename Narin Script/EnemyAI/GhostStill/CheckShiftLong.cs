using UnityEngine;
using System.Collections;
using PlayerCon;
public class CheckShiftLong : MonoBehaviour {
    public GhostStill ghos;
    PlayerController player;
    float time = 0;
    float damage = 0;
    public float settime = 1;
	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (time >= settime)
        {
            ghos.setGhostawake(true);
        }
    }
    void OnTriggerStay(Collider en)
    {
        if (en.tag == "Player"&&!Input.GetKey(KeyCode.LeftShift))
        {
            damage += Time.deltaTime;
            if (damage > 3.5f)
            {
                player.setHP(player.getHP() - 1);
                damage = 0;
            }
        }
        if (en.tag == "Player" && Input.GetKey(KeyCode.LeftShift)|| en.tag == "Player" && !Input.anyKey)
        {
            damage -= Time.deltaTime;
            time -= Time.deltaTime;
            if (time < 0)
            {
                time = 0;
            }
            if (damage < 0)
            {
                damage = 0;
            }
        }
        if (en.tag == "Player" && !Input.GetKey(KeyCode.LeftShift))
        {
            time += Time.deltaTime;
        }
        if (en.tag == "Player" && Input.GetKey(KeyCode.Space))
        {
            ghos.setGhostawake(true);
        }
        if (en.tag == "Player")
        {
            player.Checkenemyforanim = true;
        }
        if (en.tag == "DollBear")
        {
            ghos.setDoll(true);
            ghos.setNameItem(en.gameObject.name);
            ghos.setPosDoll(en.gameObject.GetComponent<Transform>().position);
            
        }
    }
    void OnTriggerExit(Collider en)
    {
        if (en.tag == "Player")
        {
            player.Checkenemyforanim = false;
            damage = 0;
            ghos.setGhostawake(false);
            time = 0;
        }
    }
}
