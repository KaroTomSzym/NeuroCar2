using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolygonCollisionMT
{
    public partial class Form1 : Form
    {
        Graphics canvas;
        PolygonManager PolygonMng;
        Polygon Car;

        public Form1()
        {
            InitializeComponent();
            canvas = splitContainer1.Panel2.CreateGraphics();
            int boundaryX = splitContainer1.Panel2.Width;
            int boundaryY = splitContainer1.Panel2.Height;

            //
            PointVector pv = new PointVector();

            MyVector mv1 = new MyVector();
            mv1.Add((double)numericUpDown1.Value);
            mv1.Add((double)numericUpDown2.Value);

            MyVector mv2 = new MyVector();
            mv2.Add((double)numericUpDown3.Value);
            mv2.Add((double)numericUpDown4.Value);

            MyVector mv3 = new MyVector();
            mv3.Add((double)numericUpDown5.Value);
            mv3.Add((double)numericUpDown6.Value);

            pv.Add(mv1);
            pv.Add(mv2);
            pv.Add(mv3);

            MyVector velocity = new MyVector();
            velocity.Add(1);
            velocity.Add(-1);

            Car = new Triangle(pv, velocity);
            //
            PolygonMng = new PolygonManager(boundaryX, boundaryY, Car);
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PointVector pv = new PointVector();

            MyVector mv1 = new MyVector();
            mv1.Add((double)numericUpDown1.Value);
            mv1.Add((double)numericUpDown2.Value);

            MyVector mv2 = new MyVector();
            mv2.Add((double)numericUpDown3.Value);
            mv2.Add((double)numericUpDown4.Value);

            MyVector mv3 = new MyVector();
            mv3.Add((double)numericUpDown5.Value);
            mv3.Add((double)numericUpDown6.Value);

            pv.Add(mv1);
            pv.Add(mv2);
            pv.Add(mv3);

            MyVector velocity = new MyVector();
            velocity.Add(0);
            velocity.Add(0);

            Car = new Triangle(pv, velocity);
            //PolygonMng.addPolygon(Car);
            //CarControl = new CarControler(Car);

            MyVector obstacleVec = new MyVector(0, 69);
            pv += obstacleVec;
            PolygonMng.addPolygon(new Triangle(pv, velocity));
            pv += obstacleVec; pv += obstacleVec;
            pv += obstacleVec;
            PolygonMng.addPolygon(new Triangle(pv, velocity));

            obstacleVec = new MyVector(69, 0);
            pv += obstacleVec;
            PolygonMng.addPolygon(new Triangle(pv, velocity));

            MyVector p1 = new MyVector(50, 50);
            MyVector p2 = new MyVector(89, 100);
            MyVector p3 = new MyVector(100, 100);
            MyVector p4 = new MyVector(100, 67);
            PointVector tetra = new PointVector();
            tetra.Add(p1);
            tetra.Add(p2);
            tetra.Add(p3);
            tetra.Add(p4);
            Tetragon tetragon = new Tetragon(tetra);
            PolygonMng.addPolygon(tetragon);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            PolygonMng.movePolygons();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                List<Point[]> polygonsToDraw = PolygonMng.getPolygonsPointsList();
                canvas.Clear(Color.White);
                foreach (Point[] p in polygonsToDraw)
                {
                    canvas.DrawLines(new Pen(Color.Red), p);
                }
            }
            catch (Exception)
            {

            }
            textBox1.Text = PolygonMng.lastForce.ToString();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            PolygonMng.stopThread();
        }

        private void button2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
