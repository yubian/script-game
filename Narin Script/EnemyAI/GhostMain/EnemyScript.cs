using UnityEngine;
using System.Collections;
using PlayerCon;
public class EnemyScript : MonoBehaviour {
    RadianCheckEnemy rce;
    public GameObject name1;
    CameraMainScript main;
    public GameObject destoy;
    SpawnEnemyScript spaw;
    PlayerController player;
   Transform target;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    lightkill ligh;

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
            navMeshAgent.SetDestination(target.position);
        }
    }

    void OnCollisionEnter(Collision en)
    {
 
        if (en.gameObject.name == "Player" )
        {
            rce.setCheckSound(false);
            main.setNameBoss("");
            player.setHP(player.getHP() - player.getHP());
            spaw.settibo(false);
            main.setCBoss(false);
            main.setCKI(false);
            Destroy(destoy);
        }


    }
    void OnTriggerExit(Collider en)
    {

        if (en.tag == "Checkenemycam")
        {
            main.setNameBoss("");
            main.setCBoss(false);
        }
    }
    void OnTriggerEnter(Collider en)
    {
        if (en.tag == "Checkenemycam")
        {
            main.setNameBoss(gameObject.name);
            main.setCBoss(true);
        }
        if (en.tag == "Checkinsportlight")
        {

                rce.setCheckSound(false);
                main.setCKI(false);
                main.setNameBoss("");
                main.setCBoss(false);
                spaw.settibo(false);
                Destroy(destoy);
       
        }
    }
}
