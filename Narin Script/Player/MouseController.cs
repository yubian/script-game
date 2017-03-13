    using UnityEngine;
using System.Collections;
using PlayerCon;
using UnityEngine.UI;
public class MouseController : MonoBehaviour
{
    public GameObject posimg;
    Vector3 pos;
    public Sprite[] itemImImg;
    public Image itemimgshow;
    Onmouse ghosttalk;
    public Image textbox;
    public Text txt;
    ItemOneClick itemclick;
    PlayerController player;
    string nametalk;
    bool invoi = false;
    bool neer = false;
    float time = 0;
    float maxtime = 4;
    string destory;
    bool initem = false;//for mouseover item
    int choseitemforbackpack;
    bool talknpc;

    public bool Talknpc
    {
        get
        {
            return talknpc;
        }

        set
        {
            talknpc = value;
        }
    }

    public void setInItem(bool i)//for mouseover item
    {
        initem = i;

    }
    public bool getInItem()//for mouseover item
    {
        return initem;
    }
    public void setDestory(string des)
    {
        destory = des;
    }
    public void setMaxtime(float ma) {
        maxtime = ma;
    }
    public void setNear(bool s)
    {
        neer = s;
    }
    public void setNametalk(string r)
    {
        nametalk = r;
    }
    void Start()
    {
        pos = new Vector3(10, 70, 0);
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
        void Update()
    {
        if (player.getEvent() == false)
        {
            posimg.transform.position = Camera.main.WorldToScreenPoint(player.GetComponent<Transform>().position) + pos;
            if (invoi == true)
            {
                time += Time.deltaTime;

            }
            if (time > maxtime)
            {
                time = 0;
                textbox.enabled = false;
                txt.enabled = false;
                invoi = false;
            }
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool dithit = Physics.Raycast(ray, out hit, 100.0f);
            if (Input.GetMouseButtonDown(0))
            {
                if (dithit)
                {
                    if (hit.collider.gameObject.name == "clock" && player.getCheckbox() == "near")
                    {
                        player.SG.SetActive(true);
                    }

                    if (hit.collider.gameObject.name == "key21" && player.getCheckbox() == "near")
                    {
                        Checksprite(hit);
                        Invoke("oldImg", 2);
                        initem = false;
                        player.Itemslot[1] = true;
                        Destroy(GameObject.Find("key21"));
                    }
                    if (hit.collider.gameObject.name == "key11" && player.getCheckbox() == "near")
                    {
                        Checksprite(hit);
                        Invoke("oldImg", 2);
                        initem = false;
                        player.Itemslot[0] = true;
                        Destroy(GameObject.Find("key11"));
                    }
                    if (hit.collider.gameObject.name == "key31" && player.getCheckbox() == "near")
                    {
                        Checksprite(hit);
                        Invoke("oldImg", 2);
                        initem = false;
                        player.Itemslot[2] = true;
                        Destroy(GameObject.Find("key31"));
                    }
                    if (hit.collider.gameObject.name == "key41" && player.getCheckbox() == "near")
                    {
                        Checksprite(hit);
                        Invoke("oldImg", 2);
                        initem = false;
                        player.Itemslot[3] = true;
                        Destroy(GameObject.Find("key41"));
                    }
                  /*  if (hit.collider.gameObject.name == "Trap" && player.getCheckbox() == "near")
                    {
                        int chs = Random.Range(0, 4);
                        if (chs == 0)
                        {
                            findtrat(101);
                        }
                        else if (chs == 1)
                        {
                            findtrat(102);
                        }
                        else
                        {

                            player.setHP(player.getHP() - 1);
                        }
                    }*/
                    if (hit.collider.gameObject.name == nametalk && neer == true)
                    {
                        ghosttalk = GameObject.Find(nametalk).GetComponent<Onmouse>();
                        txt.text = ghosttalk.getTalk();
                        textbox.enabled = true;
                        txt.enabled = true;
                        invoi = true;
                    }
                    keepitem("PotionHP", 101, hit);
                    keepitem("DollBear", 104, hit);
                   // keepitem("KeyTank", 105, hit);
                    keepitemtoslot("KeyTank", 4, hit);
                    keepitemtoslot("KeyPublic", 5, hit);
                    keepitemtoslot("Food", 11, hit);
                    keepitemtoslot("Ball", 16, hit);
                    keepitemtoslot("Bone", 14, hit);
                    keepitemtoslot("Car", 8, hit);
                    keepitemtoslot("Doll", 18, hit);
                    keepitemtoslot("Glass", 13, hit);
                    keepitemtoslot("Paper", 9, hit);
                    keepitemtoslot("Pen", 12, hit);
                    keepitemtoslot("Photo", 10, hit);
                    keepitemtoslot("KeyTree", 6, hit);
                    keepitem("potionstamina", 102, hit);
                }
            }
        }
    }
    void Checksprite(RaycastHit hit)
    {
        if (hit.collider.gameObject.tag== "PotionHP")
        {
            itemimgshow.sprite = itemImImg[0];
        }
        if (hit.collider.gameObject.tag == "DollBear")
        {
            itemimgshow.sprite = itemImImg[2];
        }
        if (hit.collider.gameObject.tag == "KeyTank")
        {
            itemimgshow.sprite = itemImImg[3];
        }
        if (hit.collider.gameObject.tag == "MainKey")
        {
            itemimgshow.sprite = itemImImg[4];
        }
    }
    void fallatctive()
    {

    }
    void findtrat(int id)
    {
        int p = 0;
        for (int i = 0; i <= (player.getItemSize() / 2) - 1; i++)
        {
            if (player.getItem(i, 0) <= 0 && p == 0)
            {
                p = 1;
                player.setItem(i, 0, id);
                player.setItem(i, 1, 1);
            }
        }
        p = 0;
    }
    void keepitemtoslot(string name, int slot, RaycastHit hit)
    {
        if (hit.collider.gameObject.tag == name && player.getCheckbox() == "near")
        {
            Checksprite(hit);
        
 
                player.Itemslot[slot] = true;
                    initem = false;
                    Destroy(GameObject.Find(destory));
         


        }
    }
        void keepitem(string name,int id,RaycastHit hit) {
        if (hit.collider.gameObject.tag == name && player.getCheckbox() == "near")
        {
            Checksprite(hit);
            int p = 0;
            for (int i = 0; i <= (player.getItemSize() / 2) - 1; i++)
            {
                if (player.getItem(i, 0) <= 0 && p == 0)
                {
                    p = 1;
                    player.setItem(i, 0, id);
                    player.setItem(i, 1, 1);
                    initem=false;
                    Destroy(GameObject.Find(destory));
                }
            }
            p = 0;


        }
    }
}
