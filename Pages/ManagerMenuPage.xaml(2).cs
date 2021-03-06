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
    /// Логика взаимодействия для ManagerMenuPage.xaml
    /// </summary>
    public partial class ManagerMenuPage : Page
    {
        public ManagerMenuPage()
        {
            InitializeComponent();
        }

        private void BtnCardClients_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ClientCards());
        }

        private void BtnStatistics_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new DishStatistics());
        }

        private void BtnCardEmployee_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new EmployeeCards());
        }
    }
}
