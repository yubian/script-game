using UnityEngine;
using System.Collections;

public class TerrainSpawn : MonoBehaviour {
    public GameObject createprefabterrain;//don't change
    public GameObject createspawposterrain; //don't change
    public float sety=0;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void CreateTerrain()
    {
        GameObject cloneterrain = Instantiate(createprefabterrain, createspawposterrain.transform.position, Quaternion.Euler(new Vector3(0, sety, 0))) as GameObject;
    }
    void OnTriggerEnter(Collider player)
    {
        if(player.tag == "RadianCheckTerrain" )
        {
            CreateTerrain();
        }
    }
}
