using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloGameEngine
{
    class Tools
    {
        public static double getDistance(Vertex A,Vertex B)//เป็นการหาจุดศูนย์กลางทำให้เส้นเชื่อมอยู่กลางจุด 
        {
            double X = Math.Pow((A.position.X - B.position.X), 2);
            double Y = Math.Pow((A.position.Y - B.position.Y), 2);

            return Math.Sqrt(X + Y);
        }

        public static double getDistance(Vector2 A, Vector2 B)
        {
            double X = Math.Pow((A.X - B.X), 2);
            double Y = Math.Pow((A.Y - B.Y), 2);

            return Math.Sqrt(X + Y);
        }
    }
}
