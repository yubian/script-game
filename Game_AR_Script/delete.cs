using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	void del()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        //if (Input.touchCount > 0)//&& Input.GetTouch(0).phase == TouchPhase.Moved)
        //{
          //  Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
         //   RaycastHit hit;
        //    if (Physics.Raycast(ray, out hit, 100))
        //    {
        //        del();
        //    }
        //}
    }
    void OnMouseDown() {
        del();
    }

}
