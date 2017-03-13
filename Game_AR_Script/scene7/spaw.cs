using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class spaw : MonoBehaviour
{
    public GameObject prefab;
    public Transform humen;
    public GameObject main;
    public Animator anim;
    int k = 0;
    float maxdelay = 5;
    float delay =0;
    float posx = 0;
    float posz = 0;
    float posy = 0;
    float delayfind = 0;
    int cout = 0;
    bool die = false;
    public bool findtrack = false;//for checktrack in AR
    List<string> tempname;	
	void Start () {
        tempname = new List<string>();

    }
	void Update () {    
            if (die == true)
        {
            anim.SetBool("ghostrunanim", true);
            Invoke("reset", 3f);
        }
        else
        {
            if (findtrack == true)
            {
                setghost();
            }
        }

    }
    void reset()
    {
        foreach (var item in tempname)
        {
            Destroy(GameObject.Find(item));
        }
        tempname.Clear();
        k = 0;
         maxdelay = 5;
         delay = 0;
         delayfind = 0;
         cout = 0;
         die = false;
        anim.SetBool("ghostrunanim", false);
    }
    void setghost()
    {
        delay += Time.deltaTime;
        if (delay > maxdelay)
        {
            posx = Random.Range(-0.34f, 0.35f);
            posz = Random.Range(-0.2f, 0.133f);
            posy = Random.Range(-0.1f, 0.05f);
            spawnghost(new Vector3(posx, posy, posz));
            // spawnghost(Random.Range(0, 8));
            delay = 0;
            maxdelay -= 0.5f;
            if (maxdelay < 0.4f)
            {
                maxdelay = 0.4f;
            }
        }
        delayfind += Time.deltaTime;
        if (delayfind > 0.5f)
        {
            delayfind = 0;
            foreach (var item in tempname)
            {
                if (GameObject.Find(item))
                {
                    cout++;
                }
            }
            if (cout > 4)
            {
                die = true;


                // gmam.SetActive(true);
            }
            cout = 0;
        }
    }
    void spawnghost(Vector3 poss)
    {

        GameObject sghost = Instantiate(prefab, poss, Quaternion.Euler(new Vector3(90, 0, 0))) as GameObject;
        sghost.name = "ghost"+k;
        tempname.Add("ghost" + k);
        sghost.transform.SetParent(main.transform);
       
        if (poss.x < humen.transform.localPosition.x-0.1f)
        {
            sghost.transform.localScale = new Vector3(-sghost.transform.localScale.x, sghost.transform.localScale.y, sghost.transform.localScale.z);
        }
        sghost.transform.localPosition = poss;
        k++;

    }

}
