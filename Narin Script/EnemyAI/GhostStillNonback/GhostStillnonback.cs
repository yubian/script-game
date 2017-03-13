using UnityEngine;
using System.Collections;
using PlayerCon;
    public class GhostStillnonback : MonoBehaviour
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
        private UnityEngine.AI.NavMeshAgent navMeshAgent;
    float timedelay;
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
            player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
            spaw = GameObject.FindGameObjectWithTag("SpawnEnemy").GetComponent<SpawnEnemyScript>();
        }

    void Update()
    { if (player.getEvent() == false)
        {
            if (ghostawake == true && doll != true)
            {
                navMeshAgent.SetDestination(target.position);
            }
            else if (doll == true)
            {
                navMeshAgent.SetDestination(dollpos);
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
        void OnTriggerEnter(Collider en)
        {
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
