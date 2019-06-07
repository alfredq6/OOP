using GasStationsApplication.Controls;
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

namespace GasStationsApplication.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListOfGSPage.xaml
    /// </summary>
    public partial class ListOfGSPage : Page
    {
        public ListOfGSPage()
        {
            InitializeComponent();
        }

        private void SortByRating(object value)
        {
            var gsList = Provider.GetProvider().GetAllGS().Where(x => x.AverageStars <= (int)value).ToList();
            gsList.Sort(new Comparator().CompareByRating);
            (App.Current as App).UpdateGSList(gsList);
        }

        private void SortByDistance(object value)
        {
            var gsList = Provider.GetProvider().GetAllGS().Where(x => x.distanceLength <= (double)value).ToList();
            gsList.Sort(new Comparator().CompareByDistance);
            (App.Current as App).UpdateGSList(gsList);
        }

        private void SortByFuelType(FuelTypeEnum fuelType)
        {
            var gsList = Provider.GetProvider().GetAllGS().ToList();
            var sortList = new List<GasStationDTO>();
            var comparator = new Comparator();
            switch (fuelType)
            {
                case FuelTypeEnum.None:
                    {
                        (App.Current as App).UpdateGSList(gsList);
                        break;
                    }
                case FuelTypeEnum.A92:
                    {
                        sortList = gsList.Where(x => x.AI92_Price != null).ToList();
                        sortList.Sort(comparator.CompareBy92Price);
                        (App.Current as App).UpdateGSList(sortList, FuelTypeEnum.A92);
                        break;
                    }
                case FuelTypeEnum.A95:
                    {
                        sortList = gsList.Where(x => x.AI95_Price != null).ToList();
                        sortList.Sort(comparator.CompareBy95Price);
                        (App.Current as App).UpdateGSList(sortList, FuelTypeEnum.A95);
                        break;
                    }
                case FuelTypeEnum.A98:
                    {
                        sortList = gsList.Where(x => x.AI98_Price != null).ToList();
                        sortList.Sort(comparator.CompareBy98Price);
                        (App.Current as App).UpdateGSList(sortList, FuelTypeEnum.A98);
                        break;
                    }
                case FuelTypeEnum.DT:
                    {
                        sortList = gsList.Where(x => x.DT_Price != null).ToList();
                        sortList.Sort(comparator.CompareByDTPrice);
                        (App.Current as App).UpdateGSList(sortList, FuelTypeEnum.DT);
                        break;
                    }
                case FuelTypeEnum.GAS:
                    {
                        sortList = gsList.Where(x => x.GAS_Price != null).ToList();
                        sortList.Sort(comparator.CompareByGASPrice);
                        (App.Current as App).UpdateGSList(sortList, FuelTypeEnum.GAS);
                        break;
                    }
            }
        }

        private void GSRatingBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<int> e)
        {
            if (App._ListOfGSPage != null)
                SortByRating(App._ListOfGSPage.GSRatingBar.Value);
        }

        private void DistanceSlider_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (App._ListOfGSPage != null)
                SortByDistance(App._ListOfGSPage.DistanceSlider.Value);
        }

        private void FuelTypeRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            switch ((sender as RadioButton).Name)
            {
                case "_All":
                    {
                        SortByFuelType(FuelTypeEnum.None);
                        break;
                    }
                case "_92":
                    {
                        SortByFuelType(FuelTypeEnum.A92);
                        break;
                    }
                case "_95":
                    {
                        SortByFuelType(FuelTypeEnum.A95);
                        break;
                    }
                case "_98":
                    {
                        SortByFuelType(FuelTypeEnum.A98);
                        break;
                    }
                case "_DT":
                    {
                        SortByFuelType(FuelTypeEnum.DT);
                        break;
                    }
                case "_GAS":
                    {
                        SortByFuelType(FuelTypeEnum.GAS);
                        break;
                    }
            }

        }
    }
}

