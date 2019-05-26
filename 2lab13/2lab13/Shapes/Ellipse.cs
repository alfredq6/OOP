using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace _2lab13.Shapes
{
    public class Ellipse : ShapeFactory
    {
        public override Brush FillColor { get { return Brushes.Chocolate; } set { FillColor = value; } }
        public override double Height { get { return 100; } set { Height = value; } }
        public override double Width { get { return 100; } set { Width = value; } }

        public override IShapePrototype Clone()
        {
            return new Ellipse();
        }
    }
}
