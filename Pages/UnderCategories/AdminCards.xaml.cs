using Restaurant.Model;
using Restaurant.Pages.UnderCategories.add;
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

namespace Restaurant.Pages.UnderCategories
{
    /// <summary>
    /// Логика взаимодействия для AdminCards.xaml
    /// </summary>
    public partial class AdminCards : Page
    {
        ARM_RestoranEntities db;
        public AdminCards()
        {
            InitializeComponent();
            db = new ARM_RestoranEntities();
            AdminCardDataGrid.ItemsSource = db.Admins.ToList();
        }

        private void ResultButton_Click(object sender, RoutedEventArgs e)
        {
            AdminCardDataGrid.ItemsSource = db.Admins.Where(x => x.first_name.Contains(FilterTxt.Text)).ToList();
        }

        private void ClientsCardDataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void AddCards_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddAdminCard());
        }
    }
}
