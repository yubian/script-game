using UnityEngine;
using System.Collections;

public class CoinManager : MonoBehaviour {
	AudioSource audi;
	public AudioClip coin;

	// Use this for initialization
	void Start () {
		audi = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	void des(){Destroy (gameObject);
		
	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.name == "Player"){
			DataSaveGame.score += 1;
			audi.PlayOneShot (coin);
			Invoke ("des",0.28f);

		}
	}
}
