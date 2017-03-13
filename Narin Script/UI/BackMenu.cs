using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class BackMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("backmenu",30);
	}
	void backmenu()
    {
        SceneManager.LoadScene("Menu");
    }
	// Update is called once per frame
	void Update () {
	
	}
}
