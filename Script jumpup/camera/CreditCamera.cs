using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class CreditCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Transform> ().position.y > -5.9) {
			transform.Translate (0, -1.75f * Time.deltaTime, 0);
		} else {
			Invoke ("end", 7);
		}
	}
	void end(){
		SceneManager.LoadScene ("MainMenu");
	}
}
