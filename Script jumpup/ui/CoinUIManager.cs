using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoinUIManager : MonoBehaviour {
	Text txt;
	// Use this for initialization
	void Start () {
		DataSaveGame.score = 0;
		txt = gameObject.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		txt.text = "" + DataSaveGame.score;
	}
}
