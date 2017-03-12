using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class ThornController : MonoBehaviour {
		bool playeron = false;
	public float[] settime;
	float time=3;
	float timecout=0;
	float timebrk=0.4f;
	float timecoutbrk=0;
	bool set1=true;
	bool set2=false;
	bool set3=false;
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (playeron == false) {
			anim.SetBool ("thorn",false);
		}
		if (playeron == true) {
			timecout += Time.deltaTime;
			if (time < timecout) {
				if (set1 == true) {
					anim.SetBool ("thorn", true);
					time = settime[1];
					timecout = 0;
					timecoutbrk = 0;
					set1 = false;
					set2 = true;
					set3 = false;
				

				}
				else if (set2 == true) {
					anim.SetBool ("thorn", true);
					time = settime[2];
					timecout = 0;
					timecoutbrk = 0;
					set1 = false;
					set2 = false;
					set3 = true;
				
				}
				else if (set3 == true) {
					anim.SetBool ("thorn", true);
					time = settime[0];
					timecout = 0;
					timecoutbrk = 0;
					set1 = true;
					set2 = false;
					set3 = false;

				}
			}
			timecoutbrk += Time.deltaTime;
			if (timebrk < timecoutbrk) {
				anim.SetBool ("thorn", false);
			}
		}
	}
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.name == "Player"){
			PlayerController.die = true;
		}
	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.name == "Player"){
			playeron = true;
		}
}
}
