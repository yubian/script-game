using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectGamesCShape
{
    class easymon:Monster
    {
        public easymon(int level, int maxhp, int damage, int def):base(level,maxhp,damage,def){

        }
        public override void atk(Player player)
        {
            base.atk(player);
        }
        public override void free()
        {
            base.free();
        }
    }
}