using UnityEngine;
using System.Collections;
using PlayerCon;
public class Onmouse : MonoBehaviour {
    public float setTime;
    public NearIcon near;
    MouseController mouse;
    PlayerController player;
    public string talk;
    public GameObject talks;
    bool nee = false;
    public int itemid;
    public int sendbackplayer;
    public float getTime()
    {
        return setTime;
    }
    public bool getNear()
    {
        return nee;
    }
    public void setNear(bool s)
    {
        nee = s;
    }
    // Use this for initialization
    public string getTalk()
    {
        return talk;
    }
    void FixedUpdate()
    {
        if (near.Canclick == true)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (player.Itemslot[itemid] == true)
                {
                    player.Itemslot[sendbackplayer] = true;
                    near.Canclick = false;
                    Destroy(gameObject);
                }
            }
        }
    }
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        mouse = GameObject.FindGameObjectWithTag("Player").GetComponent<MouseController>();
    }
	
	// Update is called once per frame
    void OnMouseOver()
    {
        mouse.setInItem(true);
        if (nee == true)
        {
            mouse.setNametalk(gameObject.name);
            near.setIcon(true);
        }
    }
    void OnMouseExit()
    {
        mouse.setInItem(false);
        near.setIcon(false);
    }
}
