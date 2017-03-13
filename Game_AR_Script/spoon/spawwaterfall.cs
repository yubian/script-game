using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawwaterfall : MonoBehaviour {
    public GameObject prefab;
    public Animator anim;
    public GameObject[] pos;
    private int maxNumbers = 3;
    private List<int> uniqueNumbers;
    private List<int> finishedList;

    int cout = 0;
    private List<int> checkfirst;
    private bool gameend = false;
    private int[] fix = new int[3] { 0, 1, 2 };
    private bool firstrun = false;
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
    }

    void Start()
    {
        checkfirst = new List<int>();
        uniqueNumbers = new List<int>();
        finishedList = new List<int>();

        GenerateRandomList();
    }
    void addidpos()
    {
        for(int i = 0; i < pos.GetLength(0); i++)
        {
            this.pos[i].GetComponent<poscheckitem>().idpos=finishedList[i];
        }
    }
	void Update () {
        if (firstrun == false)
        {
            addidpos();
            firstrun = true;
        }
        if (gameend == true)
        {
            anim.SetBool("runbody", true);
        }
        else
        {
            checkwaterfallnext();
        }

    }
    void checkwaterfallnext()
    {
        for (int i = 0; i < pos.GetLength(0); i++)
        {
            if (this.pos[i].GetComponent<poscheckitem>().withnext == true&& this.pos[i].GetComponent<poscheckitem>().nowcheck==false)
            {
                this.pos[i].GetComponent<poscheckitem>().nowcheck = true;
                   // Debug.Log("fix" + fix[i]);
                   cout += 1;
                checkfirst.Add(i);
            }
        }
       // Debug.Log("cout" + cout);
        if (cout > 2)
        {
           // Debug.Log("SSSSSSSSSSSSS");
            int coutcheck = 0;
            for (int i = 0; i < checkfirst.Count; i++)
            {
               
                if (this.pos[checkfirst[i]].GetComponent<poscheckitem>().idpos != fix[i])
                {
                   
                    this.pos[checkfirst[i]].GetComponent<poscheckitem>().nowcheck = false;
                    checkfirst.Clear();
                }
                else { coutcheck++; }
            }
            if (coutcheck == 3)
            {
                gameend = true;
            }
            else {
                cout = 0;
                gameend = false;
                rewater(); }   
        }
        
    }

    void rewater()
    {
        for (int i = 0; i < pos.GetLength(0); i++)
        {
            this.pos[i].GetComponent<poscheckitem>().nowcheck = false; 
            this.pos[i].GetComponent<poscheckitem>().des = true;
        }
    }
}
