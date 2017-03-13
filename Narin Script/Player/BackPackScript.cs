using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using PlayerCon;
public class BackPackScript : MonoBehaviour { 
    PlayerController inplayer;
    public GameObject spawitempos;
    public GameObject prefabdoll;
    public GameObject door;
   public  GameObject player;
    public Vector3 pos;
    Vector3 mouseinput;
    public GameObject backpackui;
    bool showbackpack = false;
    public Text txt;
    public Sprite[] img;
    Sprite tempimg;
    public Image[] item;
    int tempid = 0;
    int temp = 0;
    int po=0;
    int size =1;
    int useitem = 0;
    int firttime = 0;
    public float deg = 100.0F;
    int choseitemslot = 0;
    bool opentank = false;
    bool up, down, left, right = false;
    int coutname = 0;
    float mouseangle;
    public float getMouse()
    {
        return mouseangle;
    }
    public void SetOpenTank(bool ss)
    {
        opentank = ss;
    }
    public bool getOpenTank( )
    {
      return  opentank;
    }
    // Use this for initialization
    void Start () {
        inplayer = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void CheckPosMouse()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            left = true;
            right = false;
            up = false;
            down = false;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            left = false;
            right = true;
            up = false;
            down = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            up = false;
            down = true;
            left = false;
            right = false;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            down = false;
            up = true;
            left = false;
            right = false;
        }
    }
    void SetPosSpawn()
    {
        if (up == true)
        {
            spawitempos.transform.localPosition = new Vector3(0, spawitempos.transform.localPosition.y, 1);
            mouseangle = 0;
        }
        if (down == true)
        {
            spawitempos.transform.localPosition = new Vector3(0, spawitempos.transform.localPosition.y, -1);
            mouseangle = 180;
        }
        if (left == true)
        {
            spawitempos.transform.localPosition = new Vector3(-1, spawitempos.transform.localPosition.y, 0);
            mouseangle = 270;
        }
        if (right == true)
        {
            spawitempos.transform.localPosition = new Vector3(1, spawitempos.transform.localPosition.y, 0);
            mouseangle = 90;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (inplayer.getEvent() == false)
        {
            mouseinput = Camera.main.WorldToScreenPoint(Input.mousePosition);
            backpackui.transform.position = Camera.main.WorldToScreenPoint(player.GetComponent<Transform>().position) + pos;
            CheckPosMouse();
            SetPosSpawn();
            if (firttime == 0) { showbackpack = !showbackpack; firttime = 1; }
            if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.R) && Input.anyKeyDown)
            {
                showbackpack = !showbackpack;
            }
            if (showbackpack == true)
            {
                backpackui.SetActive(true);

                ScrollItem();

                setimgobj();


            }
            else if (showbackpack == false)
            {
                backpackui.SetActive(false);
            }
            if (firttime == 1)
            {
                firttime = 2;
                showbackpack = !showbackpack;
            }
        }
    }
    void setimg(int i)
    {
        if (i < 0)
        {
            i = (inplayer.getItemSize() / 2) - size;
        }
        if (i > (inplayer.getItemSize() / 2) - size)
        {
            i = 0;
        }
                if (inplayer.getItem(i, 0) == 101)
                {
                            tempimg = img[0];
            choseitemslot = i;
                }
                if (inplayer.getItem(i, 0) == 102)
                {
            choseitemslot = i;
            tempimg = img[1];
                }
                if (inplayer.getItem(i, 0) == 103)
                {
            choseitemslot = i;
            tempimg = img[2];
                }
                if (inplayer.getItem(i, 0) == 104)
                {
            choseitemslot = i;
            tempimg = img[3];
                }
                if (inplayer.getItem(i, 0) == 105)
                {
            choseitemslot = i;
            tempimg = img[4];
                }
        if (inplayer.getItem(i, 0) == 0)
        {

            tempimg = img[5];
        }
      
        useitem = inplayer.getItem(i, 0);
    }
    void checkslot()
    {
        for(int i = 0; i <= (inplayer.getItemSize() / 2) - 1; i++)
        {
            if (inplayer.getItem(i, 1) <= 0)
            {
                inplayer.setItem(i, 0, 0);
            }
        }
    }
    void sort()
    {
        for (int i = 0; i < (inplayer.getItemSize() / 2) - 1; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                if (inplayer.getItem(i, 1) <= 0)
                {
                    tempid = inplayer.getItem(i, 0);
                    temp = inplayer.getItem(i, 1);
                    inplayer.setItem(i, 0, inplayer.getItem(i + 1, 0));
                    inplayer.setItem(i, 1, inplayer.getItem(i + 1, 1));

                        inplayer.setItem(i + 1, 0, tempid);
                        inplayer.setItem(i + 1, 1, temp);
                    
                }
            }
        }
    }
    void checkuseitem()
    {
        for (int i = 0; i < (inplayer.getItemSize() / 2)-1; i++)
        {

            if (Input.GetMouseButtonDown(1))
            {
                if (inplayer.getItem(i, 0) == useitem && choseitemslot == i)
                {

                    if (useitem == 101)
                    {
                        inplayer.setHP(inplayer.getHP() + 2);
                    }
                    if (useitem == 102 )
                    {
                        inplayer.setStamina(inplayer.getStamina() + 50);
                    }
                    if (useitem == 104)
                    {
                        SpawnDoll();
                    }
                    if (useitem == 105 && opentank == true)
                    {
                        inplayer.checkbox = "";
                        Destroy(door);
                    }
                    if (inplayer.getItem(i, 1) > 0)
                    {
                        if (useitem == 105 && opentank == true)
                        {
                            inplayer.setItem(i, 1, inplayer.getItem(i, 1) - 1);
                        }
                        if (useitem != 105 )
                        {
                            inplayer.setItem(i, 1, inplayer.getItem(i, 1) - 1);
                        }

                    }
                    
                }
            }
            if (inplayer.getItem(i, 0) == 0)
            {
                inplayer.setItem(i, 0, 0);
            }
        }
    }
    void setimgobj()
    {
        checkslot();
        sort();
        setimg(po-1);
        item[0].sprite = tempimg;
        setimg(po+1);
        item[2].sprite = tempimg;
        setimg(po);
       // settxt(po);
        checkuseitem();
        item[1].sprite = tempimg;
    }
    void ScrollItem()
    {
        if(Input.GetAxis("Mouse ScrollWheel")<0)
        { po -= 1;
            if (po < 0)
            {
                po = (inplayer.getItemSize() / 2) - size;
            }
           
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            po += 1;
            if (po > (inplayer.getItemSize() / 2) - size)
            {
                po = 0;
            }
        }
    }
    void SpawnDoll()
    {

        coutname++;
        GameObject clondoll = Instantiate(prefabdoll, spawitempos.transform.position,Quaternion.Euler(0, 0, 0))as GameObject;
        clondoll.name = clondoll.name + coutname;
    }
}
