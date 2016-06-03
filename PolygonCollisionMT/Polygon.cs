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
        protected virtual PointVector _polarCoordinates
        {
            get
            {
                return _polarCoordinates;
            }
        }

        public virtual double mass
        {
            get
            {
                return mass;
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

    }
}
