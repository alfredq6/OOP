using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2lab13.Shapes
{
    abstract public class ShapeBuilder
    {
        public ComplexShape ComplexShape { get; private set; }
        public void CreateComplexShape()
        {
            ComplexShape = new ComplexShape();
        }
        public abstract void SetInnerShape();
        public abstract void SetOuterShape();
    }
}
