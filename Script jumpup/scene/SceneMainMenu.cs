using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class SceneMainMenu : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Z)) {
			goLevel1 ();
		}
	}
	void des(){
		SceneManager.LoadScene ("Level1");
		Changetolevel1.p = true;
	}
	public void goTutorial(){
		SceneManager.LoadScene ("Tutorial");
	}
	public void goLevel1(){
		Changetolevel1.p = true;
		Invoke ("des", 2);
	}public void goCredit(){
		SceneManager.LoadScene ("Credit");
	}public void goExit(){
		Application.Quit();
	}



}
