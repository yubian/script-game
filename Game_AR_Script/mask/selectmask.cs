using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectmask : MonoBehaviour {
    public GameObject allmask;
    public int selec = 0;
    public Vector3 pos;
    public int id = 0;
    public int idpos;
   // public int targetid;
    public bool lockpos = false;
    // Use this for initialization
    Vector3 oldscale;
	void Start () {
        oldscale = transform.localScale;
    }
	void OnMouseDown()
    {
        if (allmask.GetComponent<mask>().moveobj == false)
        {
            pos = transform.position;
            if (selec == 0)
            {
                allmask.GetComponent<mask>().obj.Add(gameObject.name);
                selec = 1;
            }
        }
    }
	// Update is called once per frame
	void Update () {
        if (id == idpos)
        {
            lockpos = true;
        }
        else { lockpos = false; }
        if (selec == 1)
        {
            transform.localScale = new Vector3( oldscale.x * 1.2f, oldscale.y * 1.2f, oldscale.z * 1.2f);
        }
        if (selec == 0)
        {
            transform.localScale = oldscale;
        }
	}
}
