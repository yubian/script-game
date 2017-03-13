using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class BadEnding : MonoBehaviour {
    public GameObject badenddeath;
    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void OnCollisionEnter(Collision en)
    {
        if (en.gameObject.tag == "Player")
        {
           
            badenddeath.SetActive(true);
            Invoke("goBadEnding", 2);
        }
    }
    void goBadEnding()
    {
        SceneManager.LoadScene("BadEnding");
    }
}
