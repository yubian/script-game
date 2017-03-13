using UnityEngine;
using System.Collections;
using PlayerCon;
public class WordPass : MonoBehaviour {
    PlayerController play;
    public GameObject wordpass;
    public GameObject onoffkeyitemeffect;	// Use this for initialization
	void Start () {
        play = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.D)|| Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.S))
        {
            wordpass.SetActive(false);
        }
    }
    public void ClickKeyItem()
    {
            wordpass.SetActive(true);
        
    }
    public void ClickCloseWord()
    {
        wordpass.SetActive(false);
    }
    public void onenter()
    {

        onoffkeyitemeffect.SetActive(true);
    }
    public void onexit()
    {

        onoffkeyitemeffect.SetActive(false);
    }
}
