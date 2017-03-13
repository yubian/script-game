using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
namespace PlayerCon
{
    public class PlayerController : PlayerStatus
    { int count = 0;
        int countrun=0;
        public GameObject deadui;
        private Transform temppositionevent;
        bool inscenf = false;
        public GameObject[] sweat;
        bool enemyincamera = false;
        public GameObject mapui;
        public GameObject[] childmapui;
        public GameObject[] ui;
        bool map = false;
        bool dead = false;
        bool runcheck = false;
        public GameObject[] Anim;
        public GameObject[] cameraset;
        public float speedrun = 2.5f;
        float totalstamina = 0;
        bool left = true;
        bool right = false;
        bool up = false;
        bool down = false;
        bool runone = false;
        Transform temppostevent;
        public GameObject sportligh;
        bool stopmove;
        List<string> namemoveevent;
        List<float> movespeedevent;
        public GameObject SG;
        List<float> staymove;
        float Entimetemp = 0;
        bool checkenemyforanim = false;
        public float Entimetemp1
        {
            get
            {
                return Entimetemp;
            }

            set
            {
                Entimetemp = value;
            }
        }

        public bool Runone
        {
            get
            {
                return runone;
            }

            set
            {
                runone = value;
            }
        }

        public bool Checkenemyforanim
        {
            get
            {
                return checkenemyforanim;
            }

            set
            {
                checkenemyforanim = value;
            }
        }

        public bool Dead1
        {
            get
            {
                return dead;
            }

            set
            {
                dead = value;
            }
        }

        public void setStaymove(float t)
        {
            staymove.Add(t);
        }
        public void setcountrun(int t)
        {
            countrun = t;
        }
        public int getcountrun()
        {
            return countrun;
        }
        public void setstopmove(bool s)
        {
            stopmove = s;
        }
        public bool getstopmove()
        {
            return stopmove;
        }
        public void setMoveSpeedEvent(float s)
        {
            movespeedevent.Add(s);
        }
        public int getCount()
        {
            return count;
        }
        public void setCount(int s)
        {
            count = s;
        }
        public void setNameMoveEvent(string s)
        {
            namemoveevent.Add(s);
        }
        public bool getLeft()
        {
            return left;
        }
        public bool getRight()
        {
            return right;
        }
        void Start()

        {
            deadui.SetActive(true);
            staymove = new List<float>();
                  movespeedevent = new List<float>();
                  namemoveevent = new List<string>();
            if (SceneManager.GetActiveScene().name== "FirstScene")
            {
                inscenf = true;
            }
            if (SceneManager.GetActiveScene().name == "Scene")
            {
                inscenf = false;
            }
            deadui.SetActive(false);
            //mapui = GameObject.FindGameObjectWithTag("MAPUI");

        }
        void Update()
        {         
            if (Dead1 != true)
            {
                if (getEvent() == false)
                {
                    if (Runone == true)
                    {
                        staymove.Clear();
                        count = 0;
                        countrun = 0;
                        movespeedevent.Clear();
                        namemoveevent.Clear();
                        Runone = false;
                    }
                    OpenMap();
                    Movement();
                }
                else
                {
                    if (countrun == 2)
                    {
                        setEvent(false);
                    }
                    if (stopmove == true)
                    {
                        setIdleEvent();
                    }
                    if (stopmove== false)
                    { 
                        temppositionevent = transform;
                        if (count < namemoveevent.Count && count != namemoveevent.Count)
                        {
                            if (Entimetemp <= staymove[count])
                            {
                                Entimetemp += Time.deltaTime;
                                setIdleEvent();
                            }
                            if (Entimetemp > staymove[count])
                            {
                                temppostevent = GameObject.Find(namemoveevent[count]).GetComponent<Transform>();
                                transform.position = Vector3.MoveTowards(GetComponent<Transform>().position,
                                    temppostevent.position, movespeedevent[count]);
                                MovementEvent();
                            }
                        }
                        if (count == namemoveevent.Count)
                        {
                            countrun++;

                            Runone = true;
                            stopmove = true;
                            setIdleEvent();
                            
                        }

                    }
                }
            }
            Dead();
        }
        void setIdleEvent()
        {
            if (left == true)
            {
                setAnim(0);
            }
            if (right == true)
            {
                setAnim(3);
            }
            if (up == true)
            {
                setAnim(9);
            }
            if (down == true)
            {
                setAnim(6);
            }

        }
        void MovementEvent()
        {
          
            if (transform.position.x> temppostevent.position.x &&
                (transform.position.z < temppostevent.position.z + 13 &&
                transform.position.z > temppostevent.position.z - 13))
            {
                up = false;
                left = true;
                right = false;
                down = false;
            }
            if (transform.position.x < temppostevent.position.x &&
                (transform.position.z < temppostevent.position.z + 13 &&
                transform.position.z > temppostevent.position.z - 13))
            {
                up = false;
                left = false;
                right = true;
                down = false;
            }
            if (transform.position.z < temppostevent.position.z&& 
                (transform.position.x < temppostevent.position.x+3&&
                transform.position.x > temppostevent.position.x-3))
            {
                up = true;
                left = false;
                right = false;
                down = false;
            }
            if (transform.position.z > temppostevent.position.z && 
                (transform.position.x < temppostevent.position.x + 3 &&
                transform.position.x > temppostevent.position.x - 3))
            {
                up = false;
                left = false;
                right = false;
                down = true;
            }
            if (left == true)
                setAnim(1);
            if (right == true)
                setAnim(4);
            if (up == true)
                setAnim(10);
            if (down == true)
                setAnim(7);
        }
        void Movement()
        {

            totalstamina = getStamina();
            float run = 14f;
            float walkx = Input.GetAxis("Horizontal");
            float walkz = Input.GetAxis("Vertical");
            if (runcheck == false)
            {
                if (left == true)
                {
                    setAnim(0);
                }
                if (right == true)
                {
                    setAnim(3);
                }
                if (up == true)
                {
                    setAnim(9);
                }
                if (down == true)
                {
                    setAnim(6);
                }

            }
            if (Input.GetKey(KeyCode.LeftShift) && runcheck == true && !Input.GetKey(KeyCode.Space))
            {


                run = run * (speedrun / 4);

            }
            if (inscenf == false)
            {
                if (Input.GetKey(KeyCode.Space) && runcheck == true && !Input.GetKey(KeyCode.LeftShift))
                {

                    totalstamina -= Time.deltaTime * 20;
                    setStamina(totalstamina);
                    if (getStamina() > 0)
                    {
                        if (left == true||up==true)
                        {
                            if (getStamina() < 50)
                            {
                                sweat[0].SetActive(true);
                            }
                        }
                        else { sweat[0].SetActive(false); }

                        if (right == true||down==true)
                        {
                            if (getStamina() < 50)
                            {
                                sweat[1].SetActive(true);
                            }
                        }
                        else { sweat[1].SetActive(false); }
                        if (left == true)
                        {

                            setAnim(2);
                        }
                        if (right == true)
                        {

                            setAnim(5);
                        }
                        if (up == true)
                        {

                            setAnim(11);
                        }
                        if (down == true)
                        {

                            setAnim(8);
                        }
                        run = run * speedrun;
                    }
                    if (getStamina() < 0)
                    {
                        if (left == true)
                            setAnim(1);
                        if (right == true)
                            setAnim(4);
                        if (up == true)
                            setAnim(10);
                        if (down == true)
                            setAnim(7);
                        setStamina(0);
                    }
                }

                else
                {
                    if (getStamina() <= 0)
                    {
                        DelayStamina();
                    }
                    else
                    {
                        StaminaRegen();
                    }
                    if (getStamina() <= 50)
                    {
                        if (left == true)
                        {
                            sweat[0].SetActive(true);
                        }
                        else { sweat[0].SetActive(false); }
                        if (right == true)
                        {
                            sweat[1].SetActive(true);
                        }
                        else { sweat[1].SetActive(false); }
                    }
                }
                if (getStamina() > 50)
                {

                    sweat[0].SetActive(false);
                    sweat[1].SetActive(false);
                }
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
                {
                    runcheck = true;
                }

                if (runcheck == true)
                {
                if (((Input.GetKey(KeyCode.W)) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)
                        ) && !Input.GetKey(KeyCode.Space))
                {
                    if (left == true)
                        setAnim(1);
                    if (right == true)
                        setAnim(4);
                    if (up == true)
                        setAnim(10);
                    if (down == true)
                        setAnim(7);
                }
                if ((Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) 
                    || (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
                    || (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                    || (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A)))
                {
                    
                    if ((Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)))
                    {
                        up = true;
                        down = false;
                        right = false;
                        left = false;
                       
                    }
                    if ((Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W)))
                    {
                        up = false;
                        down = true;
                        right = false;
                        left = false;
                      
                    }
                    if ((Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A)))
                    {
                        right = true;
                        left = false;
                        up = false;
                        down = false;

                    }
                    if ((Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)))
                    {
                        left = true;
                        right = false;
                        up = false;
                        down = false;

                    }
                    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                        {
                            walkz = walkz / 1.5f;
                        }
                        transform.Translate(0, 0, walkz * run * Time.deltaTime);
                    }



                if ( (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A)))
                {  
                    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
                    {
                        walkx = walkx / 1.5f;
                    }
                    transform.Translate(walkx * run * Time.deltaTime, 0, 0);
                }
                if ((Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) )
                    { 
                        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
                        {
                            walkx = walkx / 1.5f;
                        }
                        transform.Translate(walkx * run * Time.deltaTime, 0, 0);
                    }


                    if (getStamina() > getMaxstamina())
                    {
                        if (getCheatMode() == false)
                            setStamina(getMaxstamina());
                    }
                }
                if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W))
                {
                    runcheck = false;
                }
            

        }
        void StaminaRegen()
        {
            totalstamina += Time.deltaTime * 15;
            setStamina(totalstamina);
        }
        void DelayStamina()
        {
            Invoke("StaminaRegen", 2);
        }
        void OnCollisionEnter(Collision en)
        {
            //keyitem
            //^keyitem
        }
        void OnCollisionExit(Collision en)
        {
            Invoke("DelayCollideron", 3);
        }
        void Dead()
        {
            if (getHP() <= 0)
            {
                setHP(0);
                Dead1 = true;
                setAnim(0);
                Invoke("runanimdeathui", 0);
                Invoke("goGameoverdelay", 3.0f);
                //Destroy(this.gameObject, 1f);
            }

        }
        void runanimdeathui()
        {
            deadui.SetActive(true);
        }
        void goGameoverdelay()
        {
            SceneManager.LoadScene("GameOver");
        }
        void setAnim(int i)
        {
            for(int k = 0; k < Anim.Length; k++)
            {
                if(k==i)
                {
                    Anim[k].SetActive(true);
                }
                else
                {
                    Anim[k].SetActive(false);
                }
            }
        }
        void OpenMap()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                if (Itemslot[0] == true)
                {
                    childmapui[0].SetActive(true);
                }
                if (map == false)
                {
                    map = true;
                    ui[0].SetActive(false);
                    ui[1].SetActive(false);
                    mapui.SetActive(true);
                }
               else if (map == true)
                {
                    map = false;
                    ui[0].SetActive(true);
                    ui[1].SetActive(true);
                    mapui.SetActive(false);
                }
            }
        }

        public bool getenemyincamera()
        {
            return enemyincamera;
        }
        public void setenemyincamera(bool set)
        {
             enemyincamera=set;
        }
        //class
    }
        //namespace
    }