using UnityEngine;
using System.Collections;
public class Itemcheckbox : MonoBehaviour {
    MouseController mouse;
    public GameObject destory;
	// Use this for initialization
	void Start () {
        mouse = GameObject.FindWithTag("Player").GetComponent<MouseController>();
        name = destory.name + 1;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseDown()
    {
        mouse.setDestory(destory.name);
    }
    void OnMouseOver()
    {
        //mouse.setInItem(true);
    }
    void OnMouseExit()
    {
       // mouse.setInItem(false);
    }
}
