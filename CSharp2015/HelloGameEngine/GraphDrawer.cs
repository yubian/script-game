using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloGameEngine
{
    class GraphDrawer
    {
        private Graph graph;
        private int selectid;//เปลี่ยนตามที่เม้าไปคลิก 
        private int tempid;//เก็บตัวที่กดก่อนหน้า เช่น selectidเป็น 1 tempจะเป็น 0
        private bool hold;
        private int x, y;
        public GraphDrawer(Form scene,Graph graph)
        {
            this.graph = graph;
            this.selectid = -99;//ให้ต่ำกว่า0 ไม่งั้นจะไปทับกับโหนดที่0,1,2,...
            this.tempid = -99;

            scene.MouseClick += new MouseEventHandler(onMouseClick);//กด,ใช้พวกเม้าจะต้องเป็น += เสมอ
            scene.MouseDown += new MouseEventHandler(onMousedDown);//กดค้าง
            scene.MouseUp += new MouseEventHandler(onMouseUp);//กดแล้วปล่อย
            scene.MouseMove += new MouseEventHandler(onMouseMove);
        }

        private void onMouseMove(object sender, MouseEventArgs e)
        {
            if(hold == true && selectid > -1)
            {
                this.graph.getVertex(selectid).position.X = e.X;
                this.graph.getVertex(selectid).position.Y = e.Y;
            }
        }

        private void onMouseUp(object sender, MouseEventArgs e)
        {
            this.hold = false;
        }

        private void onMousedDown(object sender, MouseEventArgs e)
        {
            this.hold = true;
        }

        private void onMouseClick(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;

            selectNodeDistance(x, y);//เช็คก่อนว่าเม้าไปโดนโหนดไหนๆรึปล่าว

            if (selectid < 0)
                creatVertex(x, y);
            else
                addEdge(x, y);
            tempid = selectid; //อัพเดทเมื่อมีการสร้างโหนดใหม่
        }
        public double selectNodeDistance(int x,int y)
        {
            Vertex vtemp = new Vertex(-99, x, y);
            double result = 999;

            foreach(Vertex node in graph.getList())
            {
                result = Tools.getDistance(node, vtemp);
                if(result<Attribute.area)
                {
                    if (selectid > -1)
                        graph.getVertex(selectid).select(false);//ถ้ามากกว่า-1ให้ยกเลิกการselect
                    selectid = node.getID();
                    graph.getVertex(selectid).select(true);//ให้รับค่าใหม่แล้วselect vertectนั้น
                }
            }
            return result;
        }

        public void creatVertex(int x,int y)
        {
            if(selectid < 0)
            this.graph.insert(new Vertex(this.graph.getSize(), x, y));
        }
        public void addEdge(int x,int y)
        {
            if (tempid > -1)
            {
                this.graph.addEdge(this.graph.getVertex(selectid),
                                   this.graph.getVertex(tempid));
                this.graph.getVertex(selectid).select(false);
                selectid = -99;
            } 
        }
    }
}
