using UnityEngine;
using System.Collections;

public class BirdController : MonoBehaviour {
	public float leftmax;
	public float rightmax;
	public bool left;
	public bool right;
	float time = 1;
	float timecout=0;
	float speed=5;
	Animator anim;
	Vector3 ScaleCh;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		ScaleCh =gameObject.GetComponent<Transform> ().localScale;
	}
	
	// Update is called once per frame
	void Update () {
		timecout += Time.deltaTime;
		anim.SetBool ("idle", true);
		if (time < timecout) {

			anim.SetBool ("idle", false);
			anim.SetBool ("run", true);
			if (GetComponent<Transform> ().position.x > rightmax) {
				speed = -30;
				right = false;
				left = true;
				timecout = 0;
			}
			if (GetComponent<Transform> ().position.x < leftmax) {

				speed = 30;
				right = true;
				left = false;
				timecout = 0;
			}
			Flip ();
			transform.Translate (speed * Time.deltaTime, 0, 0);
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
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.name == "Player"){
			PlayerController.die = true;
		}
	}
}
