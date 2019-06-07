using CefSharp.Wpf;
using GSAppLogic.DTO;
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
    /// Логика взаимодействия для GSPage.xaml
    /// </summary>
    public partial class GSPage : Page
    {
        public GSPage()
        {
            InitializeComponent();
        }

        private void SetNavigation_Click(object sender, RoutedEventArgs e)
        {
            var currentGS = Provider.GetProvider().GetAllGS().FirstOrDefault(x => x.Name == GSNameTxtBlock.Text);
            var browser = new ChromiumWebBrowser();
            var win = (App.Current as App).GetNewWindow(browser);
            browser.Address = $@"www.google.com/maps/dir/?api=1&origin={App.geolocation.Latitude.ToString().Replace(',','.')}+{App.geolocation.Longtitude.ToString().Replace(',', '.')}&destination={currentGS.Lat.ToString().Replace(',', '.')}+{currentGS.Lng.ToString().Replace(',', '.')}&travelmode=driving&hl=ru";
            win.Show();
        }

        private void CompanyLinkButton_Click(object sender, RoutedEventArgs e)
        {
            var provider = Provider.GetProvider();
            var currentGS = provider.GetAllGS().FirstOrDefault(x => x.Name == GSNameTxtBlock.Text);
            var browser = new ChromiumWebBrowser();
            var win = (App.Current as App).GetNewWindow(browser);
            browser.Address = provider.GetAllCompanies().FirstOrDefault(x => x.Name == currentGS.CompanyName).WebSiteLink;
            win.Show();
        }

        private void SendFeedbackButton_Click(object sender, RoutedEventArgs e)
        {
            if (FeedBackRatingBar.Value == 0)
            {
                MessageBox.Show("Поставте хотя бы 1 звезду");
            }
            else if (FeedBackTextBox.Text?.Length < 3 || FeedBackTextBox.Text?.Length > 1000)
            {
                MessageBox.Show("Минимальная длина отзыва - 3, максимаьная - 1000");
            }
            else
            {
                try
                {
                    var provider = Provider.GetProvider();
                    var calculator = new FieldsCalculator();
                    var feedback = new FeedbackDTO()
                    {
                        Name = App.User.Name + provider.GetAllGS().FirstOrDefault(x => x.Name == GSNameTxtBlock.Text).Name,
                        UserName = App.User.Name,
                        GasStationName = provider.GetAllGS().FirstOrDefault(x => x.Name == GSNameTxtBlock.Text).Name,
                        Content = FeedBackTextBox.Text,
                        Stars = FeedBackRatingBar.Value
                    };
                    provider.SaveFeedback(feedback);
                    var currGS = provider.GetAllGS().FirstOrDefault(x => x.Name == feedback.GasStationName);
                    calculator.CalculateFeedbacksNumber(currGS);
                    calculator.CalculateAverageStarsNumber(currGS);
                    (App.Current as App).SetFeedBacksList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Вы можете оставить только один отзыв для данной АЗС");
                }
            }
        }

        private void FeedBackTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            LeftSymbolsTextBlock.Text = "Осталось символов: " + (1000 - FeedBackTextBox.Text?.Length);
        }
    }
}
