using UnityEngine;
using System;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using PlayerCon;
public class IconSG : MonoBehaviour
{ GameObject player;
    EventUI even;
    string cpload;
    int h;
    public GameObject SG;
    public static bool load=false;
    void Start()
    {
           even = GameObject.Find("Canvas").GetComponent<EventUI>();
           player = GameObject.FindWithTag("Player");
        if (load == true)
        {
            LoadGame();
        }
    }
    void OnMouseDown()
    {
        
    }
    public void ButtomCancel()
    {
        SG.SetActive(false);
    }
    public void ButtomSave()
    {// Application.persistentDataPath +  "C:/Users/Dell/Desktop/savedGames.txt"
        StreamWriter sg = new StreamWriter(Application.persistentDataPath + "savedGames.txt");
        sg.WriteLine(player.GetComponent<PlayerController>().getHP());
         sg.WriteLine(player.GetComponent<Transform>().position.x + "," + player.GetComponent<Transform>().position.y +
             "," + player.GetComponent<Transform>().position.z);
        for (int i = 0; i < player.GetComponent<PlayerController>().getItemSize2();i++)
        {
                sg.Write(player.GetComponent<PlayerController>().getItem(i,0)+",");
            
        }
        sg.WriteLine();

        for(int i = 0; i < even.even.GetLength(0); i++)
        {
            if (even.even[i] == null)
            {
                sg.Write(findname( i) + ",");
                //sg.Write(even.even[i].name + ",");
            }
            
           
        }
        sg.WriteLine();
        for (int i = 0; i < player.GetComponent<PlayerController>().Itemslot.GetLength(0); i++)
        {
            sg.Write(player.GetComponent<PlayerController>().Itemslot[i] + ",");

        }
        sg.Flush();
        sg.Close();
        SG.SetActive(false);
    }
    public void menuload()
    {
        load = true;
    }
    public void menustart()
    {
        load = false;
    }
    public void LoadGame()
    {
        List<string> lines = new List<string>();
        StreamReader sc = new StreamReader(Application.persistentDataPath + "savedGames.txt");
        cpload = sc.ReadLine();
        h = int.Parse(cpload);
        player.GetComponent<PlayerController>().setHP(h);
        string dataline;
        while ((dataline = sc.ReadLine()) != null)
        {
            lines.Add(dataline);
        }

            string[] values = lines[0].Split(',');
            Vector3 pos = Vector3.zero;
            pos.x = float.Parse(values[0]);
            pos.y = float.Parse(values[1]);
            pos.z = float.Parse(values[2]);
            player.transform.position = pos;
            values = lines[1].Split(',');
        for (int i=0;i < player.GetComponent<PlayerController>().getItemSize() / 2; i++)
        {
            player.GetComponent<PlayerController>().setItem(i, 0, Convert.ToInt32(values[i]));
        }
        values = lines[2].Split(',');
        for (int i = 0; i < even.even.GetLength(0); i++)
        {
           // Debug.Log(findname(i));
            if (findname(i) == values[i] )
            {
                Destroy(GameObject.Find(values[i]));
            }
        }
        values = lines[3].Split(',');
        for (int i = 0; i < player.GetComponent<PlayerController>().Itemslot.GetLength(0); i++)
        {
            player.GetComponent<PlayerController>().Itemslot[i] = Convert.ToBoolean(values[i]);

        }
        sc.Close();

    }
    string findname(int i)
    {
        string tem = "Event (" + i + ")";
        return tem;
    }





}