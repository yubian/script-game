using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class GoodEnding : MonoBehaviour {
    public GameObject goodending;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider en)
    {
        if (en.tag == "Player")
        {
            Invoke("goGoodEnding", 1.5f);
            goodending.SetActive(true);
        }
    }
    void goGoodEnding()
    {
        SceneManager.LoadScene("GoodEnding");
    }
        }
