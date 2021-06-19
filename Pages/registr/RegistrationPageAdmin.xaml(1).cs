using Restaurant.Controllers;
using Restaurant.Model;
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

namespace Restaurant.Pages.registr
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPageAdmin.xaml
    /// </summary>
    public partial class RegistrationPageAdmin : Page
    {
        ARM_RestoranEntities db = new ARM_RestoranEntities();
        public RegistrationPageAdmin()
        {
            InitializeComponent();
        }

        private void Login(object sender, RoutedEventArgs e)
        {

            bool resultEnt = false;
            UserController objUser = new UserController();
            bool resultLogin = objUser.CheckLogin(LoginTextBox.Text);
            bool resultPass = objUser.CheckPassword(PasswordTextBox.Text);


           



            Admins add = new Admins()
            {
                first_name = NameTextBox.Text,
                login = LoginTextBox.Text,
                password = PasswordTextBox.Text,

                role = 4
            };
            var resultMessageBox = MessageBox.Show("Вы действительно хотите зарегистрироваться?", "Изменить", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (resultMessageBox == MessageBoxResult.Yes)
            {
                MessageBox.Show("Данные изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                db.Admins.Add(add);
                db.SaveChanges();
                MessageBox.Show("Данные добавлены");



                this.NavigationService.Navigate(new MainPage());
            }


        }
    }
}
