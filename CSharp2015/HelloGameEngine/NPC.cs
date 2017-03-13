using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloGameEngine
{
    class NPC
    {
        public GameObject gameobject;
        private PathFinder path;

        public NPC(RenderTileObject rbj,Graph graph,int movespeed)
        {
            this.gameobject = new GameObject(rbj);
            this.path = new PathFinder(graph, this.gameobject.transform, movespeed);
        }
        public void update(int framecount)
        {
            gameobject.onUpdate(framecount);
            path.randomVertexTarget();
            path.moveToPoint();
        }
    }
}
