using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class InfoSlotScript : MonoBehaviour {
    Text showtxt;
    public Text Showtxt
    {
        get
        {
            return showtxt;
        }

        set
        {
            showtxt = value;
        }
    }

    // Use this for initialization
    void Start () {
        showtxt = GetComponent<Text>();

    }
	
	// Update is called once per frame
}
