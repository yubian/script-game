using UnityEngine;
using System.Collections;

public class FixSizeMenu : MonoBehaviour {
    public GameObject credit;
    public GameObject start;
    public GameObject exite;
	// Use this for initialization
	void Start () {
        if (Screen.width == 1280 && Screen.height == 1024)
        {
            credit.GetComponent<RectTransform>().anchoredPosition = new Vector2(100, 70);
            credit.GetComponent<RectTransform>().sizeDelta = new Vector2(140, 90);

            start.GetComponent<RectTransform>().anchoredPosition = new Vector2(340, 384);
            start.GetComponent<RectTransform>().sizeDelta = new Vector2(310,100);

            exite.GetComponent<RectTransform>().anchoredPosition = new Vector2(350, 259);
            exite.GetComponent<RectTransform>().sizeDelta = new Vector2(170, 100);
        }

        if (Screen.width == 1280 && Screen.height == 800)
        {
            credit.GetComponent<RectTransform>().anchoredPosition = new Vector2(100, 50);
            credit.GetComponent<RectTransform>().sizeDelta = new Vector2(140, 70);

            start.GetComponent<RectTransform>().anchoredPosition = new Vector2(340 ,300);
            start.GetComponent<RectTransform>().sizeDelta = new Vector2(310 ,80);

            exite.GetComponent<RectTransform>().anchoredPosition = new Vector2(350, 200);
            exite.GetComponent<RectTransform>().sizeDelta = new Vector2(170, 80);
        }

        if (Screen.width == 1024 && Screen.height == 768)
        {
            credit.GetComponent<RectTransform>().anchoredPosition = new Vector2(80, 50);
            credit.GetComponent<RectTransform>().sizeDelta = new Vector2(110, 70);

            start.GetComponent<RectTransform>().anchoredPosition = new Vector2(270, 280);
            start.GetComponent<RectTransform>().sizeDelta = new Vector2(250, 90);

            exite.GetComponent<RectTransform>().anchoredPosition = new Vector2(280, 200);
            exite.GetComponent<RectTransform>().sizeDelta = new Vector2(140, 80);
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
