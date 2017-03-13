using UnityEngine;
using System.Collections;
using PlayerCon;
public class CheckMoveEnemy : MonoBehaviour {
    PlayerController player;
    public GameObject nameevent;
    public GameObject enemy;
    public EventScript even;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        name = name + nameevent.name;
    }

    // Update is called once per frame
    void Update()
    {

    }
     void OnTriggerEnter(Collider en)
    {
        if (en.name == enemy.name && player.getEvent() == true)
        {
            even.Cout += 1;
            even.Entimetemp = 0;
            Destroy(this.gameObject);
        }
    }
    void OnTriggerExit(Collider en)
    {
        if (en.name == enemy.name && player.getEvent() == true)
        {
            Destroy(this.gameObject);
        }
    }
}
