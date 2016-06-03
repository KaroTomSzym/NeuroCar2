using System;
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
        protected override PointVector _polarCoordinates
        {
            get
            {
                PointVector coordsRelativeToMassCenter = _points - MassCentre;
                PointVector polarCoords = new PointVector();
                for (int i = 0; i < _points.Length; i++)
                {
                    polarCoords.Add(MyMath.polarRepresentation(coordsRelativeToMassCenter[i]));
                }
                return polarCoords;
            }
        }
        public Triangle(PointVector pv, MyVector velocity)
        {
            this._points = pv;
            this._velocity = velocity;
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

        }
    }
}
