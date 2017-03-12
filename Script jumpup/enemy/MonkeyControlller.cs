using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MonkeyControlller : MonoBehaviour {
	public GameObject Player;
	public GameObject spaw;
	public GameObject stoneleft;
	bool playeron = false;
	public float[] settime;
	float time=3;
	float timecout=0;
	float timebrk=0.60f;
	float timecoutbrk=0;
	float rotateset=45;
	bool set1=true;
	bool set2=false;
	bool set3=false;
	bool firt=true;
	bool top=false;
	bool bot=false;
	public bool right=true;
	public bool left=false;
	Vector3 ScaleCh;
	Animator anim;
	// Use this for initialization
	void Start () {
		ScaleCh =gameObject.GetComponent<Transform> ().localScale;
		anim = GetComponent<Animator> ();
	}
	void Createstone(){
			GameObject clonestone = Instantiate (stoneleft, spaw.transform.position,
                Quaternion.Euler (new Vector3 (0, 0, rotateset)))as GameObject;
			Destroy (clonestone, 1.75f);
	}
	// Update is called once per frame
	void Update () {
		Flip ();
		if (playeron == false) {
			anim.SetBool ("atk",false);
		}
		if (playeron == true) {
			timecout += Time.deltaTime;
			timecoutbrk += Time.deltaTime;
			for (;timebrk < timecoutbrk;) {
				timecoutbrk = 0;
				if (firt == false) {
					Createstone ();
				}
				anim.SetBool ("atk", false);
			}
			ChkPlayer ();
			if (right == true) {
				
				if (top == true) {
					StonAtk (225, 270, 180);
				}
				if (bot == true) {
					StonAtk (135, 180, 90);
				}
			}
			if (left == true) {
				
				if (top == true) {
					StonAtk (315, 270, 0);
				}
				if (bot == true) {
					StonAtk (45, 0, 90);
				}

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
	void ChkPlayer(){
		if (GetComponent<Transform> ().position.x < Player.GetComponent<Transform> ().position.x) {
			right = true;
			left = false;
		}
		if (GetComponent<Transform> ().position.x > Player.GetComponent<Transform> ().position.x) {
			right = false;
			left = true;
		}
			if (GetComponent<Transform> ().position.y < Player.GetComponent<Transform> ().position.y) {
				top = true;
				bot = false;
			}
			if (GetComponent<Transform> ().position.y > Player.GetComponent<Transform> ().position.y) {
				bot = true;
				top = false;
			}

	}
	void StonAtk(float set1rota,float set2rota,float set3rota){
		if (time < timecout) {
			timecoutbrk += Time.deltaTime;
			if (set1 == true) {
				anim.SetBool ("atk", true);
				time = settime [1];
				timecout = 0;
				timecoutbrk = 0;
				firt = false;
				set1 = false;
				set2 = true;
				set3 = false;
				rotateset = set1rota;
				//Createstone ();

			} else if (set2 == true) {
				anim.SetBool ("atk", true);
				time = settime [2];
				timecout = 0;
				timecoutbrk = 0;
				firt = false;
				set1 = false;
				set2 = false;
				set3 = true;
				rotateset = set2rota;
				//Createstone();
			}else if (set3 == true) {
				anim.SetBool ("atk", true);
				time = settime [0];
				timecout = 0;
				timecoutbrk = 0;
				firt = false;
				set1 = true;
				set2 = false;
				set3 = false;
				rotateset = set3rota;
				//Createstone();
			} 

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
