using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicModern
{
    [Serializable]
    public class Line: Shape
    {
        public Line(int x1, int y1, int x2, int y2)
        {
            Points = new List<Point>(2);
            Points.Add(new Point(x1, y1));
            Points.Add(new Point(x2, y2));
        }
    }
}
