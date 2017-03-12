using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectGamesCShape
{
    abstract class Monster:State
    {
       public Monster(int level,int maxhp,int damage,int def)
        {
            Level = level;
            Maxhp = maxhp + (Level * 5);
            Hp = Maxhp;
            Damage = damage + (2 * Level);
            Defense = def + (2 * Level);
        }
        public virtual void atk(Player player)
        {
            int temp = 0;
            temp = Damage - player.Defense;
            if (temp < 0)
            {
                temp = -temp;
            }
            player.Hp -= temp;
            Console.WriteLine("Monster Damage  : " + temp);
        }
        public virtual void free()
        {
            Console.WriteLine("Don't kill me pls");
        }
    }
}