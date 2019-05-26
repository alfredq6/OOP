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
using System.Windows.Shapes;

namespace _2lab13
{
    /// <summary>
    /// Логика взаимодействия для CreateWin.xaml
    /// </summary>
    public partial class CreateWin : Window
    {
        public CreateWin()
        {
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (ShapesType.SelectedIndex == -1 || ShapesNumber.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите хоть что-нибудь");
            } 
            else
            {
                this.DialogResult = true;
            }
        }
    }
}
