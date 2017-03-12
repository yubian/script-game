using UnityEngine;
using System.Collections;

public class ChkForFlootWall2 : MonoBehaviour {
	public GameObject flootwall2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.name == "Player") {
			WallController.staywall = false;
			flootwall2.GetComponent<BoxCollider2D> ().enabled=true;
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.name == "Player") {
			flootwall2.GetComponent<BoxCollider2D> ().enabled = false;
		}
	}
}
