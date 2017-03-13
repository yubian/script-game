using UnityEngine;
using System.Collections;
using PlayerCon;
    public class CameraMainScript : MonoBehaviour {
   

    PlayerController playstate;
    GameObject player;
    public Transform target;
    Vector3 playerpos;
    Vector3 oldposcenter;
    Vector3 oldposplayer;
    public float zpcamera = -40;
    Vector3 center;
    Transform findenemy;
    Transform eventCamtranform;
    string tempname;
    float smoot;
    float smootback;
    float speedcamera = 5f;
    float xp;
    float zp;
    float y = 0;
    float z = 0;
    float range = 4.5f;
    float x = 0;
    float rangerun = 5;
    float temptimekeyup = 0;
    bool checkin = false;
    bool up, down, left, right, spacebar = false;
    bool keyr = false;
    bool checkenemyin = false;
    bool leftshif = false;
    bool checkboss = false;
    string nameenemy;
    string nameboss;
    EventUI even;
    float timeevent = 0;
    float timeeventend = 0;
    int coutcam = 0;
    public void setNameBoss(string bo)
    {
        nameboss = bo;
    }
    public void setCBoss(bool c)
    {
        checkboss = c;
    }
    public void setCKI(bool k)
        {
            checkenemyin = k;
        }
        public void setNameEnemy(string name)
        {
            nameenemy = name;
        }
        void Start() {
            player = GameObject.Find("Player");
            playstate = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        even = GameObject.Find("Canvas").GetComponent<EventUI>();
        }

        // Update is called once per frame
        void Update()
        {
        //Debug.Log(coutcam);
        if (playstate.Dead1 == false)
        {
            if (playstate.getEvent() == false)
            {
                tempname = "";
                  coutcam = 0;
                   timeevent = 0;
                xp = player.transform.position.x;
                zp = player.transform.position.z;
                //playerpos = new Vector3(xp + 10, GetComponent<Transform>().position.y, zp + zpcamera);
                inputkey();
                movecamera();
                ZoomCamera();
                CheckEnemy();
            }
            else
            {
                xp = player.transform.position.x;
                zp = player.transform.position.z;
                if (coutcam < even.Posname.Count)
                {
                    if (even.Cammove[coutcam] == true)
                    {
                        if (tempname != even.Posname[coutcam].name)
                        {
                            tempname = even.Posname[coutcam].name;
                            eventCamtranform = GameObject.Find(even.Posname[coutcam].name).GetComponent<Transform>();
                        }
                        if (timeevent <= even.Camstartevent[coutcam])
                        {
                            timeevent += Time.deltaTime;
                        }
                        if (timeevent > even.Camstartevent[coutcam])
                        {

                            transform.position = Vector3.Lerp(GetComponent<Transform>().position, new Vector3
                            (eventCamtranform.position.x, transform.position.y, eventCamtranform.position.z + zpcamera), even.Cameraspeedevent[coutcam]);

                            if (timeeventend <= even.Camendevent[coutcam])
                            {
                                timeeventend += Time.deltaTime;

                            }
                            if (timeeventend > even.Camendevent[coutcam])
                            {
                                timeevent = 0;
                                timeeventend = 0;
                                even.Cammove[coutcam] = false; coutcam += 1;
                            }

                        }
                    }
                    else 
                    {
                        if (tempname != even.Posname[coutcam].name)
                        {
                            tempname = "Player";
                            eventCamtranform = GameObject.FindWithTag("Player").GetComponent<Transform>();
                        }
                        transform.position = Vector3.Lerp(GetComponent<Transform>().position, new Vector3(
                       eventCamtranform.position.x, transform.position.y, eventCamtranform.position.z + zpcamera), even.Cameraspeedevent[coutcam]);
                    }
                }
                else
                {
                    if (tempname != even.Posname[coutcam].name)
                    {
                        tempname = "Player";
                        eventCamtranform = GameObject.FindWithTag("Player").GetComponent<Transform>();
                    }

                    //coutcam = 0;
                    transform.position = Vector3.Lerp(GetComponent<Transform>().position, new Vector3(
                       eventCamtranform.position.x, transform.position.y, eventCamtranform.position.z + zpcamera), even.Speedcamback);

                    // transform.position = new Vector3(xp, GetComponent<Transform>().position.y, zp + zpcamera); 
                }
            }
        }else if (playstate.Dead1 == true)
        {
            if (Camera.main.GetComponent<Camera>().fieldOfView > 31.0f)
            {
                Camera.main.GetComponent<Camera>().fieldOfView -= 5 * Time.deltaTime;
            }
        }
    }
    void CheckEnemy()
    {
        if (checkboss == false)
        {
            if (checkenemyin == true)
            {
                if (nameenemy != null)
                {
                    checkin = true;
                    smootback = 0;

                    findenemy = GameObject.Find(nameenemy).GetComponent<Transform>();
                    center = ((findenemy.position - player.GetComponent<Transform>().position) / 2.0f) + player.GetComponent<Transform>().position;
                    smoot += Time.deltaTime * 1f;
                    transform.position = Vector3.Lerp(GetComponent<Transform>().position, new Vector3(center.x, transform.position.y, center.z + zpcamera), smoot);
                }
            }
            else if (checkenemyin == false)
            {
                smoot = 0;
                if (checkin == true)
                {
                    smootback += Time.deltaTime * 1f;
                    transform.position = Vector3.Lerp(new Vector3(center.x, transform.position.y, center.z + zpcamera), oldposplayer, smootback);
                }
            }
        }
        else
        {
            if (checkenemyin == true)
            {
                if (nameboss != null)
                {
                    checkin = true;
                    smootback = 0;
                    findenemy = GameObject.Find(nameboss).GetComponent<Transform>();
                    center = ((findenemy.position - player.GetComponent<Transform>().position) / 2.0f) + player.GetComponent<Transform>().position;
                    smoot += Time.deltaTime * 1.5f;
                    transform.position = Vector3.Lerp(GetComponent<Transform>().position, new Vector3(center.x, transform.position.y, center.z + zpcamera), smoot);
                }
            }
            else if (checkenemyin == false)
            {
                smoot = 0;
                if (checkin == true)
                {
                    smootback += Time.deltaTime * 1.5f;
                    transform.position = Vector3.Lerp(new Vector3(center.x, transform.position.y, center.z + zpcamera), oldposplayer, smootback);
                }
            }
        }
    }
    void ZoomCamera()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            leftshif = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            leftshif = false;
        }
        if (leftshif == true)
        {
            if (Camera.main.GetComponent<Camera>().fieldOfView < 43.0f)
            {
                Camera.main.GetComponent<Camera>().fieldOfView += 11 * Time.deltaTime;
            }
            if (Camera.main.GetComponent<Camera>().fieldOfView < 45.0f)
            {
                Camera.main.GetComponent<Camera>().fieldOfView += 10 * Time.deltaTime;
            }
        }
        if (leftshif == false)
        {
            if (Camera.main.GetComponent<Camera>().fieldOfView > 39.0f)
            {
                Camera.main.GetComponent<Camera>().fieldOfView -= 6 * Time.deltaTime;
            }
            if (Camera.main.GetComponent<Camera>().fieldOfView > 37.0f)
            {
                Camera.main.GetComponent<Camera>().fieldOfView -= 5 * Time.deltaTime;
            }
        }
        
    }
        void inputkey()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                keyr = !keyr;
            }
            if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            {
               
                down = false;
                up = true;
                if (!Input.GetKey(KeyCode.A))
                {

                    left = false;
                }
                if (!Input.GetKey(KeyCode.D))
                {
                    right = false;
                }
                temptimekeyup = 0;

            }

            if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
            {

                if (!Input.GetKey(KeyCode.A))
                {
                    left = false;
                }
                if (!Input.GetKey(KeyCode.D))
                {
                    right = false;
                }
                temptimekeyup = 0;
                up = false;
                down = true;

            }
            if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                right = false;
                left = true;
                if (!Input.GetKey(KeyCode.W))
                {

                    up = false;
                }
                if (!Input.GetKey(KeyCode.S))
                {
                    down = false;
                }
                temptimekeyup = 0;


            }
            if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            {

                temptimekeyup = 0;
                if (!Input.GetKey(KeyCode.W))
                {
                    up = false;
                }
                if (!Input.GetKey(KeyCode.S))
                {
                    down = false;
                }
                left = false;
                right = true;

            }
            if (Input.GetKey(KeyCode.Space) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
            {
                temptimekeyup = 0;
                spacebar = true;

            }
            if (Input.GetKeyUp(KeyCode.Space))
            {

                spacebar = false;

            }
            else if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                invokekeyup();
            }
        }
        void invokekeyup()
        {
            temptimekeyup += Time.deltaTime;
            if (temptimekeyup >= 3)
            {
                temptimekeyup = 0;
                up = false;
                down = false;
                left = false;
                right = false;
                spacebar = false;
            }

        }
        void movecamera()
        {
          //  if (spacebar == false || playstate.getStamina() == 0)
           // {


                if (z < range)
                {
                    if (up == true && down == false)//upcamera
                    {
                        if (left == false && right == false)
                        {
                            if (x > 0 + 0.25) x -= (speedcamera ) * Time.deltaTime;
                            if (x < 0 - 0.25) x += (speedcamera ) * Time.deltaTime;
                    if (x > 0 ) x -= (speedcamera/3) * Time.deltaTime;
                    if (x < 0 ) x += (speedcamera/3) * Time.deltaTime;
                }
                        if (z < range-1f)
                            z += (speedcamera*2) * Time.deltaTime;
                if (z > range-1f)
                    z += (speedcamera/2) * Time.deltaTime;
                if (z > range)
                            z -= (speedcamera/2) * Time.deltaTime;//z = range;
                    }


                }
                else if (z > 0)
                {
                    z -= speedcamera * Time.deltaTime;
                }
                if (z > -range)
                {
                    if (down == true && up == false)//downcamera
                    {
                        if (z > -range+ 1f)
                            z -= (speedcamera * 2) * Time.deltaTime;
                if (z < -range+ 1f)
                    z -= (speedcamera / 2) * Time.deltaTime;
                if (z < -range) z += (speedcamera / 2) * Time.deltaTime;//z = (-range);
                        if (left == false && right == false)
                        {

                    if (x > 0 + 0.25) x -= (speedcamera) * Time.deltaTime;
                    if (x < 0 - 0.25) x += (speedcamera) * Time.deltaTime;
                    if (x > 0) x -= (speedcamera / 3) * Time.deltaTime;
                    if (x < 0) x += (speedcamera / 3) * Time.deltaTime;
                }
                    }
                }
                else if (z < 0)
                {
                    z += speedcamera * Time.deltaTime;
                }
                if (x < range)
                {
                    if (right == true && left == false)//rightcamera
                    {
                        if (x < range- 1f)
                            x += (speedcamera * 2) * Time.deltaTime;
                if (x > range - 1f)
                    x += (speedcamera / 2) * Time.deltaTime;
                if (x > range) x -= (speedcamera / 2) * Time.deltaTime;//x = range;
                        if (up == false && down == false)
                        {
                    if (z > 0 + 0.25) z -= (speedcamera) * Time.deltaTime;
                    if (z < 0 - 0.25) z += (speedcamera) * Time.deltaTime;
                    if (z > 0) z -= (speedcamera / 3) * Time.deltaTime;
                    if (z < 0) z += (speedcamera / 3) * Time.deltaTime;
                }
                    }
                }
                else if (x > 0)
                {
                    x -= speedcamera * Time.deltaTime;
                }
                if (x > -range)
                {
                    if (left == true && right == false)//leftcamera
                    {
                        if (x > -range+ 1f)
                            x -= (speedcamera * 2) * Time.deltaTime;
                if (x < -range+ 1f)
                    x -= (speedcamera / 2) * Time.deltaTime;
                if (x < -range) x += (speedcamera / 2) * Time.deltaTime;//x = (-range);
                        if (up == false && down == false)
                        {
                    if (z > 0 + 0.25) z -= (speedcamera) * Time.deltaTime;
                    if (z < 0 - 0.25) z += (speedcamera) * Time.deltaTime;
                    if (z > 0) z -= (speedcamera / 3) * Time.deltaTime;
                    if (z < 0) z += (speedcamera / 3) * Time.deltaTime;
                }
                    }
                }
                else if (x < 0)
                {
                    x += speedcamera * Time.deltaTime;
                }

            if (up == false && down == false && left == false && right == false)
            {
                if (z > 0) z -= 5 * Time.deltaTime;
                if (z < 0) z += 5 * Time.deltaTime;
                if (x > 0) x -= 5 * Time.deltaTime;
                if (x < 0) x += 5 * Time.deltaTime;
            }

            transform.position =new Vector3(xp + x, GetComponent<Transform>().position.y + y, zp + zpcamera + z);
        oldposplayer= new Vector3(xp + x, GetComponent<Transform>().position.y + y, zp + zpcamera + z);
    }
}
// }

//for runnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn
//
/*    if (spacebar == true&&playstate.getStamina()>0)
    {
        if (up == true && down == false)//upcamera
        {
            if(z<range*2.5)
            z += (speedcamera+20) * Time.deltaTime;
            if (z > range * rangerun) z -= speedcamera * Time.deltaTime;//z = range * rangerun;
            if (left == false && right == false)
            {
                if (x > 0) x -= (speedcamera + 20) * Time.deltaTime;
                if (x < 0) x += (speedcamera + 20) * Time.deltaTime;
            }

        }
        if (down == true && up == false)//downcamera
        {
            if (z > -range * 2.5)
                z -= (speedcamera + 20) * Time.deltaTime;
            if (z < -range * (rangerun-1)) z += speedcamera * Time.deltaTime;//z = (-range * (rangerun-1));
            if (left == false && right == false)
            {
                if (x > 0) x -= (speedcamera + 20) * Time.deltaTime;
                if (x < 0) x += (speedcamera + 20) * Time.deltaTime;
            }
        }
        if (right == true && left == false)//rightcamera
        {
            if (x < range * 2.5)
                x += (speedcamera + 20) * Time.deltaTime;
            if (x > range * rangerun)
                x -= speedcamera * Time.deltaTime;//x = range * rangerun;
            if (up == false && down == false)
            {
                if (z > 0)
                    z -= (speedcamera + 20) * Time.deltaTime;
                if (z < 0)
                    z += (speedcamera + 20) * Time.deltaTime;
            }
        }
        if (left == true && right == false)//leftcamera
        {
            if (x > -range * 2.5)
                x -= (speedcamera + 20) * Time.deltaTime;
            if (x < -range * rangerun) x += speedcamera * Time.deltaTime;//x = (-range * rangerun);
            if (up == false && down == false)
            {
                if (z > 0)
                    z -= (speedcamera + 20) * Time.deltaTime;
                if (z < 0)
                    z += (speedcamera + 20) * Time.deltaTime;
            }
        }
    }
    */
//end run
