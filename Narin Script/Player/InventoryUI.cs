using UnityEngine;
using System.Collections;
using PlayerCon;
using UnityEngine.UI;
public class InventoryUI : MonoBehaviour {
    //public Image img;
   // public Sprite imgfile;
    public Text txt;
    int cout=0;
    PlayerController player;
	// Use this for initialization
	void Start () {
       
        player = GameObject.Find("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void FixedUpdate() {
        checkkeyitem();
        //txt.text = ""  + cout + " X";
        /*if (GameObject.Find("Player").GetComponent<PlayerController>().getKeyItem(0) == true)
        {
            img[0].sprite = imgfile;
            img[0].color=new Color(255, 255, 255);
        }*/
    }
    void checkkeyitem()
    {
        int k = 0;
      //  for (int i = 0; i < 3; i++) {
            
            //if (player.getKeyItem(i) == true)
         //   {
         //       k++;
         //   }
        //    cout = k;
          //      }
    }
}
