using Restaurant.Pages.under_categories;
using Restaurant.Pages.under_categories.add;
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

namespace Restaurant.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminMenuPage.xaml
    /// </summary>
    public partial class AdminMenuPage : Page
    {
        public AdminMenuPage()
        {
            InitializeComponent();
            
        }

        private void BtnAdmin_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminCards());
        }

        private void BtnMenegers_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MenegersCards());
        }

        private void BtnCardClients_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ClientCards());
        }

        private void BtnCardEmployee_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new EmployeeCards());
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddOrderPage());
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PrintReceipt());
        }

        private void BtnDish_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddDishePage());
        }

        private void BtnDishStatic_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new DishStatistics());
        }
    }
}
