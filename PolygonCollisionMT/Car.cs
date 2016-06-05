﻿using System;
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
            PointVector pv = new PointVector(x1,y1,x2,y2,x3,y3);
            MyVector velocity = new MyVector(0,0);

            carShape = new Triangle(pv, velocity);
        }
    }
}
