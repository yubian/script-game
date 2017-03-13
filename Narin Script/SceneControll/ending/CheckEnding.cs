using UnityEngine;
using System.Collections;
using PlayerCon;
public class CheckEnding : MonoBehaviour {
    public GameObject[] ending;
    float timecheck = 0;
    PlayerController player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        timecheck += Time.deltaTime;
        if (timecheck >= 10)
        {
            timecheck = 0;
            if (player.Itemslot[0]==true&& player.Itemslot[1] == true&& player.Itemslot[2] == true
                && player.Itemslot[3] == true&&GameObject.Find("ChildGoodEnding") != null)
            {
                ending[0].SetActive(true);
                ending[1].SetActive(false);
            }
           else if (player.Itemslot[0] == true && player.Itemslot[1] == true && player.Itemslot[2] == true
                && player.Itemslot[3] == true && GameObject.Find("ChildGoodEnding") == null)
            {
                ending[0].SetActive(false);
                ending[1].SetActive(true);
            }
        }
	}
}
