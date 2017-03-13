using UnityEngine;
using System.Collections;
using PlayerCon;
public class ForSee : MonoBehaviour {
    public GhostWalk ghos;
   public SphereCollider rad;
    // Use this for initialization
    PlayerController player;
    // Use this for initialization
    float damage = 0;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }
    void OnTriggerEnter(Collider en)
    {
        if (en.tag == "Player")
        {
            rad.radius = 6f;
            
            ghos.setseeplayer(true);
        }
        
    }
    void OnTriggerExit(Collider en)
    {
        if (en.tag == "Player")
        {
            player.Checkenemyforanim = false;
            damage = 0;
            rad.radius = 4.5f;
            ghos.setseeplayer(false);
        }

    }
    void OnTriggerStay(Collider en)
    {
        if (en.tag == "Player")
        {
            player.Checkenemyforanim = true;
            damage += Time.deltaTime;
            if (damage > 6)
            {
                player.setHP(player.getHP() - 1);
                damage = 0;
            }
        }
    }
}
