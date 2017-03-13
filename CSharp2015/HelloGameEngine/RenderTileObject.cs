using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HelloGameEngine
{
    class RenderTileObject : RenderObject
    {
        private List<Rectangle> frames;//ไว้ใช้เก็บเฟรมคือการเก็บตำแหน่งของxและy

        private int tilewidth;
        private int tileheight;
        private int frameindex;
        
        public RenderTileObject()
        {
            frameindex = 0;
            this.frames = new List<Rectangle>();
        }

        public RenderTileObject(Image image, int tilewidth, int tileheight) : this()//this=obj ให้ไปเรียกคอนทรักเตอร์ที่อยู่ข้างบน
        {
            this.image = image;//ใช้thisหรือimageก็ได้ตือเรียกobjจากแม่มาใช้
            this.bound = new Rectangle(0, 0, tilewidth, tileheight);
            this.tilewidth = tilewidth;
            this.tileheight = tileheight;

            int height = image.Height / tileheight;//256หาร32 = 8
            int width = image.Width / tilewidth;//96หาร32 = 3
            for(int i=0;i<height;i++)
                for(int j =0;j<width;j++)
                {
                    frames.Add(new Rectangle(j * tilewidth, i * tileheight, tilewidth, tileheight));
                }
            Console.WriteLine("sdfsfds");
        }
        public void setFrameIndex(int i)//มีเพื่อให้รู้ว่าโปรแกรมวาดเฟรมไหน เฟรมที่0,1,2,บลาๆๆๆ
        {
            this.frameindex = i;
        }

        public int getTileWidth()
        {
            return this.tilewidth;
        }

        public override void render(BufferedGraphics buffer)
        {
            buffer.Graphics.DrawImage(this.image, bound, this.frames[frameindex], GraphicsUnit.Pixel);
        }
    }
}
