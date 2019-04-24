using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2lab7UserControlLibrary
{
    /// <summary>
    /// Логика взаимодействия для CustomRadioButton.xaml
    /// </summary>
    public partial class CustomCheckBox : UserControl
    {
        static bool isActive = false;
        public Phone phone;

        public CustomCheckBox()
        {
            InitializeComponent();
            phone = new Phone();
        }

        private void InnerCircle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isActive)
            {
                InnerCircle.Opacity = 1.0;
                isActive = false;
                phone.Checked = true;
            }
            else
            {
                InnerCircle.Opacity = 0.0;
                isActive = true;
                phone.Checked = false;
            }
        }
    }
}
