using Restaurant.Model;
using System.Data.Entity.Core.Objects;
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
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;
using Core = Restaurant.Model.Core;
using Restaurant.Pages.UnderCategories.Edit;
using Restaurant.Pages.UnderCategories.add;

namespace Restaurant.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientCards.xaml
    /// </summary>
    public partial class ClientCards : Page
    {

        ARM_RestoranEntities db;
        public ClientCards()
        {
            InitializeComponent();
            db = new ARM_RestoranEntities();
            ClientsCardDataGrid.ItemsSource = db.Clients.ToList();

        }

        private void PlayersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void ResultButton_Click(object sender, RoutedEventArgs e)
        {
            ClientsCardDataGrid.ItemsSource = db.Clients.Where(x => x.first_name.Contains(FilterTxt.Text)).ToList();
        }
        private void DeleteCards_Click(object sender, RoutedEventArgs e)
        {
            //удаление определённой специальности
            if (ClientsCardDataGrid.SelectedItem != null)
            {
                Clients item = ClientsCardDataGrid.SelectedItem as Clients;
                var resultMessageBox = MessageBox.Show("Вы действительно хотите удалить клиента", "Удалить", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (resultMessageBox == MessageBoxResult.Yes)
                {
                    MessageBox.Show("Данные удалены");
                    db.Clients.Remove(item);
                    db.SaveChanges();
                }
                ClientsCardDataGrid.ItemsSource = db.Clients.ToList();
            }
            else
            {
                MessageBox.Show("Вы не выбрали клиента");
            }
        }
       
    
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Button selelectedButton = sender as Button;
            Clients item = selelectedButton.DataContext as Clients;
            this.NavigationService.Navigate(new EditClientCards(item, db));
        }
        private void AddCards_Click(object sender, RoutedEventArgs e)
        {
            
            this.NavigationService.Navigate(new AddClientCards());
        }
        private void ClientsCardDataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
           


            
        }

        private void FilterTxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
