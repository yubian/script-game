using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using PlayerCon;
public class EventUI : MonoBehaviour {
    MouseController mouse;
    bool runone=false;
    string destoyevent;
    int couttxt=0;
    float txttime;
    float starttimeshow;
    Color setapha;
    string txttemp;
    string txttutorial;
    char[] txtper;
    char[] txtchartutorial;
    string txttemptutorial;
    int sizeimg=0;
    public Image textimg;
    public Text txt;
    public Image imgL;
    public Image imgR;
    public Text tutorial;
    public GameObject[] itemface;
    List<string> textEvent;
    string nameEvent;
    string nameposCamEvent;

    List<GameObject> posname;
    List<bool> cammove;
    List<float> camstartevent;
    List<float> camendevent;
    List<float> cameraspeedevent;
    float speedcamback;

    PlayerController player;
    List<float> timetext;
    List<Sprite> imgch;
    List<int> selectimg;
    List<bool> selectshow;
    public GameObject[] even;
    List<string> EvenName;
    int cout=0;
    bool outtime = true;
    bool showtutorial = false;
    float timeonspace=0.05f;
    public List<string> EvenName1
    {
        get
        {
            return EvenName;
        }

        set
        {
            EvenName = value;
        }
    }

    public List<float> Cameraspeedevent
    {
        get
        {
            return cameraspeedevent;
        }

        set
        {
            cameraspeedevent = value;
        }
    }

    public List<float> Camendevent
    {
        get
        {
            return camendevent;
        }

        set
        {
            camendevent = value;
        }
    }

    public List<float> Camstartevent
    {
        get
        {
            return camstartevent;
        }

        set
        {
            camstartevent = value;
        }
    }

    public List<bool> Cammove
    {
        get
        {
            return cammove;
        }

        set
        {
            cammove = value;
        }
    }

    public List<GameObject> Posname
    {
        get
        {
            return posname;
        }

        set
        {
            posname = value;
        }
    }

    public float Speedcamback
    {
        get
        {
            return speedcamback;
        }

        set
        {
            speedcamback = value;
        }
    }

    public string Txttemptutorial
    {
        get
        {
            return txttemptutorial;
        }

        set
        {
            txttemptutorial = value;
        }
    }

    public bool Showtutorial
    {
        get
        {
            return showtutorial;
        }

        set
        {
            showtutorial = value;
        }
    }

    // Use this for initialization
    public void setDestoyEvent(string s)
    {
        this.destoyevent = s;
    }
    public void setTxtTutorial(string s)
    {
        txttutorial = s;
    }
    public void setStartTimeShow(float s)
    {
        starttimeshow = s;
    }
    public void setSelectShow(bool s)
    {
        selectshow.Add(s);
    }
    public void setSelectImg(int s)
    {
        selectimg.Add(s);
    }
    public void setImgCH(Sprite s)
    {
        imgch.Add(s);
    }
    public void setTimeText(float a)
    {
        timetext.Add(a);
    }
    public void setNameEvent(string nam)
    {
        nameEvent = nam;
    }
    public string getNameEvent()
    {
        return nameEvent;
    }
    public void setNamePosEvent(string nam)
    {
        nameposCamEvent = nam;
    }
    public string getNamePosEvent()
    {
        return nameposCamEvent;
    }
    public void setTextEvent(string tex)
    {
        textEvent.Add(tex.ToString());
    }
    void Start () {
        Posname = new List<GameObject>();
        cammove = new List<bool>();
         camstartevent=new List<float>();
        camendevent=new List<float>();
        cameraspeedevent=new List<float>();
        EvenName1 = new List<string>();

        mouse = GameObject.FindWithTag("Player").GetComponent<MouseController>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        textEvent = new List<string>();
        timetext = new List<float>();
        selectimg = new List<int>();
        imgch = new List<Sprite>();
        selectshow = new List<bool>();
        tutorial.enabled = false;
        textimg.enabled = false;
        txt.enabled = false;
        imgL.enabled=false;
        imgR.enabled=false;
        setapha = new Color(1f, 1f, 1f, 0f);
        imgL.color = setapha;
        imgR.color = setapha;
        for (int i = 0; i < even.GetLength(0); i++)
        {
            EvenName1.Add(even[i].name);

        }

    }

	// Update is called once per frame
	void FixedUpdate() {
        for (int i = 0; i < even.GetLength(0); i++)
        {
            if (i > 0)
            {
                if (even[i - 1] == null)
                {
                    if (even[i] != null)
                        even[i].SetActive(true);

                }
            }

        }
        if (player.getEvent() == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
        {
            player.setEvent(false);
                runone = true;
                player.Runone = true;
        }
            tutorial.text = "";
               itemface[0].SetActive(false);
            itemface[1].SetActive(false);
            if(player.getstopmove() == false)
            {
                textimg.enabled = false;
                txt.enabled = false;
                imgL.enabled = false;
                imgR.enabled = false;
            }
            if (player.getstopmove() == true && textEvent.Count>0)
            {

                if (starttimeshow > 0)
            {
                starttimeshow -= Time.deltaTime;
            }
            if (starttimeshow <= 0)
            {
                if (sizeimg != imgch.Count)
                {
                    sizeimg = imgch.Count;
                }
                if (cout < textEvent.Count && cout != textEvent.Count)
                    {
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            timeonspace = 0;
                            timetext[cout] = 0;
                        }
                        else
                        {
                            timeonspace = 0.05f;
                        }
                    if (timetext[cout] > 0f)
                    {
                        timetext[cout] -= Time.deltaTime;
                        Show();
                    }
                    else
                    {
                        couttxt = 0;
                        txttemp = "";
                        cout++;

                        if (cout >= 1 && cout != textEvent.Count)
                        {
                            if (selectshow[cout] != selectshow[cout - 1])
                            {
                                setapha.a = 0f;
                            }
                        }
                        imgL.color = setapha;
                        imgR.color = setapha;
                        outtime = true;
                        if (cout >= textEvent.Count)
                        {
                                player.setcountrun(player.getcountrun() + 1);
                                player.setstopmove(false);
                                cout = 0;
                            Invoke("OnTutorial", 2.0f);
                                //layer.setEvent(false);

                                runone = true;
                            textEvent.Clear();
                            timetext.Clear();
                            selectimg.Clear();
                            imgch.Clear();
                            selectshow.Clear();
                        }

                    }
                }
            }
            }
            if (textEvent.Count <= 0)//null text
            {
                player.setstopmove(false);
            }
        }
        else
        {
            if (runone == true)
            {
                textEvent.Clear();
                timetext.Clear();
                selectimg.Clear();
                imgch.Clear();
                selectshow.Clear();

                cammove.Clear();
                camstartevent.Clear();
                camendevent.Clear();
                cameraspeedevent.Clear();
                posname.Clear();
                   itemface[0].SetActive(true);
                itemface[1].SetActive(true);
                Destroy(GameObject.Find(destoyevent));
                if (mouse.Talknpc == false)
                {
                    textimg.enabled = false;
                    txt.enabled = false;
                }
                imgL.enabled = false;
                imgR.enabled = false;
                txttemp = "";
                textEvent.Clear();
                runone = false;
            }
            ShowTutorial();
        }
	}
    void ShowTutorial()
    {
        if (Showtutorial == true)
        {
            tutorial.enabled = true;
            txtchartutorial = txttutorial.ToCharArray();
            txttime += Time.deltaTime;
            if (txttime > 0.05f)
            {
                txttime = 0;
                if (couttxt != txtchartutorial.GetLength(0))
                {
                    Txttemptutorial += txtchartutorial[couttxt].ToString();
                }
                else if(couttxt == txtchartutorial.GetLength(0))
                {
                    Invoke("OffTutorial", 5.0f);
                }
                tutorial.text = Txttemptutorial;
                if (couttxt < txtchartutorial.GetLength(0))
                {
                    couttxt++;
                }
            }
        }
        else
        {
            tutorial.enabled = false;
            txttime = 0;
            Txttemptutorial = "";
            couttxt = 0;
        }
    }
    void OnTutorial()
    {
        Showtutorial = true;
    }
    void OffTutorial()
    {
        Showtutorial = false;
    }
    void Show()
    {
        if (outtime == true)
        {
            textimg.enabled = true;
            txt.enabled = true;
            if (selectshow[cout] == false)
            {
                if (selectimg[cout] == 0)
                {
                    imgL.sprite = imgch[0];
                }
                if (selectimg[cout] == 1)
                {
                    imgL.sprite = imgch[1];
                }
                imgL.enabled = true;
                imgR.enabled = false;
                if (imgL.color.a != 1)
                {
                    setapha.a += Time.deltaTime;
                    if (setapha.a > 1f)
                    {
                        setapha.a = 1f;
                    }
                    imgL.color = setapha;
                }
            }
            if (selectshow[cout] == true)
            {
                if (selectimg[cout] == 0)
                {
                    imgR.sprite = imgch[0];
                }
                if (selectimg[cout] == 1)
                {
                    imgR.sprite = imgch[1];
                }
                imgL.enabled = false;
                imgR.enabled = true;
                if (imgR.color.a != 1)
                {
                    setapha.a += Time.deltaTime;
                    if (setapha.a > 1f)
                    {
                        setapha.a = 1f;

                    }
                    imgR.color = setapha;
                }
            }
            txtper = textEvent[cout].ToCharArray();
            txttime += Time.deltaTime;
            if (txttime > timeonspace)
            {
                txttime = 0;
                if (couttxt != txtper.GetLength(0))
                {
                    txttemp += txtper[couttxt].ToString();
                }
                    txt.text = txttemp;
                if (couttxt < txtper.GetLength(0))
                {
                    couttxt++;
                }
            }
            
            
        }
    }
}
