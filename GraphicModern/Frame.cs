using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicModern
{
    [Serializable]
    public class Frame
    {
        public List<Shape> Shapes;
        public bool isSelectedArea = false;
        public Rectangle AreaSelectionRect;
        public Rectangle LocalSelectedAxis;
        public List<Shape> SelectedShapes;

        public Frame()
        {
            Shapes = new List<Shape>();
            SelectedShapes = new List<Shape>();
            isSelectedArea = false;
            AreaSelectionRect = null;
            LocalSelectedAxis = null;
        }
    }
}
