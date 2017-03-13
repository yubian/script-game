using UnityEngine;
using System.Collections;

public class OffSound : MonoBehaviour {
    public GameObject mainsound;
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
                mainsound.SetActive(false);
            
        }    
    }
     }
