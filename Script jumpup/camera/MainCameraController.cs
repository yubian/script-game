using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MainCameraController : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene ("MainMenu");
		}
		/*if(GetComponent<Camera>().transform.position.y<286){
		if (player.GetComponent<Transform> ().position.y > GetComponent<Transform> ().position.y+2) {
			transform.Translate (0, 10*Time.deltaTime, 0);
		}
		if (player.GetComponent<Transform> ().position.y < GetComponent<Transform> ().position.y-13) {
			transform.Translate (0, -10*Time.deltaTime, 0);
			}
		}*/
        if(player.transform.position.y>10)
        transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y,
            transform.position.z), new Vector3(transform.position.x,
            player.transform.position.y+2, transform.position.z), 2f);
	}
}
