﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Screen1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("goNext", 2);
	}
	
	// Update is called once per frame
	public void goNext(){
		SceneManager.LoadScene ("SplashScreen2");
	}
}
