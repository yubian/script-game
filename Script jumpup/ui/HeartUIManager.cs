﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HeartUIManager : MonoBehaviour {
	Text txt;
	// Use this for initialization
	void Start () {
		txt = gameObject.GetComponent<Text> ();
		DataSaveGame.heart = 5;
	}

	// Update is called once per frame
	void Update () {
		
		txt.text = "" + DataSaveGame.heart;
	}
}
