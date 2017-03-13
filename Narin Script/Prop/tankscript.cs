using UnityEngine;
using System.Collections;

public class tankscript : MonoBehaviour {
    public AudioSource bg;
    public AudioClip[] audi;
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
            bg.clip = audi[1];
            bg.Play();
        }
    }
    void OnTriggerExit(Collider en)
    {
        if (en.tag == "Player")
        {
            bg.clip = audi[0];
            bg.Play();
        }
    }
    }

