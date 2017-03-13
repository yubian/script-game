using UnityEngine;
using System.Collections;

public class ClockSound : MonoBehaviour {
    AudioSource audioa;
    // Use this for initialization
    void Start () {
        audioa = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider en)
    {
        if (en.gameObject.name == "Player")
        {
            audioa.Play();
        }

    }
    void OnTriggerExit(Collider en)
    {
        if (en.gameObject.name == "Player")
        {
            audioa.Stop();
        }

    }
}
