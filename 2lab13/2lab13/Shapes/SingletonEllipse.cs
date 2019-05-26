using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace _2lab13.Shapes
{
    public class SingletonEllipse : ShapeFactory
    {
        public override Brush FillColor { get { return Brushes.Gold; } set { FillColor = value; } }
        public override double Height { get { return 50; } set { Height = value; } }
        public override double Width { get { return 50; } set { Width = value; } }
        private static SingletonEllipse singletonEllipse;

        private SingletonEllipse() { }

        public static SingletonEllipse Get()
        {
            singletonEllipse = singletonEllipse ?? new SingletonEllipse();
            return singletonEllipse;
        }

        public override IShapePrototype Clone()
        {
            return singletonEllipse;
        }
    }
}
