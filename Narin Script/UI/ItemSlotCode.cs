using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using PlayerCon;
public class ItemSlotCode : MonoBehaviour {
    PlayerController player;
    public Image[] slot;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	for(int i = 0; i < slot.GetLength(0); i++)
        {
            if (player.Itemslot[i] == false)
            {
                slot[i].enabled = false;
            }
            else if (player.Itemslot[i] == true)
            {

                slot[i].enabled = true;
            }
        }
        }
}
