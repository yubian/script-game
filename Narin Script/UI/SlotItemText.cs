using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class SlotItemText : MonoBehaviour {
    public string textdata;
    public InfoSlotScript infoslot;
	// Use this for initialization
    public void onenter()
    {
      
    infoslot.Showtxt.text = textdata;
    }
    public void onexit()
    {
    infoslot.Showtxt.text= "";
    }
}
