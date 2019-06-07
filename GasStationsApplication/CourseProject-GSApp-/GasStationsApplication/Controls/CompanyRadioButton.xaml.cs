using GasStationsApplication.Windows;
using GSAppLogic.DTO;
using GSAppLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace GasStationsApplication.Controls
{
    /// <summary>
    /// Логика взаимодействия для CompanyCheckBox.xaml
    /// </summary>
    public partial class CompanyRadioButton : UserControl
    {
        public CompanyRadioButton()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var provider = Provider.GetProvider();
            var companyName = this.CompanyNameTxtBlock.Text;
            List<GasStationDTO> gsList = null;
            if (companyName == "Все")
                gsList = provider.GetAllGS().ToList();
            else
                gsList = provider.GetAllGS().Where(x => x.CompanyName == companyName).ToList();

            (App.Current as App).UpdateGSList(gsList);
        }
    }
}
