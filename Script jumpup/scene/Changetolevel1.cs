using UnityEngine;
using System.Collections;

public class Changetolevel1 : MonoBehaviour {

		Animator aud;
	public static bool p=false;
	// Use this for initialization
	void Start () {
		p=false;
		aud = GetComponent<Animator> ();
	}
	// Update is called once per frame
	void Update () {
		if (p == true) {
			aud.SetBool ("zaa", true);
		}
	}
}
