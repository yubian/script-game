using UnityEngine;
using System.Collections;
using PlayerCon;
public class NearIcon : MonoBehaviour {
    public Onmouse npc;
    MouseController mouse;
    public GameObject icon;
    PlayerController player;
    bool canclick = false;

    public bool Canclick
    {
        get
        {
            return canclick;
        }

        set
        {
            canclick = value;
        }
    }
    public void setIcon(bool s)
    {
        icon.SetActive(s);
    }
    // Use this for initialization
    void Start()
    {
        mouse = GameObject.FindWithTag("Player").GetComponent<MouseController>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter(Collider en)
    {
        if (en.gameObject.name == "Player")
        {
            Canclick = true;
            mouse.setMaxtime(npc.getTime());
            mouse.setNear(true);
            npc.setNear(true);
            player.checkbox = "";
            mouse.Talknpc = true;
        }

    }
    void OnTriggerExit(Collider en)
    {
        if (en.gameObject.name == "Player")
        {
            Canclick = false;
            mouse.Talknpc = false;
            mouse.setNear(false);
            npc.setNear(false);
            player.checkbox = "long";
        }

    }
}
