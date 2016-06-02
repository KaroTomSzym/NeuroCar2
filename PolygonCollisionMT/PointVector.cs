using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PolygonCollisionMT
{
    public class PointVector
    {
        private List<MyVector> _points;

        public int Length
        {
            get
            {
                return _points.Count;
            }
        }

        public int PointDimension
        {
            get
            {
                return _points[0].Length;
            }
        }

        public MyVector GeometricCentre
        {
            get
            {
                MyVector tempMv = new MyVector();
                for(int i = 0 ; i < PointDimension ; i ++)
                {
                    tempMv.Add(0);
                }
                for (int i = 0; i < Length; i++)
                {
                    tempMv[0] += _points[i][0] / Length;
                    tempMv[1] += _points[i][1] / Length;
                }
                return tempMv;
            }
        }

        public PointVector()
        {
            _points = new List<MyVector>();
        }

        public MyVector this[int index]
        {
            get
            {
                return _points[index];
            }
        }

        public void Add(MyVector myVec)
        {
            _points.Add(myVec);
        }

        public Point[] getPointsTable()
        {
            Point[] pt = new Point[_points.Count];
            for (int i = 0; i < _points.Count; i++)
            {
                pt[i] = _points[i].getPoint();
            }
            return pt;
        }

        public static PointVector operator+(PointVector pv, MyVector mv)
        {
            if (pv.PointDimension != mv.Length)
                throw new Exception();

            PointVector tempPv = new PointVector();

            for (int i = 0; i < pv.Length; i++)
            {
                MyVector tempMv = new MyVector();
                for (int j = 0; j < pv.PointDimension; j++)
                {
                    tempMv.Add(pv[i][j] + mv[j]);
                }
                tempPv.Add(tempMv);
            }

            return tempPv;

        }

    }
}
