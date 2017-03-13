using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PlayerCon;
[System.Serializable]
public class EventState
{
   
    public string textEvent=" ";
    public int selectedimg=0;
    public float timeshowtext=0.0f;
    public bool leftrightshow=false;
}
[System.Serializable]
public class SetMoveEnemy
{
    public GameObject moveEnemy;
    public float delay = 0;
    public float speed = 0;

}
[System.Serializable]
public class setCam
{
    public GameObject posname;
    public bool cammove = false;
    public float start = 0;
    public float end = 0;
    public float speed = 0;

}
[System.Serializable]
public class MovePlayer
{
    public GameObject moveplayer;
    public float movespeedplayer;
    public float stay;

}
public class EventScript : MonoBehaviour {
    EventUI even;
  //  public float speedCamEvent;
    public float starttimeshow;
    PlayerController player;
    public GameObject posname;
    public GameObject eventname;
    public bool movebeforetxt;
    public MovePlayer[] playerMove;
    public Sprite[] ImgCH;
    public string TextTutorial;
    public EventState[] eventset;
    public GameObject enemy;
    public SetMoveEnemy[] eventenemy;
    public float speedcamback;
    public setCam[] cam;
    float entimetemp = 0;
    int cout = 0;
    bool emmove = false;
    public int Cout
    {
        get
        {
            return cout;
        }

        set
        {
            cout = value;
        }
    }

    public float Entimetemp
    {
        get
        {
            return entimetemp;
        }

        set
        {
            entimetemp = value;
        }
    }

    // Use this for initialization
    void Start () {
        if (enemy != null)
        {
            enemy.name = name + enemy.name;
        }
        posname.name = "Target" + eventname.name;
        name = "CheckBox" + eventname.name; 
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        even = GameObject.Find("Canvas").GetComponent<EventUI>();
        for(int i=0;i< cam.GetLength(0); i++)
        {
            if (cam[i] != null)
            {
                cam[i].posname.name = posname.name + eventname.name;
            }
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (player.getEvent() == true&&enemy!=null&&emmove==true)
        {
            if (cout < eventenemy.GetLength(0))
            {
                if (Entimetemp <= eventenemy[Cout].delay)
                {
                    Entimetemp += Time.deltaTime;
                }
                if (Entimetemp > eventenemy[Cout].delay)
                {
                    enemy.GetComponent<Transform>().position = Vector3.MoveTowards(enemy.GetComponent<Transform>().position,
                       new Vector3(eventenemy[Cout].moveEnemy.GetComponent<Transform>().position.x, enemy.transform.position.y,
                       eventenemy[Cout].moveEnemy.GetComponent<Transform>().position.z), eventenemy[Cout].speed);
                   
                }
            }
        }
    }
        void OnTriggerEnter(Collider en)
    {
        if (player.getEvent() == false) {
            if (en.tag == "Player")
            {
                even.Speedcamback = speedcamback;
                for (int i = 0; i < cam.GetLength(0); i++)
                {
                  
                        even.Posname.Add(cam[i].posname);
                        even.Cammove.Add(cam[i].cammove);
                        even.Camendevent.Add(cam[i].end);
                        even.Camstartevent.Add(cam[i].start);
                        even.Cameraspeedevent.Add(cam[i].speed);
                   
                }
                even.Txttemptutorial = "";
                emmove = true;
                even.setDestoyEvent(eventname.name);
                // even.setCamSpeedEvent(speedCamEvent);
                //even.setNamePosEvent(posname.name);
                even.setNameEvent(name);
                player.setEvent(true);
                even.setStartTimeShow(starttimeshow);
                even.setTxtTutorial(TextTutorial);
                player.setstopmove(movebeforetxt);
                for (int i = 0; i < playerMove.GetLength(0); i++)
                {
                    player.setStaymove(playerMove[i].stay);
                    player.setNameMoveEvent(playerMove[i].moveplayer.name);
                    player.setMoveSpeedEvent(playerMove[i].movespeedplayer);
                }
                for (int i = 0; i < ImgCH.GetLength(0); i++)
                {
                    even.setImgCH(ImgCH[i]);
                }
                for (int i = 0; i < eventset.GetLength(0); i++)
                {
                    even.setTextEvent(eventset[i].textEvent);
                    even.setSelectImg(eventset[i].selectedimg);
                    even.setSelectShow(eventset[i].leftrightshow);
                    even.setTimeText(eventset[i].timeshowtext);
                }
            }
        }
    }
}
