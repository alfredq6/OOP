using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace _2lab13.Shapes
{
    public class Rectangle : ShapeFactory
    {
        public override Brush FillColor { get { return Brushes.Lavender; } set { FillColor = value; } }
        public override double Height { get { return 80; } set { Height = value; } }
        public override double Width { get { return 80; } set { Width = value; } }

        public override IShapePrototype Clone()
        {
            return new Rectangle();
        }
    }
}
