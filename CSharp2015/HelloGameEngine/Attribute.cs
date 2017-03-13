using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HelloGameEngine
{
    class Attribute//มีไว้เพื่อสร้างobjในครั้งเดียว
    {
        public static int speed = 5; //const = ค่าคงที่ ค่าที่ไม่มีการเปลี่ยนแปลง static=สามารถเอาไปใช้ในคลาสหรือmethodไหนก็ได้
        public static int area = 10;//กำหนดพื้นที่ไม่ให้เกิน

        public static SolidBrush vertexBrush = new SolidBrush(Color.Orange);
        public static SolidBrush selvertexBrush = new SolidBrush(Color.Pink);
        public static Pen edgePen = new Pen(Color.Olive);

        public static Vector2 vertexScale = new Vector2(10, 10);
    }

    enum direction//มีคุณสมบัติเหมือนintแต่เรียกใช้เป็นตัวอักษรและenumไม่จำเป็นต้องอยู่ภายใต้คลาส
    {
        Mid,Up,Down,Left,Right
    };
}
