using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poscheckitem : MonoBehaviour {
    public bool checkitem = false;
    public bool withnext = false;
    public bool des = false;
    public bool nowcheck = false;
    public int idpos = 0;
    public GameObject prefab;
    int k = 0;
    string tempnam = "";
    //public int cout = 0;
    float couttime = 0;
    void spawnghost(Vector3 poss)
    {
        GameObject clone = Instantiate(prefab, poss, Quaternion.Euler(new Vector3(90, 0, 0))) as GameObject;
        clone.name = "waterfall"+gameObject.name + k;
        tempnam = "waterfall" + gameObject.name + k;
        // clone.GetComponent<Checkclick>().boss = main;
        checkitem = true;
        clone.GetComponent<Checkclick>().main = gameObject;
        clone.transform.SetParent(gameObject.transform);
        
        k++;
    }
    void Start()
    {
        spawnghost(gameObject.transform.position);
        //cout += 1;
    }
        void Update()
    {
        if (des == true)
        {
            des = false;
            Destroy(GameObject.Find(tempnam));
            checkitem = false;
            withnext = false;
        }
        if (checkitem == false&&withnext==false)//&&cout<1)
        {
           // cout++;
            spawnghost(gameObject.transform.position);
            
        }
        //if(GameObject.Find("waterfall" + gameObject.name + k)!=null)
       // {
       //     haveitem = true;
       // }
       // else { haveitem = false; }
    }
}
