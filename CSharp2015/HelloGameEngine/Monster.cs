using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloGameEngine
{
    class Monster
    {
        private int monhp = 200;
        private int monmaxhp = 200;
        private int mondm = 5;
        public int getHp()
        {
            return monhp;
        }
        public int getMaxHp()
        {
            return monmaxhp;
        }
        public int getMondm()
        {
            return mondm;
        }
        public void sethp(int hp)
        {
            monhp = hp;
        }
        public GameObject game;
        public Monster(RenderTileObject ren)
        {
            game = new GameObject(ren);
        }
        public void update(int framecount)
        {
            game.onUpdate(framecount);   
        }
    }
}
