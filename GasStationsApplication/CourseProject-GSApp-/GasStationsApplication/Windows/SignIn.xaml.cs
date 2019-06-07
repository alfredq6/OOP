using GSAppLogic;
using GSAppLogic.DTO;
using GSAppLogic.Validators;
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

namespace GasStationsApplication.Windows
{
    /// <summary>
    /// Логика взаимодействия для SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        public UserDTO _user;
        public SignIn()
        {
            _user = new UserDTO();
            this.DataContext = _user;
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            _user.Name = LoginTxtBox.Text;
            _user.Password = PasswordTxtBox.Password;
            var userValidator = new UserAutoriseValidator(_user);

            if (userValidator.IsAutoriseDataValid())
            {
                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }
    }
}
