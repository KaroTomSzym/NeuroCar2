﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PolygonCollisionMT
{
    public class Triangle : Polygon
    {

        public override MyVector MassCentre
        {
            get
            {
                return _points.GeometricCentre;
            }
        }

        public override double Mass
        {
            get
            {
                return MyMath.triangleSurface(_points);
            }
        }

        public Triangle(PointVector pv, MyVector velocity)
        {
            this._points = pv;
            this._velocity = velocity;
            this._angularVelocity = 0.1;
        }

        public override Point[] getPointsTable()
        {
            Point[] pt = new Point[_points.Length + 1];
            Point[] contour = _points.getPointsTable();
            for (int i = 0; i < _points.Length; i++)
            {
                pt[i] = contour[i];
            }
            pt[_points.Length] = _points[0].getPoint();

            return pt;
        }

        public override void shift()
        {
            _points = _points + _velocity;
        }

        public override void rotate()
        {
            _points = _points.rotate(_angularVelocity, MassCentre);
        }

        public override MyVector boundaryCollison(double minX, double maxX, double minY, double maxY)
        {

            MyVector minXPoint = _points.minCoordinatePoint(0);
            MyVector maxXPoint = _points.maxCoordinatePoint(0);
            MyVector minYPoint = _points.minCoordinatePoint(1);
            MyVector maxYPoint = _points.maxCoordinatePoint(1);

            if (minX > minXPoint[0])
            {
                return minXPoint;
            }
            if (maxX < maxXPoint[0])
            {
                return maxXPoint;
            }
            if (minY > minYPoint[1])
            {
                return minYPoint;
            }
            if (maxY < maxYPoint[1])
            {
                return minYPoint;
            }

            MyVector noCollison = new MyVector(-1, 0);
            return noCollison;
        }

        public override bool isPointInside(MyVector point)
        {
            double controlSurface = MyMath.triangleSurface(_points);

            double splitedSurface = MyMath.splitedTriangleSurface(_points, point);

            if (controlSurface == splitedSurface)
                return false;
            else
                return true;

        }
    }
}
