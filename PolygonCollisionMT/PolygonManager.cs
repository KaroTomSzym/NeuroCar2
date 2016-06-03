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
        private int _boundaryX;
        private int _boundaryY;
        public PolygonManager(int boundaryX, int boundaryY)
        {
            _polygons = new List<Polygon>();
            _boundaryX = boundaryX;
            _boundaryY = boundaryY;
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
            checkCollisions();
            foreach (Polygon p in _polygons)
            {
                p.shift();
                p.rotate();
            }
        }

        public void checkCollisions()
        {
            List<Polygon> polygonsToRemove = new List<Polygon>();
            foreach (Polygon p in _polygons)
            {
                //boundary collison zwraca punkt (-1,0) jeśli brak kolizji
                if (p.boundaryCollison(0, _boundaryX, 0, _boundaryY)[0] != -1)
                {
                    polygonsToRemove.Add(p);
                }
            }
            foreach (Polygon p in polygonsToRemove)
	        {
                _polygons.Remove(p);
	        }
        }
    }
}
