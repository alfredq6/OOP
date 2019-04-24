using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _2lab7UserControlLibrary
{
    public class Phone : DependencyObject
    {
        public static readonly DependencyProperty CheckedProperty;
        public static readonly DependencyProperty PriceProperty;

        static Phone()
        {
            CheckedProperty = DependencyProperty.Register("Checked", typeof(bool), typeof(Phone));
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata();
            
            metadata.CoerceValueCallback = new CoerceValueCallback(CoercePriceValue);

            PriceProperty = DependencyProperty.Register("Price", typeof(int), typeof(Phone), metadata);
        }

        public int Price
        {
            get { return (int)GetValue(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }

        public bool Checked
        {
            get { return (bool)GetValue(CheckedProperty); }
            set { SetValue(CheckedProperty, value); }
        }

        public static object CoercePriceValue(DependencyObject d, object value)
        {
            if ((int)value > 1200)
                return 1200;
            return (int)value;
        }

        public static bool ValidatePriceValue(object value)
        {
            if ((int)value <= 0)
                return true;
            return false;
        }
    }
}
