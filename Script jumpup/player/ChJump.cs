using UnityEngine;
using System.Collections;

public class ChJump : MonoBehaviour {
	public GameObject player;
	public Vector3 pos;
	Vector3 oldpos;
	public static bool hide = true;
	// Use this for initialization
	void Start () {
		oldpos = GetComponent<RectTransform> ().position;
	}
	
	// Update is called once per frame
	void Update () {
		if (hide == false) {
			transform.position = Camera.main.WorldToScreenPoint (player.transform.position) + pos;
		}
		if (hide == true) {
			transform.position = Camera.main.WorldToScreenPoint (oldpos);
		}
	}
}
