using UnityEngine;
using System.Collections;

public class HeartObjectController : MonoBehaviour {
	// Use this for initialization
	float ko;
	float speed=5;
	public AudioClip Clip;
	AudioSource audi;
	void Start () {
		audi = GetComponent<AudioSource> ();
		ko=GetComponent<Transform> ().position.y;
	}
	void des(){Destroy (gameObject);}
	// Update is called once per frame
	void Update () {
		if (GetComponent<Transform>().position.y > ko+0.5) {
			speed = -5;
		}
		if (GetComponent<Transform>().position.y < ko-0.5) {

			speed = 6;
		}
		transform.Translate (0, speed* Time.deltaTime, 0);
	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.name == "Player"){
				DataSaveGame.heart += 1;
			audi.PlayOneShot (Clip);
			Invoke ("des", 0.4f);
		}
	}
}
