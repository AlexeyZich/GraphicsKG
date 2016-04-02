using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicModern
{
    [Serializable]
    public abstract class Shape
    {
        public List<Point> Points { get; set; }
    }
}
