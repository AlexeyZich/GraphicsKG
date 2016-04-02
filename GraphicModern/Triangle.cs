using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicModern
{
    [Serializable]
    class Triangle: Shape
    {
        public Triangle(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            Points = new List<Point>(3);
            Points.Add(new Point(x1, y1));
            Points.Add(new Point(x2, y2));
            Points.Add(new Point(x3, y3));
        }
    }
}
