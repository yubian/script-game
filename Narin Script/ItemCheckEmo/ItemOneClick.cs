using UnityEngine;
using System.Collections;

public class ItemOneClick : MonoBehaviour {
    bool click = false;
    public void setclick(bool i)
    {
        click = i;
    }
    public bool getclick()
    {
        return click;
    }
	// Use this for initialization
}
