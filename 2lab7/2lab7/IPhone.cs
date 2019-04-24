using _2lab7UserControlLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _2lab7
{
    class IPhone : Phone
    {

        public static readonly DependencyProperty TitleProperty;

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        static IPhone()
        {
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata();
            TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(IPhone), metadata, new ValidateValueCallback(ValidateTitleValue));
        }

        public IPhone(string title, int price)
        {
            this.Title = title;
            this.Price = price;
        }

        public static bool ValidateTitleValue(object value)
        {
            if (value == null)
                return true;
            else
            {
                string currValue = ((string)value).ToLower();
                if (currValue.Contains("iphone"))
                    return true;
                return false;
            }
        }
    }
}
