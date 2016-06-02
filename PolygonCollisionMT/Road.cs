using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PolygonCollisionMT
{
    public class Road
    {
        private List<Polygon> _polygons;
        public List<Polygon> VisiblePolygons { get; set; }
        public Area VisibleArea { get; set; }

        public Road()
        {
            VisibleArea = new Area(300,400);
        }

    }
}
