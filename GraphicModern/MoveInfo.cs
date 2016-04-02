using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicModern
{
    class MoveInfo
    {
        public Shape Shape;
        public List<Point> StartPoints { get; set; } //точки начального положения
        public Point StartMousePoint; // координаты курсора в моменты клика
    }
}
