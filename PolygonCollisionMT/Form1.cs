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
        Car car;

        public Form1()
        {
            InitializeComponent();
            canvas = splitContainer1.Panel2.CreateGraphics();
            PolygonMng = new PolygonManager();
            car = new Car();
            PolygonMng.addPolygon(car.carShape);

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
            PointVector pv = new PointVector();

            MyVector mv1 = new MyVector();
            mv1.Add((double)numericUpDown1.Value);
            mv1.Add((double)numericUpDown2.Value);

            MyVector mv2 = new MyVector();
            mv2.Add((double)numericUpDown3.Value);
            mv2.Add((double)numericUpDown4.Value);

            MyVector mv3 = new MyVector();
            mv3.Add((double)numericUpDown3.Value);
            mv3.Add((double)numericUpDown3.Value);

            pv.Add(mv1);
            pv.Add(mv2);
            pv.Add(mv3);

            MyVector velocity = new MyVector();
            velocity.Add(1);
            velocity.Add(2);


            PolygonMng.addPolygon(new Triangle(pv, velocity));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PolygonMng.movePolygons();
        }
    }
}
