using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectGamesCShape
{
    public class State
    {
        int maxhp;
        int hp;
        int damage;
        int defense;
        int level;
        string name;
        public int Hp
        {
            get
            {
                return hp;
            }

            set
            {
                hp = value;
            }
        }

        public int Damage
        {
            get
            {
                return damage;
            }

            set
            {
                damage = value;
            }
        }

        public int Defense
        {
            get
            {
                return defense;
            }

            set
            {
                defense = value;
            }
        }

        public int Level
        {
            get
            {
                return level;
            }

            set
            {
                level = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int Maxhp
        {
            get
            {
                return maxhp;
            }

            set
            {
                maxhp = value;
            }
        }
    }
}