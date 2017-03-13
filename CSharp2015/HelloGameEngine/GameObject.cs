using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloGameEngine
{
    class GameObject
    {
        protected RenderTileObject objRender;
        protected direction direction;
        protected bool idle;
        protected int startframe;
        protected int animationrate;
        protected int framlimit;
        protected int framecurrent;

        public Transform transform;

        public GameObject(RenderTileObject objRender)
        {
            this.objRender = objRender;
            this.direction = direction.Mid;
            this.idle = true;
            this.startframe = 0;
            this.animationrate = 4;
            this.framlimit = objRender.getImage().Width / objRender.getTileWidth();
            this.framecurrent = 0;

            this.transform = new Transform();
            
        }

        public void setStartFrame(int frame)
        {
            this.startframe = frame;
        }

        public void setAnimationrate(int rate)
        {
            this.animationrate = rate;
        }

        public void setPosition(Vector2 pos)
        {
            this.transform.position = pos;
        }

        public void setFrameLimit(int limit)
        {
            this.framlimit = limit;
        }

        public void setDirection(direction dir)
        {
            this.direction = dir;
        }
        public virtual void onUpdate(int framecount)
        {
            this.objRender.setBoundPosition(transform.position.X,transform.position.Y);
            if (framecount % this.animationrate == 0)
                animate();
        }

        public virtual void animate()
        {
            if(this.idle == false)
            {
                framecurrent++;
                if(framecurrent >= framlimit)
                    framecurrent = 0;

                this.objRender.setFrameIndex(startframe + framecurrent);
            }
        }

        public virtual void setIdle(bool idle)
        {
            this.idle = idle;
        }
    }
}
