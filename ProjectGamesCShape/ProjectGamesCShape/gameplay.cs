using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectGamesCShape
{
    public class gameplay
    {
        private bool fightmode = false;
        private bool saveshowtext=false;
        private bool loadshowtext = false;
        private XML xml = new XML();
       private ShowText text = new ShowText();
       private Vector posplayer;
        private Vector enemypos;
        private Player player=new Player();
       private Graph grp = new Graph();
        private bool joinmap=false;
        private easymon weakmonster;
        int monfree;
        private boss boss;
        private bossfsm fsmboss=new bossfsm();
        private bool action = false;
        private bool bossdie = false;
        Random rand;
        public gameplay()
        {
            rand = new Random();
            grp.selectmapgraph("1",player);
            boss= new boss(15, 100, 5, 3);
            //Console.WriteLine(player.Level);
            //boss = new boss(15, 100, 5, 3);
            // posplayer = grp.PlayerPos;
            //  grp.drawMap(grp.Map1);
            //  Console.WriteLine();
            //  Console.WriteLine("============================================================================================");
            //  text.showStatus(player);
            //  grp.selectmapgraph("2");
        }
        public void playgame()
        {xml.loadsave(player);/////////////////
            while (true)
            { String temp;


                while (joinmap==false && bossdie == false && player.Hp > 0)
                {
                     
                    grp.resetmapgrp(grp.Mapgraph);
                    grp.drawmapgraph(grp.Mapgraph);
                    Console.WriteLine("============================================================================================");
                    text.showStatus(player);
                    grp.shownodecanmove();
                   
                    //grp.test();

                    if (loadshowtext == true)
                    {
                        Console.WriteLine("load complete....");
                        loadshowtext = false;
                    }
                    if (saveshowtext == true)
                    {
                        Console.WriteLine("save complete....");
                        saveshowtext = false;
                    }
                   
                    Console.WriteLine("input \'S\' for save \'L\' for load");
                    Console.Write("move to or \"E\" for enter map: ");
                   
                    temp = Console.ReadLine();
                    foreach(var item in grp.Chosemap)
                    {
                        if (temp == "E"||temp=="e")
                        {
                            joinmap = true;
                        }
                        else if (temp=="s"||temp=="S")
                        {
                            xml.Player = player;
                            xml.please_save();
                            saveshowtext = true;
                        }
                        else if (temp == "l" || temp == "L")
                        {
                            xml.loadsave(player);
                            loadshowtext = true;
                        }
                        else if (temp == item.Item1 && player.getLevel() >= item.Item2)
                            {
                                grp.selectmapgraph(temp, player);
                                break;
                            }
                    }
                    Console.Clear();
                }
                posplayer = grp.getplayerpos(grp.Tempgrppos);
                enemypos = grp.getenemypos(grp.Tempgrppos);
                weakmonster=new easymon(rand.Next(1,player.Level+1),60,3,0);
                monfree = rand.Next(0, 5);
                grp.drawMap();
                while (joinmap == true&& bossdie == false&& player.Hp > 0)
                {
                    
                        inmap();

                    fightnow();
                    

                }
                if (player.Hp <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Game Over");
                    Console.Read();
                }
                if (bossdie == true)
                {
                    Console.Clear();
                    Console.WriteLine("Good game");
                    Console.Read();
                }
                // Console.Read();
            }

        }

        void fightnow()
        {
            string key="1";
            if (posplayer.X == enemypos.X&&posplayer.Y==enemypos.Y)
            {
                fightmode = true;
            }
            if (fightmode == true)
            {
                if (grp.Tempgrppos == "5")//boss
                {
                    text.showStatus(player);
                    if (fsmboss.checktalk() == false)
                    { Console.WriteLine("enter \"1\" for talk: "); }
                    if (fsmboss.checktalk() == true)
                    {
                        Console.WriteLine("enter \"A\" for Attack \"S\" for heal : ");
                    }
                   
                    if (action == false)
                    {
                        key = Console.ReadLine();
                        Console.Clear();
                    }
                    if (fsmboss.checktalk() == false)
                    {
                        fsmboss.Eureka(key);
                    }

                    if (fsmboss.checktalk() == true&&boss.Hp>0)
                    {
                        if (action == false && key.ToUpper() == "A")
                        {
                            
                            int temp = 0;
                            temp = player.Damage - boss.Defense;
                            if (temp < 0)
                            {
                                temp = +temp;
                            }
                            boss.Hp -= temp;
                            Console.WriteLine("Acttack monster Damage: "+ temp);
                            Console.WriteLine("Boss HP: " + boss.Hp);
                            action = true;
                        }
                        if (action == false && key.ToUpper() == "S")
                        {
                            
                            player.Hp += player.Maxhp / 4;
                            Console.WriteLine("heal self: "+ ( player.Maxhp / 4)+" point");
                            action = true;
                        }
                        if(action==true)
                        {
                            fsmboss.fightmode(boss, player, action);
                            action = false;
                        }
                    }
                     if(boss.Hp<=0)
                    {
                        bossdie = true;
                    }

                }
                else//easymon
                {
                    text.showStatus(player);
                        Console.WriteLine("enter \"A\" for Attack \"S\" for heal : ");
                    

                    if (action == false)
                    {
                        key = Console.ReadLine();
                        Console.Clear();
                    }
                    if (action == false && key.ToUpper() == "A")
                    {

                        int temp = 0;
                        temp = player.Damage - weakmonster.Defense;
                        if (temp < 0)
                        {
                            temp = +temp;
                        }
                        weakmonster.Hp -= temp;
                        Console.WriteLine("Acttack monster Damage: " + temp);
                        Console.WriteLine("Monster HP: " + weakmonster.Hp);
                        action = true;
                    }
                    if (action == false && key.ToUpper() == "S")
                    {

                        player.Hp += player.Maxhp / 4;
                        Console.WriteLine("heal self: " + (player.Maxhp / 4) + " point");
                        action = true;
                    }
                    if (action == true&&monfree!=3)
                    {
                        weakmonster.atk(player);
                        action = false;
                    }
                    else
                    {
                        posplayer = grp.getplayerpos(grp.Tempgrppos);
                        weakmonster.free();
                        action = false;
                        fightmode = false;
                        joinmap = false;
                        Console.Read();
                    }
                    if (weakmonster.Hp <= 0)
                    {
                        posplayer = grp.getplayerpos(grp.Tempgrppos);
                        Console.WriteLine("Victory");
                        player.setLevel(player.Level + 1);
                        action = false;
                        fightmode = false;
                        joinmap = false;
                        Console.Read();
                    }

                }
            }
        }
         void inmap()
        {
            if (fightmode == false)
            {
                string key = Console.ReadKey().Key.ToString();
                // if (action == false)
                // {
                //grp.drawMap(grp.Map1);
                // key = Console.ReadLine();
                if (key.ToUpper() == "W")
                    if (grp.checkmove(Int32.Parse(grp.Tempgrppos), posplayer.X, posplayer.Y - 1) == true)
                        posplayer.Y--;
                if (key.ToUpper() == "S")
                    if (grp.checkmove(Int32.Parse(grp.Tempgrppos), posplayer.X, posplayer.Y + 1) == true)
                        posplayer.Y++;
                if (key.ToUpper() == "A")
                    if (grp.checkmove(Int32.Parse(grp.Tempgrppos), posplayer.X - 1, posplayer.Y) == true)
                        posplayer.X--;
                if (key.ToUpper() == "D")
                    if (grp.checkmove(Int32.Parse(grp.Tempgrppos), posplayer.X + 1, posplayer.Y) == true)
                        posplayer.X++;

                grp.setposplayer(posplayer.X, posplayer.Y);
                Console.Clear();
                grp.drawMap();
                Console.WriteLine();
                Console.WriteLine("============================================================================================");
                text.showStatus(player);
            }
        }
    }
}