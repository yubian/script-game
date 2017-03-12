using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class WinPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void win(){
		SceneManager.LoadScene ("Credit");
	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.name == "Player"){
			Invoke ("win", 1);
		}
	}
}
