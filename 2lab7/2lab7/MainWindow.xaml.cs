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
using _2lab7UserControlLibrary;

namespace _2lab7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Phone> phones = new List<Phone>() { new IPhone("IPhone 6s", 250), new IPhone("IPhone 7", 500),
                                                new IPhone("IPhone 8", 600), new IPhone("IPhone 10", 900),
                                                new IPhone("IPhone 5s", 200), new IPhone("IPhone 10+", 1500),
                                                new Samsung("Samsung S4", 250), new Samsung("Samsung S5", 300),
                                                new Samsung("Samsung S6", 400), new Samsung("Samsung S7", 500),
                                                new Samsung("Samsung S8", 600), new Samsung("Samsung S9", 800)};

        public MainWindow()
        {
            InitializeComponent();
            SamsungCustomCheckBox.phone = (Phone)SamsungCustomCheckBox.DataContext;
            IPhoneCustomCheckBox.phone = (Phone)IPhoneCustomCheckBox.DataContext;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PhonesListBox.Items.Clear();

            if (SamsungCustomCheckBox.phone.Checked)
                foreach (var el in phones.Select(phone => phone.GetType() == typeof(Samsung) ? $"{((Samsung)phone).Title} Цена: {((Samsung)phone).Price}" : null))
                    if (el != null)
                        PhonesListBox.Items.Add(el);
            if (IPhoneCustomCheckBox.phone.Checked)
                foreach(var el in phones.Select(phone => phone.GetType() == typeof(IPhone) ? $"{((IPhone)phone).Title} Цена: {((IPhone)phone).Price}" : null))
                    if (el != null)
                        PhonesListBox.Items.Add(el);
        }

        public void Canvas_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show(sender.ToString());
        }

        private void AscendingSort_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Работаю");
        }

        private void CustomButton_CustomTap(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(sender.ToString());
        }
    }
}
