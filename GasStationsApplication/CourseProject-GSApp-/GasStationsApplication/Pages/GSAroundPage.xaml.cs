using GSAppLogic.Services;
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

namespace GasStationsApplication.Pages
{
    /// <summary>
    /// Логика взаимодействия для GSAroundPage.xaml
    /// </summary>
    public partial class GSAroundPage : Page
    {
        public GSAroundPage()
        {
            InitializeComponent();
        }

        private void LoadLink(string fuelName)
        {
            var fuelType = Provider.GetProvider().GetAllFuelTypes().FirstOrDefault(x => x.Name == fuelName);
            browser.Address = fuelType?.MapLink;

        }
        private void A92_Click(object sender, RoutedEventArgs e)
        {
            LoadLink("A92");
            ListViewWithGS.Items.Clear();
            foreach (var el in App.GSListBoxItems_92)
                ListViewWithGS.Items.Add(el);
        }
        private void A95_Click(object sender, RoutedEventArgs e)
        {
            LoadLink("A95");
            ListViewWithGS.Items.Clear();
            foreach (var el in App.GSListBoxItems_95)
                ListViewWithGS.Items.Add(el);
        }
        private void A98_Click(object sender, RoutedEventArgs e)
        {
            LoadLink("A98");
            ListViewWithGS.Items.Clear();
            foreach (var el in App.GSListBoxItems_98)
                ListViewWithGS.Items.Add(el);
        }
        private void DT_Click(object sender, RoutedEventArgs e)
        {
            LoadLink("DT");
            ListViewWithGS.Items.Clear();
            foreach (var el in App.GSListBoxItems_DT)
                ListViewWithGS.Items.Add(el);
        }
        private void GAS_Click(object sender, RoutedEventArgs e)
        {
            LoadLink("GAS");
            ListViewWithGS.Items.Clear();
            foreach (var el in App.GSListBoxItems_GAS)
                ListViewWithGS.Items.Add(el);
        }

        private void CurrPos_Click(object sender, RoutedEventArgs e)
        {
            App.geolocation = Geolocation.GetGeolocation();
            var currLink = browser.Address;
            var newMap = App.geolocation.GetCurrentPositionOnMap(currLink.Substring(8));
            browser.Address = newMap;
        }
    }
}
