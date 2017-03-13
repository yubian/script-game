using UnityEngine;
using System.Collections;
using PlayerCon;
public class RadianCheckEnemy : MonoBehaviour {
    AudioSource audi;
    CameraMainScript main;
    GameObject uieffect;
    Animator animUieffect;
    bool bossout = false;
    bool bossin = true;
    // Use this for initialization
    bool checksound = false;
    float kk = 0;
    GameObject findboss;
    PlayerController player;
    float damage = 0;
    public void setCheckSound(bool s)
    {
        checksound = s;
    }
    void Start () {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        animUieffect = GameObject.Find("EffectEnemy").GetComponent<Animator>();
        audi = GetComponent<AudioSource>();
        main = GameObject.Find("MainCamera").GetComponent<CameraMainScript>();
    }
    void Awake()
    {
        
    }
	// Update is called once per frame
	void Update () {
        if (checksound==false)
        {
            audi.Stop();
        }kk += Time.deltaTime;
        if (kk > 7)
        {
            findboss = GameObject.Find("MainEnemy");
            kk = 0;
        }
        if (player.getEvent() == false)
        {
            if (findboss != null && bossin == true)
            {
                bossin = false;
                bossout = true;
                animUieffect.SetBool("effectin", true);
                animUieffect.SetBool("effectout", false);
            }
            if (findboss == null && bossout == true)
            {
                bossin = true;
                bossout = false;
                animUieffect.SetBool("effectout", true);
                animUieffect.SetBool("effectin", false);
            }
        }
        if (player.getEvent() == true)
        {
            bossin = true;
            bossout = false;
            animUieffect.SetBool("effectout", true);
            animUieffect.SetBool("effectin", false);
        }
	}
    void OnTriggerExit(Collider en)
    {
            if (en.tag == "Enemy")
        {
           // player.Checkenemyforanim = false;
            checksound = false;
            main.setNameEnemy("");
            main.setCKI(false);
        }
    }
    /*void OnTriggerStay(Collider en)
    {
        if (en.tag == "Enemy")
        {
            damage += Time.deltaTime;
            if (damage > 2)
            {
                player.setHP(player.getHP() - 1);
                damage = 0;
            }
        }
    }*/
    void OnTriggerEnter(Collider en)
    {

        if (en.tag == "Enemy")
        {
               //player.Checkenemyforanim = true;
               checksound = true;
            main.setNameEnemy(en.gameObject.name);
            main.setCKI(true);
            audi.Play();
        }
    }
}
