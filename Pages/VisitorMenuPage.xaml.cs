using Restaurant.Pages.under_categories;
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
    /// Логика взаимодействия для VisitorMenuPage.xaml
    /// </summary>
    public partial class VisitorMenuPage : Page
    {
        public VisitorMenuPage()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddOrderPage());
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PrintReceipt());
        }
    }
}
