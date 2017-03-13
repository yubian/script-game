using UnityEngine;
using System.Collections;
using PlayerCon;
using UnityEngine.UI;
public class NearDoor : MonoBehaviour {
    public Animator anim;
    public string text;
    PlayerController item;
    public int itemkey;
    MouseController mouse;
    public GameObject des;
    // Use this for initialization
    void Start () {
        item = GameObject.Find("Player").GetComponent<PlayerController>();
        mouse = GameObject.FindWithTag("Player").GetComponent<MouseController>();
    }
	
	// Update is called once per frame
    void OnTriggerEnter(Collider en)
    {

        // item.SetOpenTank(true);
    }
    void OnTriggerStay(Collider en)
    {
        if (en.tag == "Player")
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (item.Itemslot[itemkey] == true)
                {
                    //Destroy(des);
                    anim.enabled = true;
                    item.checkbox = "";
                    mouse.setInItem(true);
                }
            }
        }
    }
    void OnTriggerExit(Collider en)
    {
        item.checkbox = "";
        mouse.setInItem(true);
        //item.SetOpenTank(false);
    }
}
