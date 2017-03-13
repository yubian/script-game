using UnityEngine;
using System.Collections;

public class TerrainCheck : MonoBehaviour {
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerExit(Collider player) { 

        if (player.tag == "RadianCheckTerrain")
        {
            Destroy(this.gameObject);
        }
    }
}
