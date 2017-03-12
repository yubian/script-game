using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGamesCShape
{
    class Graph
    {
        Vector playerPos=new Vector();
        Vector enemypos = new Vector();
       
        private string tempgrppos;
        private int levelplayer;
        private char[,] mapgraph = new char[20, 30];
        private bool[,] map1 = new bool[20, 30];
        private bool[,] map2 = new bool[20, 40];
        private bool[,] map3 = new bool[25, 50];
        private bool[,] map4 = new bool[20, 40];
        private bool[,] map5 = new bool[35, 60];
        private List<Node> all_node = new List<Node>();
        private List<Tuple<string, int>> chosemap = new List<Tuple<string, int>>();
        private List<Tuple<string, Vector>> startposmap = new List<Tuple<string, Vector>>();
        private List<Tuple<string, Vector>> posenemy = new List<Tuple<string, Vector>>();
        public Vector PlayerPos
        {
            get
            {
                return PlayerPos1;
            }

            set
            {
                PlayerPos1 = value;
            }
        }

        public bool[,] Map1
        {
            get
            {
                return map1;
            }

            set
            {
                map1 = value;
            }
        }

        public bool[,] Map2
        {
            get
            {
                return map2;
            }

            set
            {
                map2 = value;
            }
        }

        public bool[,] Map3
        {
            get
            {
                return map3;
            }

            set
            {
                map3 = value;
            }
        }

        public bool[,] Map4
        {
            get
            {
                return map4;
            }

            set
            {
                map4 = value;
            }
        }

        public bool[,] Map5
        {
            get
            {
                return map5;
            }

            set
            {
                map5 = value;
            }
        }

        public char[,] Mapgraph
        {
            get
            {
                return mapgraph;
            }

            set
            {
                mapgraph = value;
            }
        }

        public List<Tuple<string, int>> Chosemap
        {
            get
            {
                return chosemap;
            }

            set
            {
                chosemap = value;
            }
        }

        public string Tempgrppos
        {
            get
            {
                return tempgrppos;
            }

            set
            {
                tempgrppos = value;
            }
        }

        public Vector PlayerPos1
        {
            get
            {
                return playerPos;
            }

            set
            {
                playerPos = value;
            }
        }

        public Vector Enemypos
        {
            get
            {
                return enemypos;
            }

            set
            {
                enemypos = value;
            }
        }

        void setmapgraph(int y,int x, char st)
        {
            Mapgraph[y, x] = st;
        }
        public void drawmapgraph(char[,] mgrp)
        {
            for(int y = 0; y < mgrp.GetLength(0); y++)
            {
                for(int x = 0; x < mgrp.GetLength(1); x++)
                {
                    if (mgrp[y, x] =='P')
                    {
                        Console.Write("P");
                    }
                    else if (mgrp[y, x] == '1')
                    {
                        Console.Write("1");
                    }
                    else if (mgrp[y, x] == '2')
                    {
                        Console.Write("2");
                    }
                    else if (mgrp[y, x] == '3')
                    {
                        Console.Write("3");
                    }
                    else if (mgrp[y, x] == '4')
                    {
                        Console.Write("4");
                    }
                    else if (mgrp[y, x] == '5')
                    {
                        Console.Write("5");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
        void newmap(bool[,] mappp)
        {
            for(int y = 0; y < mappp.GetLength(0); y++)
            {
                for(int x = 0; x < mappp.GetLength(1); x++)
                {
                    if (y == 0||y==mappp.GetLength(0)-1
                        ||x==0||x==mappp.GetLength(1)-1)
                    {
                        mappp[y, x] = false;
                    }
                    else
                    {
                        mappp[y, x] = true;
                    }
                }
            }
        }
        public Graph()
        {
            string[] nod = new string[5] { "1", "2", "3", "4", "5" };
            foreach (var item in nod)
            {
                all_node.Add(new Node(item));
            }
            for(int i=0;i< Mapgraph.GetLength(0); i++)
            {
                for(int j=0;j< Mapgraph.GetLength(1); j++)
                {
                    Mapgraph[i, j] = ' ';
                }
            }
            Tempgrppos = "1";

            newmap(map1);
            newmap(map2);
            newmap(map3);
            newmap(map4);
            newmap(map5);

            setPlayerpos("1", 15, 2);
            setPlayerpos("2", 20, 2);
            setPlayerpos("3", 25, 2);
            setPlayerpos("4", 20, 2);
            setPlayerpos("5", 30, 2);

            setposenemy("1", 15, 17);
            setposenemy("2", 15, 15);
            setposenemy("3", 30, 21);
            setposenemy("4", 25, 18);
            setposenemy("5", 30, 30);

            setmapgraph(18, 15, '1');
            setmapgraph(15, 10, '2');
            setmapgraph(15, 20, '3');
            setmapgraph(10, 15, '4');
            setmapgraph(5, 15, '5');

            addNeighbor("1", "2", 0);
            addNeighbor("1", "3", 0);
            addNeighbor("2", "4", 0);
            addNeighbor("3", "4", 0);
            addNeighbor("4", "5", 15);
        }
        public void resetmapgrp(char[,] mgrp)
        {
            int xx=0, yy = 0;
            setmapgraph(18, 15, '1');
            setmapgraph(15, 10, '2');
            setmapgraph(15, 20, '3');
            setmapgraph(10, 15, '4');
            setmapgraph(5, 15, '5');
            for (int y = 0; y < mgrp.GetLength(0); y++)
            {
                for (int x = 0; x < mgrp.GetLength(1); x++)
                {
                    if (mgrp[y, x] == Char.Parse(Tempgrppos))
                    {
                        xx = x;
                        yy = y;
                    }
                }
            }
            setmapgraph(yy, xx, 'P');
        }
        public bool checkmove(int selectmap, int x, int y)
        {
            if (selectmap == 1)
            {
                if (map1[y, x] == true)
                {
                    return true;
                }
            }
            if (selectmap == 2)
            {
                if (map2[y, x] == true)
                {
                    return true;
                }
            }
            if (selectmap == 3)
            {
                if (map3[y, x] == true)
                {
                    return true;
                }
            }
            if (selectmap == 4)
            {
                if (map4[y, x] == true)
                {
                    return true;
                }
            }
            if (selectmap == 5)
            {
                if (map5[y, x] == true)
                {
                    return true;
                }
            }
            return false;
        }
        public void setPlayerpos(string st, int x,int y)
        { Vector none = new Vector();
            none.X = x;
            none.Y = y;
            startposmap.Add(Tuple.Create(st, none));
        }
        public void setposenemy(string st, int x, int y)
        {
            Vector none = new Vector();
            none.X = x;
            none.Y = y;
            posenemy.Add(Tuple.Create(st, none));
        }
        public Vector getenemypos(string st)
        {
            foreach (var item in posenemy)
            {
                if (item.Item1 == st)
                {
                    setEnemypos(item.Item2.X, item.Item2.Y);
                    return item.Item2;
                }
            }
            return null;
        }
        public Vector getplayerpos(string st)
        {
            foreach(var item in startposmap)
            {
                if (item.Item1 == st)
                {
                    setposplayer(item.Item2.X, item.Item2.Y);
                    return item.Item2;
                }
            }
            return null;
        }
        public void setposplayer(int x, int y)
        {
            PlayerPos1.X = x;
            PlayerPos1.Y = y;
        }
        public void setEnemypos(int x,int y)
        {
            Enemypos.X = x;
            Enemypos.Y = y;
        }
        public void drawMap()
        {
            bool[,] Map=new bool[1,1];
            if (tempgrppos == "1") {
                Map=new bool[map1.GetLength(0),map1.GetLength(1)];
                Map = map1;
            }
            if (tempgrppos == "2")
            {
                Map = new bool[map2.GetLength(0), map2.GetLength(1)];
                Map = map2;
            }
            if (tempgrppos == "3")
            {
                Map = new bool[map3.GetLength(0), map3.GetLength(1)];
                Map = map3;
            }
            if (tempgrppos == "4")
            {
                Map = new bool[map4.GetLength(0), map4.GetLength(1)];
                Map = map4;
            }
            if (tempgrppos == "5")
            {
                Map = new bool[map5.GetLength(0), map5.GetLength(1)];
                Map = map5;
            }
            for (int y = 0; y < Map.GetLength(0); y++)
            {
                for(int x = 0; x < Map.GetLength(1); x++)
                {
                    if (y == PlayerPos.Y && x == PlayerPos.X)
                    {
                        Console.Write("P");
                    }
                    else if(y== Enemypos.Y&&x== Enemypos.X)
                    {
                        Console.Write("E");
                    }
                   else if (Map[y, x] == true)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("#");
                    }
                    
                    
                }
                Console.WriteLine();
            }
        }
        public void addNeighbor(String base_node, String neighbor, int cost)
        {
            foreach (var item in all_node)
            {
                if (item.Data == base_node)
                {
                    item.add_myNeighbor(neighbor, cost);
                }
                if (item.Data == neighbor)
                {
                    item.add_myNeighbor(base_node, cost);
                }
            }
        }
        public void shownodecanmove()
        {
            Console.Write("You can move: ");
            foreach (var item in Chosemap)
            {
                if (levelplayer >= item.Item2)
                {
                    Console.Write(item.Item1 + " ");
                }
                else { Console.Write("\"map " +item.Item1 + " need level "+item.Item2+"\""); }
            }
            Console.WriteLine();
        }
        public void selectmapgraph(String base_node,Player player)
        {
            //Console.WriteLine(player.Level);
            levelplayer = player.getLevel();
            Tempgrppos = base_node;
            Chosemap.Clear();
            foreach (var item in all_node)
            {
                if (item.Data == base_node)
                {         
                    item.getnodedata(Chosemap);
                    
                }
            }
            
           
        }
        public void test()
        {
            foreach (var item in Chosemap)
            {
                Console.Write(item.Item2+" ");
            }
        }
    }
}
