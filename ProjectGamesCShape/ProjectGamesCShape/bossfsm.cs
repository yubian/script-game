using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGamesCShape
{
    
    class bossfsm
    {
        private int coutheal = 0;
        private int cout = 0;
        private delegate void state();
        private state active;

        public bossfsm()
        {
            active = (state)(q1);
            active();
            Console.Clear();
        }
        public bool checktalk()
        {
            if (cout == 3)
            {
                return true;
            }
            return false;
        }
        public void Eureka(string x)
        {
            Transition_Function(x);
            active();
        }

        public void fightmode(boss bos,Player player,bool action)
        {
            if(bos.Hp< (bos.Maxhp /2)&&action== true&&coutheal<2)
            {
                bos.heal();
                coutheal += 1;
            }
           else if (bos.Hp < (bos.Maxhp/ 3)&&action == true)
            {
                bos.strongatk(player);
            }
            else if (action == true)
            {
                bos.atk(player);
            }
        }
        private void q1()
        {
            Console.WriteLine("I will give F for you HaHaHaHa");
        }
        private void q2()
        {
            Console.WriteLine("HaHaHaHaHa");
        }
        private void q3()
        {
            Console.WriteLine("You don't want F?");
           
        }


        private void Transition_Function(string x)
        {
           
            if ((active == q1) && (x == "1"))
            {
                active = (state)(q2);
                cout++;
            }
            else if ((active == q2) && (x == "1"))
            {
                active = (state)(q3);
                cout++;
            }
            else if ((active == q3) && (x == "1"))
            {
                active = (state)(q1);
                cout++;
            }
        }
    }
}
