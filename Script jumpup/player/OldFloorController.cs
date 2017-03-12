using UnityEngine;
using System.Collections;

public class OldFloorController : MonoBehaviour {
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void des(){
		Destroy (gameObject);
	}
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.name == "Player") {
			anim.SetBool ("aweak", true);
			Invoke ("des", 3);
		}
	}
}
