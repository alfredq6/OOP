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

namespace GasStationsApplication.Controls
{
    /// <summary>
    /// Логика взаимодействия для UserFeedbackItem.xaml
    /// </summary>
    public partial class UserFeedbackItem : UserControl
    {
        public UserFeedbackItem()
        {
            InitializeComponent();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            SaveButton.IsEnabled = true;
            FeedbackContentTextBox.IsHitTestVisible = true;
            FeedbackRatingBar.IsHitTestVisible = true;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (FeedbackContentTextBox.Text.Length < 3)
            {
                MessageBox.Show("Минимальная длина отзыва - 3");
            }
            else
            {
                var provider = Provider.GetProvider();
                var calculator = new FieldsCalculator();
                var currFB = GetCurrentFeedback(GSNameTxtBlock.Text);
                var currGS = provider.GetAllGS().FirstOrDefault(x => x.Name == currFB.GasStationName);

                currFB.Content = FeedbackContentTextBox.Text;
                currFB.Stars = FeedbackRatingBar.Value;
                provider.UpdateFeedback(currFB);

                calculator.CalculateAverageStarsNumber(currGS);

                FeedbackContentTextBox.IsHitTestVisible = false;
                FeedbackRatingBar.IsHitTestVisible = false;
                SaveButton.IsEnabled = false;
                
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var provider = Provider.GetProvider();
            var calculator = new FieldsCalculator();
            var currFB = GetCurrentFeedback(GSNameTxtBlock.Text);
            var currGS = provider.GetAllGS().FirstOrDefault(x => x.Name == currFB.GasStationName);

            App._UserFeedBacksPage.UserFeedBacksStackPanel.Children.Remove(this);
            provider.RemoveFeedback(currFB);
            calculator.CalculateFeedbacksNumber(currGS);
            calculator.CalculateAverageStarsNumber(currGS);
        }

        private FeedbackDTO GetCurrentFeedback(string gsName)
        {
            return Provider.GetProvider().GetAllFeedbacks().FirstOrDefault(x => x.GasStationName == gsName && x.UserName == App.User.Name);
        }
    }
}
