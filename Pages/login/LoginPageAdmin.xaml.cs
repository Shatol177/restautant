using Restaurant.Controllers;
using Restaurant.Pages.registr;
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

namespace Restaurant.Pages.login
{
    /// <summary>
    /// Логика взаимодействия для LoginPageAdmin.xaml
    /// </summary>
    public partial class LoginPageAdmin : Page
    {
        public LoginPageAdmin()
        {
            InitializeComponent();
        }

        public void Login(object sender, RoutedEventArgs e)
        {

            bool resultEnt = false;
            UserController objUser = new UserController();
            CheckController objCheck = new CheckController();
            bool resultLogin = objUser.CheckLogin(LoginTextBox.Text);
            bool resultPass = objUser.CheckPassword(PasswordTextBox.Text);
            bool LoginNull = objCheck.TextNull(LoginTextBox.Text);
            bool PassNull = objCheck.TextNull(PasswordTextBox.Text);


            if (resultLogin != true && resultPass != true)
            {
                MessageBoxResult result = MessageBox.Show("Нет Такого пользователя!", "", MessageBoxButton.OK);
                return;
            }
            if (resultLogin == false)
            {
                MessageBoxResult result = MessageBox.Show("Неправельный логин", "", MessageBoxButton.OK);
                return;
            }
            if (resultPass == false)
            {
                MessageBoxResult result = MessageBox.Show("Неправельный пароль", "", MessageBoxButton.OK);
                return;
            }
            if (resultLogin == true && resultPass == true)
            {
                resultEnt = true;
            }
            if (LoginNull == false)
            {
                MessageBoxResult result = MessageBox.Show("Введите данные", "", MessageBoxButton.OK);
                return;

            }
            if (PassNull == false)
            {
                MessageBoxResult result = MessageBox.Show("Введите данные", "", MessageBoxButton.OK);
                return;

            }


            Properties.Settings.Default.adminLoginString = LoginTextBox.Text;
            Properties.Settings.Default.Save();
            this.NavigationService.Navigate(new AdminMenuPage());



            this.NavigationService.Navigate(new AdminMenuPage());
        }


        private void Registration(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RegistrationPageAdmin());

        }
    }


 
}
