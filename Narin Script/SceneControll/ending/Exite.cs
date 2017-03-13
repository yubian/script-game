using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using PlayerCon;
public class Exite : MonoBehaviour {
    PlayerController player;
    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider en)
    {
        if (en.gameObject.name == "Player")
        {if(player.Itemslot[0]==true&& player.Itemslot[1] == true
                && player.Itemslot[2] == true && player.Itemslot[3] == true)
            {
                SceneManager.LoadScene("Ending");
            }
        }
    }
}
