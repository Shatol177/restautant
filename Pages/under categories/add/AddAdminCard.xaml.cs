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

namespace Restaurant.Pages.under_categories.add
{
    /// <summary>
    /// Логика взаимодействия для AddAdminCard.xaml
    /// </summary>


    public partial class AddAdminCard : Page
    {
        ARM_RestoranEntities db = new ARM_RestoranEntities();
        public AddAdminCard()
        {
            InitializeComponent();



        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            CheckController objCheck = new CheckController();
            bool NameNull = objCheck.TextNull(FirstNameTextBox.Text);
            bool loginNull = objCheck.TextNull(login.Text);
            bool passNull = objCheck.TextNull(password.Text);
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


            if (loginNull == true)
            {
                MessageBoxResult result = MessageBox.Show("Такой логин уже есть", "", MessageBoxButton.OK);
                return;
            }




            Admins add = new Admins()
            {
                first_name = FirstNameTextBox.Text,

                login = login.Text,
                password = password.Text,
                role = 4
            };

            db.Admins.Add(add);
            db.SaveChanges();
            MessageBox.Show("Данные добавлены");
            this.NavigationService.Navigate(new AdminCards());

        }
    }
}
