using UnityEngine;
using System.Collections;

public class GroundController : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.name == "Player") {
			PlayerController.isground = true;
		}
	}
	void OnCollisionExit2D(Collision2D col){
		if (col.gameObject.name == "Player") {
			PlayerController.isground = false;
		}
	}
}
