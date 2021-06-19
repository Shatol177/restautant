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

namespace Restaurant.Pages.under_categories.Edit
{
    /// <summary>
    /// Логика взаимодействия для EditEmloyeeCards.xaml
    /// </summary>
    public partial class EditEmloyeeCards : Page
    {
        ARM_RestoranEntities db;
        Wraiters item1;
        public EditEmloyeeCards(Wraiters item, ARM_RestoranEntities db)
        {
            InitializeComponent();
            
            item1 = item;
            this.DataContext = item1;
            this.DataContext = item;
            this.db = db;

            FirstNameTextBox.Text = item1.first_name;
            LastNameTextBox.Text = item1.last_name;
            login.Text = item1.login;
            password.Text = item1.password;

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var resultMessageBox = MessageBox.Show("Вы действительно хотите изменить название специальности?", "Изменить", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (resultMessageBox == MessageBoxResult.Yes)
            {
                item1.first_name = FirstNameTextBox.Text;
                item1.last_name = LastNameTextBox.Text;
                item1.login = login.Text;
                item1.password = password.Text;
                MessageBox.Show("Данные изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                
                db.SaveChanges();
                this.NavigationService.Navigate(new EmployeeCards());
            }
        }
    }

}
