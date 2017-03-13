using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using PlayerCon;
public class BlackUI : MonoBehaviour {
    public Image[] blackui;
    PlayerController player;
    float pos1 = 1;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (player.getEvent() == true)
        {
            blackui[0].enabled = true;
            blackui[1].enabled = true;
            if (pos1<2)
            {
                pos1 += Time.deltaTime; 
            }
            blackui[0].rectTransform.localScale = new Vector3(1, pos1, 1);
            blackui[1].rectTransform.localScale = new Vector3(1, pos1, 1);
        }
        else if(player.getEvent() == false)
        {
            if (pos1 <= 1)
            {
                blackui[0].enabled = false;
                blackui[1].enabled = false;
            }
            if (pos1 >1)
            {
                pos1 -= Time.deltaTime;
            }
            blackui[0].rectTransform.localScale = new Vector3(1, pos1, 1);
            blackui[1].rectTransform.localScale = new Vector3(1, pos1, 1);
        }
	}
}
