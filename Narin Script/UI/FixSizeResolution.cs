using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class FixSizeResolution : MonoBehaviour {
    // Use this for initialization
   public Image[] img;
    public GameObject faceui;
    public GameObject keyitem;
    public GameObject map;
	void Start () {
        fixsizeresolution();
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void fixsizeresolution()
    {
        if (Screen.width == 1920 && Screen.height == 1080)
        {
            //itemslot
            img[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(-70, 60);
            img[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(-90, 10);
            img[2].GetComponent<RectTransform>().anchoredPosition = new Vector2(-70, -40);
            img[0].GetComponent<RectTransform>().sizeDelta = new Vector2(25, 25);
            img[1].GetComponent<RectTransform>().sizeDelta = new Vector2(60, 60);
            img[2].GetComponent<RectTransform>().sizeDelta = new Vector2(25, 25);
            //end itemslot
            //emotion
            //emo.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 60);
            //emo.GetComponent<RectTransform>().sizeDelta = new Vector2(70, 70);
            //end emotion
            //face
            faceui.GetComponent<RectTransform>().anchoredPosition = new Vector2(1400, 800);
            faceui.GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 1);
            //end face
            //keyitem
          //  keyitem.GetComponent<RectTransform>().anchoredPosition = new Vector2(-150, -90);
          //  keyitem.GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 1);
            //endkeyitem
            //mapui
            map.GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 1);
            //endmapui
        }

        if (Screen.width == 1600 && Screen.height == 900)
        {
            //itemslot
            img[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(-65, 48);
            img[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(-78, 8);
            img[2].GetComponent<RectTransform>().anchoredPosition = new Vector2(-65, -32);
            img[0].GetComponent<RectTransform>().sizeDelta = new Vector2(20, 20);
            img[1].GetComponent<RectTransform>().sizeDelta = new Vector2(48, 48);
            img[2].GetComponent<RectTransform>().sizeDelta = new Vector2(20, 20);
            //end itemslot
            //emotion
            //emo.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 36);
           // emo.GetComponent<RectTransform>().sizeDelta = new Vector2(56, 56);
            //end emotion
            //face
            faceui.GetComponent<RectTransform>().anchoredPosition = new Vector2(1120, 640);
            faceui.GetComponent<RectTransform>().localScale = new Vector3(1.2f, 1.2f, 1);
            //end face
            //keyitem
          //  keyitem.GetComponent<RectTransform>().anchoredPosition = new Vector2(-120, -72);
           // keyitem.GetComponent<RectTransform>().localScale = new Vector3(1.2f, 1.2f, 1);
            //endkeyitem
            //mapui
            map.GetComponent<RectTransform>().localScale = new Vector3(1.2f, 1.2f, 1);
            //endmapui
        }

        if (Screen.width == 1440 && Screen.height == 900)
        {
            //itemslot
            img[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(-65, 48);
            img[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(-78, 8);
            img[2].GetComponent<RectTransform>().anchoredPosition = new Vector2(-65, -32);
            img[0].GetComponent<RectTransform>().sizeDelta = new Vector2(20, 20);
            img[1].GetComponent<RectTransform>().sizeDelta = new Vector2(48, 48);
            img[2].GetComponent<RectTransform>().sizeDelta = new Vector2(20, 20);
            //end itemslot
            //emotion
            //emo.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 36);
           // emo.GetComponent<RectTransform>().sizeDelta = new Vector2(56, 56);
            //end emotion
            //face
            faceui.GetComponent<RectTransform>().anchoredPosition = new Vector2(1030, 640);
            faceui.GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.2f, 1);
            //end face
            //keyitem
          //  keyitem.GetComponent<RectTransform>().anchoredPosition = new Vector2(-108, -72);
          //  keyitem.GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.2f, 1);
            //endkeyitem
            //mapui
            map.GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.2f, 1);
            //endmapui
        }

        if (Screen.width == 1360 && Screen.height == 768)
        {
            //itemslot
            img[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(-52, 41);
            img[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(-66, 7);
            img[2].GetComponent<RectTransform>().anchoredPosition = new Vector2(-52, -27);
            img[0].GetComponent<RectTransform>().sizeDelta = new Vector2(17, 17);
            img[1].GetComponent<RectTransform>().sizeDelta = new Vector2(41, 41);
            img[2].GetComponent<RectTransform>().sizeDelta = new Vector2(17, 17);
            //end itemslot
            //emotion
           // emo.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 20);
           // emo.GetComponent<RectTransform>().sizeDelta = new Vector2(48, 48);
            //end emotion
            //face
            faceui.GetComponent<RectTransform>().anchoredPosition = new Vector2(940, 540);
            faceui.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            //end face
            //keyitem
           // keyitem.GetComponent<RectTransform>().anchoredPosition = new Vector2(-97, -61);
          //  keyitem.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            //endkeyitem
            //mapui
            map.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            //endmapui
        }

        if (Screen.width == 1280 && Screen.height == 1024)
        {
            //itemslot
            img[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(-56, 53);
            img[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(-70, 9);
            img[2].GetComponent<RectTransform>().anchoredPosition = new Vector2(-56, -35);
            img[0].GetComponent<RectTransform>().sizeDelta = new Vector2(22, 22);
            img[1].GetComponent<RectTransform>().sizeDelta = new Vector2(53, 53);
            img[2].GetComponent<RectTransform>().sizeDelta = new Vector2(22, 22);
            //end itemslot
            //emotion
           // emo.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 50);
           // emo.GetComponent<RectTransform>().sizeDelta = new Vector2(62, 62);
            //end emotion
            //face
            faceui.GetComponent<RectTransform>().anchoredPosition = new Vector2(950, 700);
            faceui.GetComponent<RectTransform>().localScale = new Vector3(1, 1.3f, 1);
            //end face
            //keyitem
            //keyitem.GetComponent<RectTransform>().anchoredPosition = new Vector2(-102, -75);
            //keyitem.GetComponent<RectTransform>().localScale = new Vector3(1, 1.3f, 1);
            //endkeyitem
            //mapui
            map.GetComponent<RectTransform>().localScale = new Vector3(1, 1.3f, 1);
            //endmapui
        }

        if (Screen.width == 1280 && Screen.height == 800)
        {
            //itemslot
            img[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(-53, 42);
            img[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(-67, 7);
            img[2].GetComponent<RectTransform>().anchoredPosition = new Vector2(-53, -28);
            img[0].GetComponent<RectTransform>().sizeDelta = new Vector2(18, 18);
            img[1].GetComponent<RectTransform>().sizeDelta = new Vector2(42, 42);
            img[2].GetComponent<RectTransform>().sizeDelta = new Vector2(18, 18);
            //end itemslot
            //emotion
            //end emotion
            //face
            faceui.GetComponent<RectTransform>().anchoredPosition = new Vector2(950, 550);
            faceui.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            //end face
            //keyitem
           // keyitem.GetComponent<RectTransform>().anchoredPosition = new Vector2(-102, -65);
           // keyitem.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            //endkeyitem
            //mapui
            map.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            //endmapui
        }

        if (Screen.width == 1024 && Screen.height == 768)
        {
            //itemslot
            img[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(-50, 41);
            img[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(-60, 7);
            img[2].GetComponent<RectTransform>().anchoredPosition = new Vector2(-50, -27);
            img[0].GetComponent<RectTransform>().sizeDelta = new Vector2(17, 17);
            img[1].GetComponent<RectTransform>().sizeDelta = new Vector2(41, 41);
            img[2].GetComponent<RectTransform>().sizeDelta = new Vector2(17, 17);
            //end itemslot
            //emotion
           // emo.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 20);
           // emo.GetComponent<RectTransform>().sizeDelta = new Vector2(48, 48);
            //end emotion
            //face
            faceui.GetComponent<RectTransform>().anchoredPosition = new Vector2(760, 540);
            faceui.GetComponent<RectTransform>().localScale = new Vector3(0.8f, 1, 1);
            //end face
            //keyitem
          //  keyitem.GetComponent<RectTransform>().anchoredPosition = new Vector2(-82, -65);
          //  keyitem.GetComponent<RectTransform>().localScale = new Vector3(0.8f, 1, 1);
            //endkeyitem
            //mapui
            map.GetComponent<RectTransform>().localScale = new Vector3(0.8f, 1, 1);
            //endmapui
            
        }


    }
}
