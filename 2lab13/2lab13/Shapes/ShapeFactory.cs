using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace _2lab13.Shapes
{
    public abstract class ShapeFactory : IShapePrototype
    {
        public abstract Brush FillColor { get; set; }
        public abstract double Width { get; set; }
        public abstract double Height { get; set; }
        public abstract IShapePrototype Clone();
    }
}
