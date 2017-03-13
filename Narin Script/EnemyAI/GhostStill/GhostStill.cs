using UnityEngine;
using System.Collections;
using PlayerCon;
    public class GhostStill : MonoBehaviour
    {
    RadianCheckEnemy rce;
        public GameObject name1;
        CameraMainScript main;
        bool ghostawake = false;
        public GameObject destoy;
        SpawnEnemyScript spaw;
        PlayerController player;
        Transform target;
    bool doll = false;
    Vector3 dollpos;
    bool oldpos=true;
    public GameObject oldposbox;
        private UnityEngine.AI.NavMeshAgent navMeshAgent;
    float timedelay;
    bool runtime = false;
    string nameitem;
    char[] charname;
    GameObject getitem;
    public void setNameItem(string s)
    {
        nameitem = s;
    }
    public void setDoll(bool dol)
    {
        doll = dol;
    }
    public void setPosDoll(Vector3 posdol)
    {
        dollpos = posdol;
    }
    public bool getGhostawake()
        {
            return ghostawake;
        }
        public void setGhostawake(bool set)
        {
            ghostawake = set;
        }
        void Awake()
        {
        
           target = GameObject.FindGameObjectWithTag("Player").transform;
            //playerHealth = player.GetComponent <PlayerHealth> ();
            //enemyHealth = GetComponent <EnemyHealth> ();
            navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        }
        void Start()
        {
       
       rce = GameObject.FindGameObjectWithTag("Checkenemycam").GetComponent<RadianCheckEnemy>();
            name = name1.name;
               main = GameObject.Find("MainCamera").GetComponent<CameraMainScript>();
            player = GameObject.Find("Player").GetComponent<PlayerController>();
            spaw = GameObject.FindGameObjectWithTag("SpawnEnemy").GetComponent<SpawnEnemyScript>();
        }

        void Update()
    {
        if (player.getEvent() == false)
        {
            if (runtime == false)
            {
                if (ghostawake == true && doll != true)
                {
                    navMeshAgent.SetDestination(target.position);
                }
                else if (doll == true)
                {
                    navMeshAgent.SetDestination(dollpos);
                }
                else
                {
                    if (oldpos == false)
                        navMeshAgent.SetDestination(oldposbox.transform.position);
                }
            }
            else if (runtime == true)
            {
                timedelay += Time.deltaTime;
                if (timedelay >= 3)
                {
                    timedelay = 0;
                    runtime = false;
                }
            }
        }
        }

        void OnCollisionEnter(Collision en)
    {
        if (en.gameObject.tag == "DollBear")
        {

           
           charname = nameitem.ToCharArray();
            nameitem = "";
            for (int i = 0; i < charname.Length; i++)
            {
                if (i == charname.Length - 1)
                {
                    charname[i] = ' ';
                }
                if(charname[i]!=' ')
                nameitem = nameitem + charname[i].ToString();

            }
            doll = false;
            runtime = true;
            Destroy(GameObject.Find(nameitem));
           
        }
            if (en.gameObject.name == "Player")
            {
            rce.setCheckSound(false);
                main.setCKI(false);
                main.setNameEnemy("");
                player.setHP(player.getHP() - player.getHP());
                Destroy(destoy);
            }

        }
    void OnTriggerExit(Collider en)
    {
        if (en.gameObject.name == oldposbox.name)
        {
            oldpos = false;
        }
    }
        void OnTriggerEnter(Collider en)
        {
        if (en.gameObject.name == oldposbox.name)
        { oldpos = true; }
            if (en.tag == "Checkinsportlight")
        {
            player.Checkenemyforanim = false;
            rce.setCheckSound(false);
            main.setCKI(false);
            main.setNameEnemy("");
            Destroy(destoy);
            }
        }
    }
