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
        //Car car;
        Road road;
        int roadLength = 2000;

        public Form1()
        {
            InitializeComponent();
            canvas = splitContainer1.Panel2.CreateGraphics();
            PolygonMng = new PolygonManager();
            //car = new Car();
            road = new Road(roadLength);
            //PolygonMng.addPolygon(car.carShape);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Point[]> polygonsToDraw = PolygonMng.getPolygonsPointsList();

            foreach (Point[] p in polygonsToDraw)
	        {
		        canvas.DrawLines(new Pen(Color.Red), p );
	        }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PointVector pv = new PointVector((double)numericUpDown1.Value, (double)numericUpDown2.Value, (double)numericUpDown3.Value, (double)numericUpDown4.Value, (double)numericUpDown3.Value, (double)numericUpDown3.Value);
            MyVector velocity = new MyVector(0, 0);
            Triangle triangle = new Triangle(pv, velocity);
            PolygonMng.addPolygon(triangle);
            //road.addPolygon(triangle);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PolygonMng.movePolygons();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            road.VisibleArea.CurrentAreaPosition += 5;
            PolygonMng.setPolygonsList(road.getVisiblePolygons());
            //button3_Click(sender, e);
            //button1_Click(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
