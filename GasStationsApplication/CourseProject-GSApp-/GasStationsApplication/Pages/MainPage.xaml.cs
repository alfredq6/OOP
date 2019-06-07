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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GasStationsApplication;
using GasStationsApplication.Controls;
using GasStationsApplication.Windows;
using GSAppLogic.DTO;
using GSAppLogic.Services;
using MaterialDesignThemes.Wpf;

namespace GasStationsApplication.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void GSAround_Click(object sender, RoutedEventArgs e)
        {
            var gsArPage = App._GSAroundPage;
            (App.Current.MainWindow as MainWindow).MainFrame.NavigationService.Navigate(gsArPage);
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            SignUp signUpWin = new SignUp();
            if (signUpWin.ShowDialog() == true)
            {
                App.User = new UserDTO()
                {
                    Email = signUpWin._user.Email,
                    Name = signUpWin._user.Name,
                    Password = Crypto.HashPassword(signUpWin._user.Password)
                };
                LogInSettings();
                Provider.GetProvider().SaveUser(App.User);
            }
        }

        private void LogInUserButton_Click(object sender, RoutedEventArgs e)
        {
            SignIn signInWin = new SignIn();
            if (signInWin.ShowDialog() == true)
            {
                App.User = Provider.GetProvider().GetAllUsers().FirstOrDefault(x => x.Name == signInWin._user.Name);
                LogInSettings();
            }
        }

        private void LogInSettings()
        {
            (App.Current.MainWindow as MainWindow).AutorisedUserTxtBlock.Text = App.User.Name;
            LogInUserButton.Visibility = Visibility.Hidden;
            LogOutUserButton.Visibility = Visibility.Visible;

            App._GSPage.SendFeedbackButton.IsEnabled = true;
        }

        private void LogOutUserButton_Click(object sender, RoutedEventArgs e)
        {
            App.User = null;
            var win = (App.Current.MainWindow as MainWindow);
            win.AutorisedUserTxtBlock.Text = string.Empty;
            LogInUserButton.Visibility = Visibility.Visible;
            LogOutUserButton.Visibility = Visibility.Hidden;

            while (win.MainFrame.NavigationService.CanGoForward)
            {
                win.MainFrame.NavigationService.GoForward();
            }

            win.isJournalDelete = true;
            App._GSPage.SendFeedbackButton.IsEnabled = false;
        }

        private void UserFeedbacksButton_Click(object sender, RoutedEventArgs e)
        {
            if (App.User == null)
            {
                MessageBox.Show("Войдите, чтобы просмотреть ваши отзывы");
            }
            else
            {
                App._UserFeedBacksPage.UserFeedBacksStackPanel.Children.Clear();
                var feedbacks = Provider.GetProvider().GetAllFeedbacks().Where(x => x.UserName == App.User.Name).ToList();
                if (feedbacks.Count == 0)
                    App._UserFeedBacksPage.UserFeedBacksStackPanel.Children.Add(App._UserFeedBacksPage.DefaultFeedbacksNumber);
                else
                {
                    foreach (var feedback in feedbacks)
                    {
                        var item = new UserFeedbackItem();
                        item.FeedbackContentTextBox.Text = feedback.Content;
                        item.GSNameTxtBlock.Text = feedback.GasStationName;
                        item.FeedbackRatingBar.Value = feedback.Stars;
                        App._UserFeedBacksPage.UserFeedBacksStackPanel.Children.Add(item);
                    }
                }
                (App.Current.MainWindow as MainWindow).MainFrame.NavigationService.Navigate(App._UserFeedBacksPage);
            }
        }
    }
}
