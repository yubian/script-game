using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectGamesCShape
{
    public class ItemSlot
    {
        Potion potion = new Potion();
        List<string> slotitem = new List<string>();
        public void ShowItem()
        {
            foreach(var slot in slotitem)
            {
                Console.Write(slot);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
        public void addItem(string add)
        {
            slotitem.Add(add);
        }
        public int useitem(int i)
        {
            
                return potion.getPotion();
        }
    }
}