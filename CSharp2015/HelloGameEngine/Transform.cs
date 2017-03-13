using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloGameEngine
{
    class Transform
    {
        public Vector2 position;
        public Vector2 rotate;
        public Vector2 scale;

        public Transform()
        {
            this.position = new Vector2(0, 0);
            this.rotate = new Vector2(0, 0);
            this.scale = new Vector2(1, 1);
        }
    }
}
