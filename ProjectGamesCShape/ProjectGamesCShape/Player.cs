using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectGamesCShape
{
    public class Player : State
    {
       public Player()
        {
            Level = 1;
            Hp = (95) + (Level * 5);
            Maxhp = (95) + (Level * 5);
            Damage = 5 + (2 * Level);
            Defense = 0 + (2 * Level);
        }
        public void setLevel(int vel)
        {
            Level = vel;
            Hp = (95) + (Level * 5);
            Maxhp = (95) + (Level * 5);
            Damage = 5 + (2 * Level);
            Defense = 0 + (2 * Level);
        }
        public int getLevel()
        {
            return Level;
        }
    }
}