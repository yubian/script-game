using UnityEngine;
using System.Collections;
namespace PlayerCon
{
    public class SpawnEnemyScript : MonoBehaviour
    {
        PlayerController player;
       public AudioSource soundghost;
        float time = 0.1f;
        bool tibo = false;
        public void settibo(bool to)
        {
            tibo = to;
        }
        public void settime(float k)
        {
            time = k;
        }
        public float gettime()
        {
            return time;
        }
        public GameObject[] enemypos;
        public GameObject enemyprefab;
        // Use this for initialization
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }
        void CreateTerrain(int i)
        {
            
            GameObject cloneterrain = Instantiate(enemyprefab, enemypos[i].transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            cloneterrain.name = "MainEnemy";
        }
        // Update is called once per frame
        void Update()
        {
            if (player.getEvent() == false&&player.Itemslot[0]==true)
            {
                if (tibo == false)
                {
                    time += Time.deltaTime;
                }
                if (time / 60 >= Random.Range(1, 1))
                {
                    tibo = true;
                    time = 0;
                    soundghost.Play();

                    CreateTerrain(Random.Range(0, enemypos.GetLength(0)));
                }
            }
        }
    }
}
