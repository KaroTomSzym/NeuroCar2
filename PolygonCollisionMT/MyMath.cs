using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonCollisionMT
{
    class MyMath
    {
        public static MyVector polarRepresentation(MyVector vector)
        {
            double norm = vector.Length;
            double angle;
            MyVector normalVec = vector.normalVector();

            if (normalVec[0] > 0)
            {
                angle = Math.Acos(normalVec[1]);
            }
            else
            {
                angle = 2 * Math.PI - Math.Acos(normalVec[1]);
            }

            MyVector polarForm = new MyVector(norm, angle);
            return polarForm;
        }
        public static double triangleSurface(PointVector triangleVertices)
        {
            if (triangleVertices.Length != 3 || triangleVertices.PointDimension != 2)
            {
                throw new Exception();
            }

            double xA = triangleVertices[0][0];
            double yA = triangleVertices[0][1];
            double xB = triangleVertices[1][0];
            double yB = triangleVertices[1][1];
            double xC = triangleVertices[2][0];
            double yC = triangleVertices[2][1];
            double surface = 0.5 * Math.Abs((xB - xA) * (yC - yA) - (yB - yA) * (xC - xA));

            return surface;
        }


    }
}
