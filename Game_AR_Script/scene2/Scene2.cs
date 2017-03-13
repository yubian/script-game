using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2 : MonoBehaviour {
    // Use this for initialization
    bool checkclick=false;
    float time = 0;
    float intouch = 0;
    Animator anim;
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (checkclick == true)
        {
            time += Time.deltaTime;
            anim.SetBool("eye", true);
        }
        if (intouch > 0.3f&&time>0.3f)
        {
            anim.SetBool("close", true);
        }
     //   if (time > 0.25f)
     //   {
      //      time = 0;
      //         checkclick = false;
        //    anim.SetBool("eye", false);
     //   }
    }
    void OnMouseDown()
    {
                checkclick = true;
    }
    void OnMouseOver()
    {
        intouch += Time.deltaTime;
    }
    void OnMouseUp()
    {
        time = 0;
        checkclick = false;
        anim.SetBool("eye", false);
        anim.SetBool("close", false);
    }
    }
