using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace PolygonCollisionMT
{
    public class PolygonManager
    {
        private List<Polygon> _polygons;
        private int _boundaryX;
        private int _boundaryY;
        private Thread PolygonManagerThread;
        private bool running;
        public PolygonManager(int boundaryX, int boundaryY)
        {
            _polygons = new List<Polygon>();
            _boundaryX = boundaryX;
            _boundaryY = boundaryY;
            startThread();
            running = true;
        }

        public void threadAction(object data)
        {
            while (true)
            {
                if (running)
                movePolygons();

                Thread.Sleep(50);
            }
        }

        public void startThread()
        {
            PolygonManagerThread = new Thread(this.threadAction);
            PolygonManagerThread.Start();
        }

        public void stopThread()
        {
            PolygonManagerThread.Abort();
        }

        public void addPolygon(Polygon p)
        {
            _polygons.Add(p);
        }

        public List<Point[]> getPolygonsPointsList()
        {
            List<Point[]> polygonsPointsList = new List<Point[]>();

            try
            {
                foreach (Polygon p in _polygons)
                {
                    polygonsPointsList.Add(p.getPointsTable());
                }
            }
            catch (InvalidOperationException)
            {
                return polygonsPointsList;
            }
            
            return polygonsPointsList;
        }

        public void movePolygons()
        {
            
            checkCollisions();

            try
            {
                foreach (Polygon p in _polygons)
                {
                    p.shift();
                    p.rotate();
                }
                running = true;
            } 
            catch(InvalidOperationException){

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
            if (polygonsToRemove.Count > 0)
            {
                foreach (Polygon p in polygonsToRemove)
                {
                    _polygons.Remove(p);
                }                      
            }         
        }
    }
}
