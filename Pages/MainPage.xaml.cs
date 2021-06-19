using Restaurant.Model;
using Restaurant.Pages.login;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        ARM_RestoranEntities db = new ARM_RestoranEntities();

        public MainPage()
        {
            InitializeComponent();
            





        }

        private void BtnWraiter_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LoginPageWraiter());
        }

        private void BtnAdmin_Click(object sender, RoutedEventArgs e)
        {
            
            this.NavigationService.Navigate(new LoginPageAdmin());
        }
        private void BtnManager_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LoginPageMeneger());
        }

        private void BtnClient_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LoginPageClient());
        }
    }
    
}
