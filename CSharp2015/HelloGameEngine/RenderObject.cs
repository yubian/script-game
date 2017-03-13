using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HelloGameEngine
{
    class RenderObject
    {
        protected Image image;
        protected Rectangle bound;

        public RenderObject() { }
        public RenderObject(Image image)
        {
            this.image = image;
            bound = new Rectangle(0, 0, image.Width, image.Height);
        }

        public Image getImage()
        {
            return this.image;
        }

        public virtual void setBoundPosition(int x,int y)
        {
            this.bound.X = x;
            this.bound.Y = y;
        }

        public virtual void setBoundScale(int width, int height)
        {
            this.bound.Width = width;
            this.bound.Height = height;
        }

        public virtual void render(BufferedGraphics buffer)
        {
            buffer.Graphics.DrawImage(this.image, this.bound);
        }
    }
}
