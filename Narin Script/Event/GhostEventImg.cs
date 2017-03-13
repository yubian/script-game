using UnityEngine;
using System.Collections;
using PlayerCon;
public class GhostEventImg : MonoBehaviour {
    PlayerController player;
    public EventScript even;
    Vector3 tempscal=new Vector3(1,1,1);
    Transform tran;
    string tempname;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        
	}
	
	// Update is called once per frame
	void Update () {
        if (player.getEvent() == true&&even.Cout<even.eventenemy.GetLength(0))
        {
            if (tempname != even.eventenemy[even.Cout].moveEnemy.name)
            {
                tempname = even.eventenemy[even.Cout].moveEnemy.name;
                tran = GameObject.Find(even.eventenemy[even.Cout].moveEnemy.name).GetComponent<Transform>();
            }
            if (tempscal != transform.localScale)
            {
                if (tran.position.x < transform.position.x)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    tempscal = transform.localScale;
                }
                if (tran.position.x > transform.position.x)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    tempscal = transform.localScale;
                }
            }

        }
	}
}
