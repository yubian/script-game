using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class GroundUpController : MonoBehaviour {
	bool key=false;
	// Use this for initialization
	void Start () {
	
	}
	float up = 1.5f;
	// Update is called once per frame
	void Update () {
		if (Input.anyKey)
		{		key = true;
	}
		if (key == true) {

			gameObject.GetComponent<Transform> ().Translate (new Vector3 (0, up * Time.deltaTime, 0));
		}
	}
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.name == "Player"){
			SceneManager.LoadScene ("GameOver");
		}
	}
}
