using Restaurant.Model;
using Restaurant.Pages;
using Restaurant.Pages.login;
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

namespace Restaurant
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        ARM_RestoranEntities db = new ARM_RestoranEntities();
        
        public MainWindow()
        {  
            InitializeComponent(); 
            

            MainFrame.Navigate(new MainPage());
            
        }
         public void Navigate(Page Move)
        {
            MainShow.Navigate(Move);
           
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
                MainFrame.GoBack();
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {

        }

        private void MainShow_Navigated(object sender, NavigationEventArgs e)
        {
            var page = e.Content;
            if (MainShow.CanGoBack && ( page is LoginPageAdmin))
                MainShow.RemoveBackEntry();
            
        }

       

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            

         if (MainFrame.CanGoBack)

         { MainFrame.GoBack(); }

            
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
