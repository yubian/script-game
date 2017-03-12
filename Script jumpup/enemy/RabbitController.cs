using UnityEngine;
using System.Collections;

public class RabbitController : MonoBehaviour {
	public float leftmax;
	public float rightmax;
	public bool left;
	public bool right;
	public float time;
	float speed=5;
	public bool aweak=false;
	Animator anim;
	Vector3 ScaleCh;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		ScaleCh =gameObject.GetComponent<Transform> ().localScale;
	}
	
	// Update is called once per frame
	void Update () {
		if (aweak == false) {
			//anim.SetBool ("almosteat", true);
		}
		if (aweak == true) {
			anim.SetBool ("almosteat", false);
			anim.SetBool ("eat", true);
			if (GetComponent<Transform> ().position.x > rightmax) {
				speed = -5;
				right = false;
				left = true;
			}
			if (GetComponent<Transform> ().position.x < leftmax) {

				speed = 5;
				right = true;
				left = false;
			}
			Flip ();
			transform.Translate (speed* Time.deltaTime, 0, 0);
		}
	}
	void run(){
		aweak = true;
	}
	void almosteat(){
		anim.SetBool ("almosteat", true);
	}
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.name == "Player"){
			PlayerController.die = true;
		}
	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.name == "Player"){
			Invoke ("run", time);
			Invoke ("almosteat", time-1.0f);
		}
	}
	void Flip(){
		Vector3 Sca=gameObject.GetComponent<Transform>().localScale;
		if (left == true) {
			Sca.Set (ScaleCh.x, ScaleCh.y, ScaleCh.z);
			gameObject.GetComponent<Transform> ().localScale = Sca;
		}
		if (right == true) {
			Sca.Set (-ScaleCh.x, ScaleCh.y, ScaleCh.z);
			gameObject.GetComponent<Transform> ().localScale = Sca;
		}
	}
}
