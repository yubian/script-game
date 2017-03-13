using UnityEngine;
using System.Collections;

public class SpawnMiniEnemy : MonoBehaviour {
    public string NameEN;
    public GameObject enemypos;
    public GameObject enemyprefab;
    string tempname;
    float temptime;
    bool find = false;

    // Use this for initialization
    void Start () {
        CreateTerrain();

    }
    void CreateTerrain()
    {

        GameObject Enemy = Instantiate(enemyprefab,
            enemypos.transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
        Enemy.name = enemyprefab.name + NameEN+name;
        tempname = enemyprefab.name + NameEN+name ;
        temptime = 0;
    }
    // Update is called once per frame
    void Update () {
        if (find == false)
        {
            if (GameObject.Find(tempname) == null)
            {
                find = true;
            }
        }
        if (find == true)
        {
            temptime += Time.deltaTime;
            if (temptime / 60 > 1)
            {
                find = false;
                CreateTerrain();
            }
        }
	}
}
