using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HelloGameEngine
{

    class Vertex
    {
        private int id;//เก็บที่อยู่ของจุดนั้น
        private bool selected;//มีไว้เมื่อเอาเม้าไปคลิกแล้วจุดจะเปลี่ยนสี
        private SolidBrush fill;

        public Vector2 position;
        private List<Edge> edges;

        public Vertex(int id,int x,int y)
        {
            this.id = id;
            this.selected = false;
            this.fill = Attribute.vertexBrush;

            this.position = new Vector2(x, y);
            this.edges = new List<Edge>();
        }

        public void addEdge(Vertex node)
        {
            Edge edge = new Edge(this, node);//สร้างเส้นขึ้นมาลอยๆ
            this.edges.Add(edge);//เพิ่มเส้นให้เชื่อมระหว่างจุด
        }
        public Vertex getDestination(int i) { return edges[i].getDestinationNode(); }//Destination=ปลายทาง
        public int getEdgeCount() { return this.edges.Count; }

        public int getID() { return this.id; }
        public void select(bool select) { this.selected = select; }//ไม่ว่าจะเป็นtrueหรือfalseก็จะเอามาใส่ในselected

        public bool hasNode(int id)//ไว้เช็คว่ามีการเชื่อมจุดซ้ำหรือไม่ เอาไว้แจ้งว่า
        {
            foreach(Edge edge in edges)//คือลูป เป็นการเอาค่าที่มีไปแทนในสมาชิกทุกตัวเมื่อครบทุกตัวแล้วก็จะออกจากลูปเอง
            {
                if (edge.getDestinationNode().getID() == id)
                    return true;
            }
            return false;
        }

        public void render(BufferedGraphics buffer)
        {
            foreach(Edge edge in edges)
            {
                buffer.Graphics.DrawLine(Attribute.edgePen, this.position.X, this.position.Y,
                                         edge.getDestinationNode().position.X,
                                         edge.getDestinationNode().position.Y);
                
            }
            if (selected == true)//จุดเป็นสีส้มถ้ากดเป็นสีชมพู
                fill = Attribute.selvertexBrush;
            else
                fill = Attribute.vertexBrush;

            buffer.Graphics.FillRectangle(fill,
                                        this.position.X - (Attribute.vertexScale.X / 2),
                                        this.position.Y - (Attribute.vertexScale.Y / 2),
                                        Attribute.vertexScale.X,
                                        Attribute.vertexScale.Y);
        }
    }

    class Edge
    {
        private Vertex originNode;//จุดต้น
        private Vertex destinationNode;//จุดปลาย
        private double distance;//ค่าน้ำหนักหรือระยะห่าง

        public Edge(Vertex v1,Vertex v2)
        {
            this.originNode = v1;
            this.destinationNode = v2;
            this.distance = Tools.getDistance(v1, v2);
        }

        public double getDistance() { return this.distance; }
        public Vertex getDestinationNode() { return this.destinationNode; }
    }

    class Graph : RenderObject //จะโชว์ในrenderหรือจะไม่โชว์
    {
        private bool showGraph;
        private List<Vertex> graph;

        public Graph()
        {
            this.showGraph = false;
            this.graph = new List<Vertex>();
        }

        public void insert(Vertex node)
        {
            this.graph.Add(node);
        }

        public void addEdge(Vertex v1,Vertex v2)
        {
            if (v1.hasNode(v2.getID()) == false)//ให้v1เช็คว่ามันมีIDเดียวกับของv2ไหม
            {
                v1.addEdge(v2);//ให้รู้ว่าv1จะเชื่อมไปv2
                v2.addEdge(v1);//ให้รู้ว่าv2มีv1เชื่อม
            }
            else
                Console.WriteLine("Cannot add Edge");
        }

        public int getSize() { return this.graph.Count; }
        public Vertex getVertex(int index) { return this.graph[index]; }
        public List<Vertex> getList() { return this.graph; }
        public void show(bool show)
        {
            this.showGraph = show;
        }

        public override void render(BufferedGraphics buffer)
        {
            if(showGraph == true)
            {
                foreach(Vertex node in this.graph)
                {
                    node.render(buffer);
                }
            }
        }
    }
}
