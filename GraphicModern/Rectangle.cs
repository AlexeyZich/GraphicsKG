using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicModern
{
    [Serializable]
    public class Rectangle : Shape
    {
        public Rectangle(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
        {
            Points = new List<Point>(3);
            Points.Add(new Point(x1, y1));
            Points.Add(new Point(x2, y2));
            Points.Add(new Point(x3, y3));
            Points.Add(new Point(x4, y4));
        }

        public int Width { get { return Math.Abs(Points[1].X - Points[0].X); } } //  свойство которое получает ширину четырехугольника
        public int Height { get { return Math.Abs(Points[2].Y - Points[0].Y); } }

        public Point TopLeft
        {
            get
            {
                int top = int.MaxValue;
                int left = int.MaxValue;
                foreach (Point p in Points)
                {
                    if (p.X < left) left = p.X;
                    if (p.Y < top) top = p.Y;
                }
                return new Point(left, top);
            }
        }

        public Point BotRight
        {
            get
            {
                int bot = int.MinValue;
                int right = int.MinValue;
                foreach (Point p in Points)
                {
                    if (p.X > right) right = p.X;
                    if (p.Y > bot) bot = p.Y;
                }
                return new Point(right, bot);
            }
        }

        public bool isPointInRect(Point p)
        {
            if (p.X >= TopLeft.X && p.X <= BotRight.X && p.Y >= TopLeft.Y && p.Y <= BotRight.Y)
                return true;
            
            return false;
        } 
    }
}
