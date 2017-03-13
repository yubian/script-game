using UnityEngine;
using System.Collections;
    public class PlayerStatus: MonoBehaviour
{ bool[] keyitem =new bool[4] {false, false, false ,false};
    public string checkbox;//for mouseover item
    bool eventingame = false;
    bool[] itemslot = new bool[25] {false, false, false, false, false, false, false, false,
        false, false, false, false, false, false, false, false, false, false, false, false,
        false, false, false, false, false }; 
    int[,] item = new int[5,2] { {101,1}, { 101,  0},{ 104, 0 }, { 104, 1 }, { 105,0 } };
    bool cheatmode = false;
    int hp = 6;
        int maxhp = 6;
        float maxstamina = 100;
        float stamina = 100;

    public bool[] Itemslot
    {
        get
        {
            return itemslot;
        }

        set
        {
            itemslot = value;
        }
    }

    public void setEvent(bool ev)
    {
        eventingame = ev;
    }
    public bool getEvent()
    {
        return eventingame;
    }
    public void setItem(int i, int j,int k)
    {
        item[i,j]=k;
    }
    public int getItemSize()
    {
        return item.Length;
    }
    public int getItemSize2()
    {
        return item.GetLength(0);
    }
    public int getItem(int i,int j)
    {
        return item[i,j];
    }
    //public void setKeyItem(int i,bool k) {
    //    this.keyitem[i] = k;
   // }
   // public bool getKeyItem(int i)
  //  {
   //     return this.keyitem[i];
   // }
        public float getMaxstamina()
        {
            return this.maxstamina;
        }
        public float getStamina()
        {
            return this.stamina;
        }
        public void setStamina(float sta)
        {
            this.stamina = sta;
        }
        public void setHP(int hpp)
        {
            this.hp = hpp;
        }
        public int getMaxhp()
        {
            return this.maxhp;
        }
        public int getHP()
        {
            return this.hp;
        }
    public void setCheatMode(bool cm)
    {
        this.cheatmode = cm;
    }
    public bool getCheatMode()
    {
        return this.cheatmode;
    }
    public string getCheckbox()//for mouseover item
    {
        return checkbox;
    }
    public void setCheckbox(string i)//for mouseover item
    {
        checkbox = i;
    }
    // Use this for initialization

}