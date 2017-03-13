using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mask : MonoBehaviour
{
    public GameObject anim;

    public GameObject[] masks;
    public Transform[] posmask;
    public List<string> obj;
    public bool moveobj = false;

    private float times = 0;

    private int maxNumbers = 8;
    private List<int> uniqueNumbers;
    private List<int> finishedList;

    private bool gameend = false;
    public void GenerateRandomList()
    {
        for (int i = 0; i < maxNumbers; i++)
        {
            uniqueNumbers.Add(i);
        }
        for (int i = 0; i < maxNumbers; i++)
        {
            int ranNum = uniqueNumbers[Random.Range(0, uniqueNumbers.Count)];
            finishedList.Add(ranNum);
            uniqueNumbers.Remove(ranNum);
        }
        //Do
    }
        void Start()
    {
        uniqueNumbers = new List<int>();
            finishedList = new List<int>();
            obj = new List<string>();

        GenerateRandomList();


        for (int i = 0; i < masks.GetLength(0); i++)
        {
            masks[i].transform.position = posmask[finishedList[i]].position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        changemasks();
        if (gameend == true)
        {
            anim.GetComponent<Animator>().SetBool("end", true);
            Invoke("resetgame", 0.8f);
            //resetgame();
        }
        else
        {
            checkgame();
        }
    }
    void checkgame()
    {
        int coutlockpos = 0;
       for(int i = 0; i < masks.GetLength(0); i++)
        {
            if (masks[i].GetComponent<selectmask>().lockpos == true)
            {
                coutlockpos++;
            }
        }
        if (coutlockpos >= masks.GetLength(0))
        {
            gameend = true;
        }
    }
    void resetgame()
    {
        uniqueNumbers.Clear();
        finishedList.Clear();
        GenerateRandomList();
        gameend = false;
           moveobj = false;
        for (int i = 0; i < masks.GetLength(0); i++)
        {
            masks[i].transform.position = posmask[finishedList[i]].position;
        }
        anim.GetComponent<Animator>().SetBool("end", false);
        times = 0;
        GameObject.Find(obj[0]).GetComponent<selectmask>().selec = 0;
        GameObject.Find(obj[1]).GetComponent<selectmask>().selec = 0;
        obj.Clear();
    }
    void resetmasks()
    {
        moveobj = false;
        times = 0;
        GameObject.Find( obj[0]).GetComponent<selectmask>().selec = 0;
        GameObject.Find(obj[1]).GetComponent<selectmask>().selec = 0;
        obj.Clear();
    }
    void changemasks()
    {
       // int tempid1 = 0;
        //int tempid2 = 0;
        if (obj.Count > 1)
        {
            GameObject.Find(obj[0]).GetComponent<Transform>().position = Vector3.Lerp(
                GameObject.Find(obj[0]).GetComponent<Transform>().position
                , GameObject.Find(obj[1]).GetComponent<selectmask>().pos, 0.3f);

            GameObject.Find(obj[1]).GetComponent<Transform>().position = Vector3.Lerp(
               GameObject.Find(obj[1]).GetComponent<Transform>().position
               , GameObject.Find(obj[0]).GetComponent<selectmask>().pos, 0.3f);

           // tempid1 = GameObject.Find(obj[0]).GetComponent<selectmask>().targetid;
           // tempid2 = GameObject.Find(obj[1]).GetComponent<selectmask>().targetid;

            //GameObject.Find(obj[0]).GetComponent<selectmask>().targetid = tempid2;
           // GameObject.Find(obj[1]).GetComponent<selectmask>().targetid = tempid1;

            moveobj = true;
            times += Time.deltaTime;
        }
        if (times > 1.5f)
            //GameObject.Find(obj[0]).GetComponent<selectmask>().targetid==tempid2&&
           // GameObject.Find(obj[1]).GetComponent<selectmask>().targetid == tempid1)
        {
            resetmasks();
        }
    }
}
