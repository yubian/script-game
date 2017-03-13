using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace HelloGameEngine
{
    class Renderer
    {
        private BufferedGraphicsContext buffcontext;
        private BufferedGraphics buffer;
        private Rectangle freamBuffer;
        private List<RenderObject> renderlist;

        public Renderer(SceneManager scene)
        {
            scene.Paint += new System.Windows.Forms.PaintEventHandler(onRender);
            freamBuffer = new Rectangle(0,0,scene.Size.Width,scene.Size.Height);
            renderlist = new List<RenderObject>();
        }

        public void addtoRender(RenderObject obj)
        {
            renderlist.Add(obj);
        }
        public void retoRender(RenderObject obj)
        {
            renderlist.Remove(obj);
        }
        private void onRender(object sender, PaintEventArgs e)
        { 
            render(e.Graphics);
           
        }
        public void delRender( RenderObject obj)
        {
            renderlist.Clear();
        }
        public void render(Graphics graph)
        {
            buffcontext = BufferedGraphicsManager.Current;
            buffer = buffcontext.Allocate(graph, freamBuffer);

            for(int i = 0; i<renderlist.Count;i++)
            {
                renderlist[i].render(buffer);
            }

            buffer.Render(graph);
            buffer.Dispose();
        }
    }
}
