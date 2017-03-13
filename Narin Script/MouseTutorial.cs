using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MouseTutorial : MonoBehaviour {
    public string text;
    Text txt;
	// Use this for initialization
	void Start () {
        txt = GameObject.Find("Tutorial").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseOver()
    {
        txt.text = text;
        //mouse.setInItem(true);
    }
    void OnMouseExit()
    {
        txt.text = "";
        // mouse.setInItem(false);
    }
}
