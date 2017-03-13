using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloGameEngine
{
    class PathFinder
    {
        private Graph graph;
        private Vertex targetvertex;//เพื่อเอามาใช้อ้างอิงว่าจะให้มันเดินไปที่โหนดอะไร
        private Transform transform;//ตำแหน่งobjที่ต้องการให้ขยับ
        private int movespeed;

        public PathFinder(Graph graph,Transform transform,int movespeed)
        {
            this.graph = graph;
            this.transform = transform;
            this.movespeed = movespeed;
        }

        public void randomVertexTarget()//หาvertexโดยการrandom
        {
            if(this.graph.getSize()>1 && targetvertex == null)//ถ้ามีโหนดมากกว่า1(คือ2โหนดขึ้นไป)ให้random && เพื่อให้โหนดมันมีค่าแล้วrandom
            {
                Random rand = new Random();//มีคลาสrandomอยู่แล้ว
                int randomnode = rand.Next(0, this.graph.getSize() - 1);
                targetvertex = this.graph.getVertex(randomnode);//0คือค่าต่ำสุดที่จะrandom เวลาที่กราฟมีมากกว่า1โหนดจะ-1
                //เช่น ถ้ามี2โหนด ก็จะมีโหนดที่ 0 และ 2-1 = 1

            }
        }

        public void moveToPoint()
        {
            double distance ;//เอาตำแหน่งของโหนดเป้าหมายใส่ลงไปในmethod Toolsที่Vector2
            int newx = 0;
            int newy = 0;

            if(targetvertex != null)
            {
                distance = Tools.getDistance(targetvertex.position, transform.position);
                if (targetvertex.getEdgeCount() > 0 && distance < 8)//8 ระยะที่ใกล้ที่สุดแล้ว
                {
                    Random rand = new Random();
                    targetvertex = targetvertex.getDestination(rand.Next(0, targetvertex.getEdgeCount() - 1));
                }

                if (transform.position.X < targetvertex.position.X)//เช็คแกนX
                    newx = transform.position.X + movespeed;
                else
                    newx = transform.position.X - movespeed;

                if (transform.position.Y < targetvertex.position.Y)//เช็คแกนY
                    newy = transform.position.Y + movespeed;
                else
                    newy = transform.position.Y - movespeed;

                transform.position = new Vector2(newx, newy);
            }
        }
    }
}
