using UnityEngine;
using System.Collections;

public class jumpscaryoff : MonoBehaviour {
    public GameObject jumpscary;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Invoke("offjumpscary", 1.5f);
	}
    void offjumpscary()
    {
        jumpscary.SetActive(false);
        Destroy(gameObject);
    }
}
