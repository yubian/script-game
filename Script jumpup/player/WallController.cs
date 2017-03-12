using UnityEngine;
using System.Collections;

public class WallController : MonoBehaviour {
	public GameObject player;
	public static bool staywall=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnTriggerStay2D(Collider2D col){
		if (col.gameObject.name == "Player") {

			PlayerController.jumpinwall = true;
			staywall = true;
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.name == "Player") {
			
			player.GetComponent<Rigidbody2D> ().gravityScale = 1;
			PlayerController.jumpinwall = false;
			staywall = false;
		}
	}
}
