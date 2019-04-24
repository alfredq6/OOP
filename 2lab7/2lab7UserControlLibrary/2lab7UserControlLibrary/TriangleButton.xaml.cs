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
    /// Логика взаимодействия для TriangleButton.xaml
    /// </summary>
    public partial class TriangleButton : UserControl
    {
        public TriangleButton()
        {
            InitializeComponent();
        }
        

        private void Polyline_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show(sender.ToString());
        }
    }
}
