using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectGamesCShape
{
    public class ShowText
    {
       public void showStatus(Player player)
        {
            Console.WriteLine("Level: " + player.Level);
            Console.WriteLine("HP: " + player.Hp + "/" + player.Maxhp + " Damage: " + player.Damage + " Defense: " + player.Defense);
        }
    }
}