using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using PlayerCon;

public class StaminaUI : MonoBehaviour
{
    public Slider slid;
	// Use this for initialization
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        
        slid.value = GameObject.Find("Player").GetComponent<PlayerController>().getStamina();
     
	}
}
