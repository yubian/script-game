using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using PlayerCon;

public class EmoScript : MonoBehaviour {
    PlayerController play;
     GameObject player;
    MouseController mouse;
    public Vector3 pos;
    public GameObject[] emotion;
    //public Image emobox;
    string oldtxt;
    float temptime;
    public Sprite[] img;
    void Start () {
        player = GameObject.Find("Player");
        play = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        mouse = GameObject.FindWithTag("Player").GetComponent<MouseController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (play.getEvent() == false)
        {
            //emo.transform.position = Camera.main.WorldToScreenPoint(player.GetComponent<Transform>().position) + pos;
            if (play.getCheckbox()!=oldtxt||mouse.getInItem()==false) { temptime = 0; }
            if (play.getCheckbox() == "long" && mouse.getInItem() == true)
            {
                temptime += Time.deltaTime;
                if (temptime <= 0.2f)
                {
                    emotion[0].SetActive(false);
                    emotion[1].SetActive(false);
                    emotion[2].SetActive(true);
                    emotion[3].SetActive(false);
                }
                else if (temptime > 0.2f)
                {
                    emotion[0].SetActive(false);
                    emotion[1].SetActive(false);
                    emotion[2].SetActive(false);
                    emotion[3].SetActive(true);
                }
                oldtxt = play.getCheckbox();
                //emobox.sprite = img[0];
            }
            if (play.getCheckbox() == "near" && mouse.getInItem() == true)
            {
                temptime += Time.deltaTime;
                if (temptime <= 0.2f)
                {
                    emotion[0].SetActive(true);
                    emotion[1].SetActive(false);
                    emotion[2].SetActive(false);
                    emotion[3].SetActive(false);
                }
                else if (temptime > 0.2f)
                {
                    emotion[0].SetActive(false);
                    emotion[1].SetActive(true);
                    emotion[2].SetActive(false);
                    emotion[3].SetActive(false);
                }
                oldtxt = play.getCheckbox();
                //emobox.sprite = img[1];
            }
            if (play.getCheckbox() == "" || mouse.getInItem() == false)
            {
                emotion[0].SetActive(false);
                emotion[1].SetActive(false);
                emotion[2].SetActive(false);
                emotion[3].SetActive(false);
                //emobox.sprite = img[2];
            }
        }
    }
}
