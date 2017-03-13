using UnityEngine;
using System.Collections;
using PlayerCon;
using UnityEngine.SceneManagement;
public class CheatModeScript : MonoBehaviour {
    PlayerController player;
    SpawnEnemyScript spaw;

    bool txtbool = false;
	// Use this for initialization
	void Start () {
        player=GetComponent<PlayerController>();


        if (SceneManager.GetActiveScene().name == "Scene")
        {
        spaw = GameObject.FindGameObjectWithTag("SpawnEnemy").GetComponent<SpawnEnemyScript>();
            }

    }
	
	// Update is called once per frame
	void Update () {
        CheatMode();
    }
    void CheatMode()
    {
        if (Input.GetKeyDown(KeyCode.F1)|| Input.GetKeyDown(KeyCode.Alpha0))
        {
            txtbool = !txtbool;
            player.setCheatMode(!player.getCheatMode()) ;
        }
        if (player.getCheatMode() == true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                player.setHP(10);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                player.setStamina(30000f);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                spaw.settime(5000f);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                player.Itemslot[0] =true;
                player.Itemslot[1] = true;
                player.Itemslot[2] = true;
                player.Itemslot[3] = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                for(int i = 0; i < player.Itemslot.GetLength(0); i++)
                {
                    player.Itemslot[i] = true;
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                player.transform.position = new Vector3(120, 3.25f, -90);
            }
            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                player.transform.position = new Vector3(-256, 3.25f, 292);
            }
            if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                player.transform.position = new Vector3(-8.1f, 3.25f, 1065.4f);
            }
            if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                player.transform.position = new Vector3(698.8f, 3.25f, 489.4f);
            }
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                player.transform.position = new Vector3(208.1f, 3.25f, 485.1f);
            }

                }
    }

}
