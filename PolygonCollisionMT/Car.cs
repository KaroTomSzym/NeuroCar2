using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PolygonCollisionMT
{
    public class Car
    {
        public Triangle carShape { get; set; }
        double x1 = 100, x2 = 130, x3, y1 = 280, y2 = 280, y3 = 240;
        public Car()
        {
            x3 = (x1 + x2) / 2;
            PointVector pv = new PointVector();
            MyVector mv1 = new MyVector();

            mv1.Add(x1);
            mv1.Add(y1);

            MyVector mv2 = new MyVector();
            mv2.Add(x2);
            mv2.Add(y2);

            MyVector mv3 = new MyVector();
            mv3.Add(x3);
            mv3.Add(y3);

            pv.Add(mv1);
            pv.Add(mv2);
            pv.Add(mv3);

            MyVector velocity = new MyVector();
            velocity.Add(1);
            velocity.Add(1);
            carShape = new Triangle(pv, velocity);
        }
    }
}
