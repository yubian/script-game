using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crows : MonoBehaviour {
    //public bool findtrack = false;
    // Use this for initialization
   public Animator anim;
    
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnMouseDown()
    {
        anim.SetBool("crowrun", true);
    }
}
