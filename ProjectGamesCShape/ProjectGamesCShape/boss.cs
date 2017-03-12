using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectGamesCShape
{
     class boss : Monster
    {
        public boss(int level, int maxhp, int damage, int def):base(level,maxhp,damage,def)
        {

        }
        public override void atk(Player player)
        {
            base.atk(player);
        }
        public void heal()
        {
            Hp += Maxhp / 3;
            Console.WriteLine("Monster Use Skill \"Heal\""+(Maxhp / 3)+" point");
        }
        
        public void strongatk(Player player)
        {
            int temp = 0;
            temp = (Damage+(Damage/2)) - player.Defense;
            if (temp < 0)
            {
                temp = -temp;
            }
            player.Hp -= temp;
            Console.WriteLine("Monster Damage : " + temp);
        }
    }
}