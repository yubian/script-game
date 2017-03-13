using UnityEngine;
using System.Collections;

public class ghostjumpscary : MonoBehaviour {
    public GameObject jumpscary;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter(Collision en)
    {
        if (en.gameObject.tag == "Player")
        {
            Debug.Log("sss");
            jumpscary.SetActive(true);
        }
    }
        }
