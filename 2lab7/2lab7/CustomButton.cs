using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace _2lab7
{
    class CustomButton : Button
    {
        public static readonly RoutedEvent CustomTapEvent = EventManager.RegisterRoutedEvent(
        "Tap", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(CustomButton));

        public event RoutedEventHandler CustomTap
        {
            add { AddHandler(CustomTapEvent, value); }
            remove { RemoveHandler(CustomTapEvent, value); }
        }

        void RaiseTapEvent()
        {
            base.OnClick();
            RoutedEventArgs newEventArgs = new RoutedEventArgs(CustomButton.CustomTapEvent);
            RaiseEvent(newEventArgs);
        }
        protected override void OnClick()
        {
            MessageBox.Show(this.ToString());
            RaiseTapEvent();
        }

    }
}
