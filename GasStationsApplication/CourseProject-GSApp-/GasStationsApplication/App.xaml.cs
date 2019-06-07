using GasStationsApplication.Controls;
using GasStationsApplication.Pages;
using GasStationsApplication.Windows;
using GSAppLogic.Services;
using GSAppLogic.DTO;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace GasStationsApplication
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MainPage _MainPage { get; set; }
        public static GSAroundPage _GSAroundPage { get; set; }
        public static GSPage _GSPage { get; set; }
        public static UserFeedbacksPage _UserFeedBacksPage { get; set; }
        public static ListOfGSPage _ListOfGSPage { get; set; }
        public static AboutPage _AboutPage { get; set; }
        public static Geolocation geolocation { get; set; }
        public static UserDTO User { get; set; }
        public static List<ListBoxItem> GSListBoxItems_92 { get; private set; }
        public static List<ListBoxItem> GSListBoxItems_95 { get; private set; }
        public static List<ListBoxItem> GSListBoxItems_98 { get; private set; }
        public static List<ListBoxItem> GSListBoxItems_DT { get; private set; }
        public static List<ListBoxItem> GSListBoxItems_GAS { get; private set; }
        public static List<ListBoxItem> FullGSListItems { get; private set; }

        private void StratUpApp(object sender, StartupEventArgs e)
        {
            _MainPage = new MainPage();
            _GSAroundPage = new GSAroundPage();
            _UserFeedBacksPage = new UserFeedbacksPage();
            _GSPage = new GSPage();
            _ListOfGSPage = new ListOfGSPage();
            _AboutPage = new AboutPage();
            GSListBoxItems_92 = new List<ListBoxItem>();
            GSListBoxItems_95 = new List<ListBoxItem>();
            GSListBoxItems_98 = new List<ListBoxItem>();
            GSListBoxItems_DT = new List<ListBoxItem>();
            GSListBoxItems_GAS = new List<ListBoxItem>();
            FullGSListItems = new List<ListBoxItem>();
            App.geolocation = Geolocation.GetGeolocation();

            SetAllListOfGS();
            SetCompaniesPanel();
        }

        private void SetCompaniesPanel()
        {
            foreach (var company in Provider.GetProvider().GetAllCompanies())
            {
                var radioButton = new CompanyRadioButton();
                radioButton.CompanyNameTxtBlock.Text = company.Name;
                App._ListOfGSPage.CompaniesStackPanel.Children.Add(radioButton);
            }
        }

        public void AddGSToList(GasStationDTO gs)
        {
            FullGSListItems.Add(GetGSListItem(gs.CompanyName, gs.Name, gs.Adress, gs.distanceLength, gs.AverageStars, gs.FeedbacksNumber));
        }

        private void SetAllListOfGS()
        {
            var provider = Provider.GetProvider();
            var calculator = new FieldsCalculator();
            var list = provider.GetAllGS()
                .Select(x => x = calculator.CalculateDistance(x)).ToList()
                .Select(x => x = calculator.CalculateAverageStarsNumber(x)).ToList()
                .Select(x => x = calculator.CalculateFeedbacksNumber(x)).ToList();

            list.Sort(new Comparator().CompareByDistance);
            foreach (var gs in list)
            {
                AddGSToList(gs);

                if (gs.AI92_Price != null)
                {
                    GSListBoxItems_92.Add(GetGSListItem(gs.CompanyName, gs.Name, gs.Adress, gs.distanceLength, gs.AverageStars, gs.FeedbacksNumber, gs.AI92_Price));
                }
                if (gs.AI95_Price != null)
                {
                    GSListBoxItems_95.Add(GetGSListItem(gs.CompanyName, gs.Name, gs.Adress, gs.distanceLength, gs.AverageStars, gs.FeedbacksNumber, gs.AI95_Price));
                }
                if (gs.AI98_Price != null)
                {
                    GSListBoxItems_98.Add(GetGSListItem(gs.CompanyName, gs.Name, gs.Adress, gs.distanceLength, gs.AverageStars, gs.FeedbacksNumber, gs.AI98_Price));
                }
                if (gs.DT_Price != null)
                {
                    GSListBoxItems_DT.Add(GetGSListItem(gs.CompanyName, gs.Name, gs.Adress, gs.distanceLength, gs.AverageStars, gs.FeedbacksNumber, gs.DT_Price));
                }
                if (gs.GAS_Price != null)
                {
                    GSListBoxItems_GAS.Add(GetGSListItem(gs.CompanyName, gs.Name, gs.Adress, gs.distanceLength, gs.AverageStars, gs.FeedbacksNumber, gs.GAS_Price));
                }
            }

            foreach (var el in App.FullGSListItems)
                App._ListOfGSPage.FullGSList_listBox.Items.Add(el);
        }

        public ListBoxItem GetGSListItem(string companyName, string name, string address, double distance, int stars, int? feedbacksNumber, decimal? price = null)
        {
            var listBoxItem = new ListBoxItem() { Background = Brushes.White, HorizontalContentAlignment = HorizontalAlignment.Stretch };
            var item = new GSListItemWithPrice();
            item.GSNameTxtBlock.Text = name;
            item.GSAdressTxtBlock.Text = address;
            item.DistanceTxtBlock.Text = Math.Round(distance, 3).ToString() + " км";
            item.FuelPriceTxtBlock.Text = price?.ToString();
            item.GSRatingBar.Value = stars;
            item.GSFeedbacksNumberTxtBlock.Text = $"Отзывов: ({feedbacksNumber?.ToString() ?? "0"})";
            listBoxItem.Content = item;
            listBoxItem.MouseUp += GS_MouseUp;
            return listBoxItem;
        }

        private void GS_MouseUp(object sender, MouseButtonEventArgs e)
        {
            App._GSPage.FeedBackRatingBar.Value = 0;
            App._GSPage.FeedBackTextBox.Text = string.Empty;

            (App.Current as App).SetGSNameAndAdress((sender as ListBoxItem).Content as GSListItemWithPrice);
            (App.Current as App).SetFuelPricesGrid();
            (App.Current as App).SetFeedBacksList();
            if (App.User != null)
            {
                App._GSPage.SendFeedbackButton.IsEnabled = true;
            }
            else
            {
                App._GSPage.SendFeedbackButton.IsEnabled = false;
            }
            ((App.Current as App).MainWindow as MainWindow).MainFrame.NavigationService.Navigate(App._GSPage);
        }

        public void SetFeedBacksList()
        {
            var provider = Provider.GetProvider();
            var gs = provider.GetAllGS().FirstOrDefault(x => x.Name == App._GSPage.GSNameTxtBlock.Text);
            var listFeedbacks = provider.GetAllFeedbacks()?.Where(x => x.GasStationName == App._GSPage.GSNameTxtBlock.Text).ToList();
            App._GSPage.FeedbacksListBox.Items.Clear();
            if (listFeedbacks?.Count == 0)
            {
                App._GSPage.FeedbacksListBox.Items.Add(App._GSPage.DefaultFeedbackNumberListBoxItem);
            }
            else
            {
                foreach (var el in listFeedbacks)
                {
                    var feedbackListBoxItem = new ListBoxItem() { HorizontalContentAlignment = HorizontalAlignment.Stretch, IsHitTestVisible = false };
                    var item = new FeedbackListItem();
                    item.UserNameTxtBlock.Text = el.UserName;
                    item.FeedbackRatingBar.Value = el.Stars;
                    item.FeedbackContentTxtBlock.Text = el.Content;
                    feedbackListBoxItem.Content = item;
                    App._GSPage.FeedbacksListBox.Items.Add(feedbackListBoxItem);
                }
            }
        }

        public void SetGSNameAndAdress(GSListItemWithPrice control)
        {
            App._GSPage.GSNameTxtBlock.Text = control.GSNameTxtBlock.Text;
            App._GSPage.GSAdressTxtBlock.Text = control.GSAdressTxtBlock.Text;
        }

        public void SetFuelPricesGrid()
        {
            var currentGS = Provider.GetProvider().GetAllGS().FirstOrDefault(gs => gs.Name == App._GSPage?.GSNameTxtBlock.Text);
            if (currentGS?.AI92_Price != null)
            {
                App._GSPage.Price92.Text = currentGS.AI92_Price.ToString();
            }
            else
            {
                App._GSPage.Price92.Text = "-";
            }
            if (currentGS?.AI95_Price != null)
            {
                App._GSPage.Price95.Text = currentGS.AI95_Price.ToString();
            }
            else
            {
                App._GSPage.Price95.Text = "-";
            }
            if (currentGS?.AI98_Price != null)
            {
                App._GSPage.Price98.Text = currentGS.AI98_Price.ToString();
            }
            else
            {
                App._GSPage.Price98.Text = "-";
            }
            if (currentGS?.DT_Price != null)
            {
                App._GSPage.PriceDT.Text = currentGS.DT_Price.ToString();
            }
            else
            {
                App._GSPage.PriceDT.Text = "-";
            }
            if (currentGS?.GAS_Price != null)
            {
                App._GSPage.PriceGAS.Text = currentGS.GAS_Price.ToString();
            }
            else
            {
                App._GSPage.PriceGAS.Text = "-";
            }
        }

        public void UpdateGSList(List<GasStationDTO> gsList, FuelTypeEnum fuelType = FuelTypeEnum.None)
        {
            if (App._ListOfGSPage != null)
            {
                App._ListOfGSPage.FullGSList_listBox.Items.Clear();
                foreach (var gs in gsList)
                {
                    var item = App.FullGSListItems.FirstOrDefault(x => (x.Content as GSListItemWithPrice).GSNameTxtBlock.Text == gs.Name);
                    var gsListItem_control = item.Content as GSListItemWithPrice;
                    decimal? price = null;
                    gsListItem_control.GSFeedbacksNumberTxtBlock.Text = $"Отзывов ({gs.FeedbacksNumber.ToString()})";
                    gsListItem_control.GSRatingBar.Value = gs.AverageStars;
                    if (fuelType != FuelTypeEnum.None)
                    {
                        switch (fuelType)
                        {
                            case FuelTypeEnum.A92:
                                {
                                    price = gs.AI92_Price;
                                    break;
                                }
                            case FuelTypeEnum.A95:
                                {
                                    price = gs.AI95_Price;
                                    break;
                                }
                            case FuelTypeEnum.A98:
                                {
                                    price = gs.AI98_Price;
                                    break;
                                }
                            case FuelTypeEnum.DT:
                                {
                                    price = gs.DT_Price;
                                    break;
                                }
                            case FuelTypeEnum.GAS:
                                {
                                    price = gs.GAS_Price;
                                    break;
                                }
                        }
                    }
                    gsListItem_control.FuelPriceTxtBlock.Text = price?.ToString();
                    App._ListOfGSPage.FullGSList_listBox.Items.Add(item);
                }
            }
        }

        public Window GetNewWindow(FrameworkElement element)
        {
            var window = new Window();
            var grid = new Grid();
            grid.Children.Add(element);
            window.Content = grid;
            return window;
        }
    }
}

