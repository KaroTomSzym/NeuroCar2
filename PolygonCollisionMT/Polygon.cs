using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PolygonCollisionMT
{
    public abstract class Polygon
    {
        protected PointVector _points;
        protected MyVector _velocity;
        protected double _angularVelocity;

        public virtual double Mass
        {
            get
            {
                return Mass;
            }
        }
        public virtual MyVector MassCentre
        {
            get
            {
                return MassCentre;
            }
        }

        public abstract Point[] getPointsTable();
        public abstract void shift();
        public abstract void rotate();

        //Jeśli brak kolizji to zwróci (-1,?)
        public abstract MyVector boundaryCollison(double minX, double maxX, double minY, double maxY);

        public abstract bool isPointInside(MyVector point);
    }
}
