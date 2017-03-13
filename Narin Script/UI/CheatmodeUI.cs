using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using PlayerCon;
public class CheatmodeUI : MonoBehaviour {
    Text txt;
    SpawnEnemyScript spaw;
	// Use this for initialization
	void Start () {
        txt = GetComponent<Text>();
        spaw =GameObject.FindGameObjectWithTag("SpawnEnemy"). GetComponent<SpawnEnemyScript>();

    }
	
	// Update is called once per frame
	void Update () {
        txt.text = "Time : " + spaw.gettime();
	}
}
