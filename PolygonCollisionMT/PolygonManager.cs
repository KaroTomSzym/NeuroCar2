using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PolygonCollisionMT
{
    public class PolygonManager
    {
        private List<Polygon> _polygons;

        public PolygonManager()
        {
            _polygons = new List<Polygon>();
        }

        public void addPolygon(Polygon p)
        {
            _polygons.Add(p);
        }

        public List<Point[]> getPolygonsPointsList()
        {
            List<Point[]> polygonsPointsList = new List<Point[]>();
            foreach (Polygon p in _polygons)
	        {
                polygonsPointsList.Add(p.getPointsTable());
	        }
            return polygonsPointsList;
        }

        public void movePolygons()
        {
            foreach (Polygon p in _polygons)
            {
                p.shift();
            }
        }
    }
}
