﻿using System;
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
        public Polygon carPolygon;
        //
        public MyVector lastForce;
        //
        public PolygonManager(int boundaryX, int boundaryY,Polygon car)
        {
            _polygons = new List<Polygon>();
            _boundaryX = boundaryX;
            _boundaryY = boundaryY;
            startThread();
            running = true;
            //
            carPolygon = car;
            lastForce = new MyVector(0,0);
            //
        }

        public void threadAction(object data)
        {
            while (true)
            {
                if (running)
                movePolygons();

                Thread.Sleep(10);
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
                polygonsPointsList.Add(carPolygon.getPointsTable());
            }
            catch (InvalidOperationException)
            {
                return polygonsPointsList;
            }
            
            return polygonsPointsList;
        }

        public void movePolygons()
        {
            
            checkBoundaryCollisions();
            checkObstacleCollison();
            try
            {
                foreach (Polygon p in _polygons)
                {
                    p.shift();
                    p.rotate();
                }
                carPolygon.shift();
                carPolygon.rotate();
            } 
            catch(InvalidOperationException){

            }
            
        }

        public void checkObstacleCollison()
        {
            foreach (Polygon p in _polygons)
            {
                MyVector contactPoint = carPolygon.polygonCollision(p);
                if (contactPoint[0] != -1)
                {
                    MyVector massCentre = carPolygon.MassCentre - p.MassCentre;
                    MyVector force = carPolygon.getForceVector(contactPoint);
                    Double forceValue = MyMath.normVector(force);
                    force =  MyMath.normalizeVector(force+massCentre) * forceValue;
                    carPolygon.actForce(contactPoint, force);
                    //p.actForce(contactPoint, force*-1);
                }
                else
                {
                    MyVector contactPoint2 = p.polygonCollision(carPolygon);
                    if (contactPoint2[0] != -1)
                    {
                        MyVector massCentre = carPolygon.MassCentre - p.MassCentre;
                        MyVector force = carPolygon.getForceVector(contactPoint2);
                        Double forceValue = MyMath.normVector(force);
                        force = MyMath.normalizeVector(force + massCentre) * forceValue;
                        carPolygon.actForce(contactPoint2, force);
                        //p.actForce(contactPoint2, force * -1);
                    }
                }
            }
        }

        public void checkBoundaryCollisions()
        {

            MyVector contactPoint = carPolygon.boundaryCollison(0, _boundaryX, 0, _boundaryY);
            //boundary collison zwraca punkt (-1,0) jeśli brak kolizji
            if (contactPoint[0] != -1)
            {
                //x=0 lub x = max
                if (contactPoint[0] < 0 || contactPoint[0] > _boundaryX)
                {
                    MyVector force = carPolygon.getForceVector(contactPoint);
                    force[0] *= -1;
                    carPolygon.actForce(contactPoint, force);
                    lastForce = force;
                }
                //y=0 lub y = max
                if (contactPoint[1] < 0 || contactPoint[1] > _boundaryY)
                {
                    MyVector force = carPolygon.getForceVector(contactPoint);
                    force[1] *= -1;
                    carPolygon.actForce(contactPoint, force);
                    lastForce = force;
                }
            }
            //foreach (Polygon p in _polygons)
            //{
            //    MyVector contactPoint = p.boundaryCollison(0, _boundaryX, 0, _boundaryY);
            //    //boundary collison zwraca punkt (-1,0) jeśli brak kolizji
            //    if (contactPoint[0] != -1)
            //    {
            //        //x=0 lub x = max
            //        if (contactPoint[0] < 0 || contactPoint[0] > _boundaryX)
            //        {
            //            MyVector force = p.getForceVector(contactPoint);
            //            force[0] *= -1;
            //            p.actForce(contactPoint, force);
            //            lastForce = force;
            //        }
            //        //y=0 lub y = max
            //        if (contactPoint[1] < 0 || contactPoint[1] > _boundaryY)
            //        {
            //            MyVector force = p.getForceVector(contactPoint);
            //            force[1] *= -1;
            //            p.actForce(contactPoint, force);
            //            lastForce = force;
            //        }
            //    }
            //}        
        }
    }
}
