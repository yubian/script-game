using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using PlayerCon;

public class HPUI : MonoBehaviour {
    PlayerController player;
    public GameObject animlowhp;
    public Animator[] animUIHP;
    public Image[] img;
    public Sprite[] spri;
    int temp=0;
    float tem = 0;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (tem < 0.5f)
        {
            tem += Time.deltaTime;
        }
        else
        {
            if (player.getHP() <= 2)
            {
                animlowhp.SetActive(true);
            }
            else
            {
                animlowhp.SetActive(false);
            }
            if (player.Checkenemyforanim == false)
            {
                for (int i = 0; i < animUIHP.GetLength(0); i++)
                {
                    animUIHP[i].SetBool("idle", true);
                    animUIHP[i].SetBool("hp", false);
                }
            }
            else if(player.Checkenemyforanim == true)
            {
                for (int i = 0; i < animUIHP.GetLength(0); i++)
                {
                    animUIHP[i].SetBool("idle", false);
                    animUIHP[i].SetBool("hp", true);
                }
            }
            tem = 0;
        }
        if (temp != player.getHP())
        {
            temp = player.getHP();
            if (player.getHP() > 6)
            {
                player.setHP(6);
            }
            if (player.getHP() == 6)
            {
                img[0].sprite = spri[0];
                img[1].sprite = spri[0];
                img[2].sprite = spri[0];
            }
            if (player.getHP() == 5)
            {
                img[0].sprite = spri[0];
                img[1].sprite = spri[0];
                img[2].sprite = spri[1];
            }
            if (player.getHP() == 4)
            {
                img[0].sprite = spri[0];
                img[1].sprite = spri[0];
                img[2].sprite = spri[2];
            }
            if (player.getHP() == 3)
            {
                img[0].sprite = spri[0];
                img[1].sprite = spri[1];
                img[2].sprite = spri[2];
            }
            if (player.getHP() == 2)
            {
                img[0].sprite = spri[0];
                img[1].sprite = spri[2];
                img[2].sprite = spri[2];
            }
            if (player.getHP() == 1)
            {
                img[0].sprite = spri[1];
                img[1].sprite = spri[2];
                img[2].sprite = spri[2];
            }
            if (player.getHP() == 0)
            {
                img[0].sprite = spri[2];
                img[1].sprite = spri[2];
                img[2].sprite = spri[2];
            }
        }

    }
}
