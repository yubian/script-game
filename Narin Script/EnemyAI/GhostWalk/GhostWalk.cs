using UnityEngine;
using System.Collections;
using PlayerCon;
    public class GhostWalk : MonoBehaviour
    {

    RadianCheckEnemy rce;
    public GameObject name1;
        CameraMainScript main;
        public GameObject destoy;
        SpawnEnemyScript spaw;
        PlayerController player;
        GameObject target;
        bool seeplayer = false;
        public GameObject[] targetnonplayer;
        private UnityEngine.AI.NavMeshAgent navMeshAgent;
        bool get1 = true;
        bool get2 = false;
        bool get3 = false;
        bool reget3 = false;
    public float minspeed;
    public float maxspeed;
        public bool getseeplayer()
        {
            return seeplayer;
        }
        void Awake()
        {
            target = GameObject.FindGameObjectWithTag("Player");
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
        public void setseeplayer(bool see)
        {
            seeplayer = see;
        }
        public GameObject getplay()
        {
            return target;
        }
        public bool gettarget1()
        {
            return get1;
        }
        public bool gettarget2()
        {
            return get2;
        }
        public bool gettarget3()
        {
            return get3;
        }
        public GameObject getgame1()
        {
            return targetnonplayer[0];
        }
        public GameObject getgame2()
        {
            return targetnonplayer[1];
        }
        public GameObject getgame3()
        {
            return targetnonplayer[2];
        }
        void Update()
        {
        if (player.getEvent() == false)
        {
            if (seeplayer == true)
            {
                navMeshAgent.speed = maxspeed;
                navMeshAgent.SetDestination(target.GetComponent<Transform>().position);
            }
            else
            {
                navMeshAgent.speed = minspeed;
                if (targetnonplayer[0].activeSelf == true)
                {
                    navMeshAgent.SetDestination(targetnonplayer[0].GetComponent<Transform>().position);

                }
                if (targetnonplayer[1].activeSelf == true)
                {
                    navMeshAgent.SetDestination(targetnonplayer[1].GetComponent<Transform>().position);

                }
                if (targetnonplayer[2].activeSelf == true)
                {
                    navMeshAgent.SetDestination(targetnonplayer[2].GetComponent<Transform>().position);

                }
            }
        }
        }

        void OnCollisionEnter(Collision en)
        {
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
            if (en.name == "target1")
            {
                targetnonplayer[1].SetActive(true);
                targetnonplayer[0].SetActive(false);
                targetnonplayer[2].SetActive(false);
                get1 = false;
                get2 = true;
                get3 = false;
                if (reget3 == true)
                {
                    reget3 = false;
                }
            }
            if (en.name == "target2")
            {
                if (reget3 == true)
                {
                    targetnonplayer[0].SetActive(true);
                    targetnonplayer[1].SetActive(false);
                    targetnonplayer[2].SetActive(false);
                    get2 = false;
                    get1 = true;
                    get3 = false;
                }
                else
                {
                    targetnonplayer[0].SetActive(false);
                    targetnonplayer[1].SetActive(false);
                    targetnonplayer[2].SetActive(true);
                    get2 = false;
                    get1 = false;
                    get3 = true;
                }

            }
            if (en.name == "target3")
            {
                targetnonplayer[0].SetActive(false);
                targetnonplayer[1].SetActive(true);
                targetnonplayer[2].SetActive(false);
                get2 = true;
                get1 = false;
                get3 = false;
                reget3 = true;

            }
        }
    }