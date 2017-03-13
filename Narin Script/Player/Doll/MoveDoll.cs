using UnityEngine;
using System.Collections;

public class MoveDoll : MonoBehaviour {
   public GameObject doll;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position =new Vector3( doll.GetComponent<Transform>().position.x, doll.GetComponent<Transform>().position.y+1.5f
            , doll.GetComponent<Transform>().position.z);
    }
}
