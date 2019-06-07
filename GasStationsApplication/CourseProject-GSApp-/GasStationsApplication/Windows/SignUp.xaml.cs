using GSAppLogic.DTO;
using GSAppLogic.Services;
using GSAppLogic.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
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

namespace GasStationsApplication.Windows
{
    /// <summary>
    /// Логика взаимодействия для SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public UserDTO _user;
        private int code;

        public SignUp()
        {
            InitializeComponent();
            _user = new UserDTO();
            this.DataContext = _user;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (code.ToString() == CodeTextBox.Text)
            {
                new EmailSender(_user).SendPasswordToEmail();
                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show("Неверный код");
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _user.Name = LoginTextBox.Text;
            _user.Password = PasswordTextBox.Text;
            _user.Email = EmailTextBox.Text;
            _user.RepeatingPassword = RepeatePasswordTextBox.Text;
            if (new UserAutoriseValidator(_user).IsDataFieldsValid() && CodeTextBox.Text.Count() != 0)
            {
                AcceptButton.IsEnabled = true;
            }
            else
            {
                AcceptButton.IsEnabled = false;
            }
        }

        private void GetCodeButton_Click(object sender, RoutedEventArgs e)
        {
            if (_user["Email"] == string.Empty)
            {
                CodeTextBox.IsEnabled = true;
                var rand = new Random();
                code = rand.Next(1000, 9999);
                var esender = new EmailSender();
                var error = esender.SendCodeToEmail(EmailTextBox.Text, code);
                if (error != null)
                {
                    MessageBox.Show(esender.SendCodeToEmail(EmailTextBox.Text, code));
                }
            }
        }
    }
}
