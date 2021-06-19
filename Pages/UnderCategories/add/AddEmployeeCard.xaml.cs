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

namespace Restaurant.Pages.UnderCategories.add
{
    /// <summary>
    /// Логика взаимодействия для AddEmployeeCard.xaml
    /// </summary>
    public partial class AddEmployeeCard : Page
    {
        ARM_RestoranEntities db = new ARM_RestoranEntities();

        public AddEmployeeCard()
        {
            InitializeComponent();
        }
           

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            bool resultEnt = false;
            UserController objUser = new UserController();
            CheckController objnull = new CheckController();

            bool resultLogin = objUser.CheckLogin(login.Text);

            bool NameNull = objnull.TextNull(FirstNameTextBox.Text);
            bool loginNull = objnull.TextNull(login.Text);
            bool passNull = objnull.TextNull(password.Text);
            bool secont = objnull.TextNull(LastName.Text);

            if (resultLogin == true)
            {
                MessageBoxResult result = MessageBox.Show("Такой логин уже есть", "", MessageBoxButton.OK);
                return;
            }
            if (NameNull == false)
            {
                MessageBoxResult result = MessageBox.Show("Введите данные", "", MessageBoxButton.OK);
                return;

            }
            if (loginNull == false)
            {
                MessageBoxResult result = MessageBox.Show("Введите данные", "", MessageBoxButton.OK);
                return;
            }
            if (passNull == false)
            {
                MessageBoxResult result = MessageBox.Show("Введите данные", "", MessageBoxButton.OK);
                return;
            }
            if (secont == false)
            {
                MessageBoxResult result = MessageBox.Show("Введите данные", "", MessageBoxButton.OK);
                return;
            }


            




            Wraiters add = new Wraiters()
            {
                first_name = FirstNameTextBox.Text,
                login = login.Text,
                password = password.Text,
                last_name = LastName.Text,
                role = 2
            };

            db.Wraiters.Add(add);
            db.SaveChanges();
            MessageBox.Show("Данные добавлены");
            this.NavigationService.Navigate(new EmployeeCards());

        
    }
    }
}
