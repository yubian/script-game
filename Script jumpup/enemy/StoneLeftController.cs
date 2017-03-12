using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class StoneLeftController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (-20*Time.deltaTime,0,0);
	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.name == "Player"){
			PlayerController.die = true;
		}
	}
}