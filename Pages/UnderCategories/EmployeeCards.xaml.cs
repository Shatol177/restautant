using Restaurant.Model;
using Restaurant.Pages.UnderCategories.add;
using Restaurant.Pages.UnderCategories.Edit;
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
    /// Логика взаимодействия для EmployeeCards.xaml
    /// </summary>
    public partial class EmployeeCards : Page
    {
        ARM_RestoranEntities db;
        public EmployeeCards()
        {
            InitializeComponent();
            db = new ARM_RestoranEntities();
            EmployeeCardDataGrid.ItemsSource = db.Wraiters.ToList();
        }

        private void ClientsCardDataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void ResultButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeCardDataGrid.ItemsSource = db.Wraiters.Where(x => x.first_name.Contains(FilterTxt.Text)).ToList();

        }

        private void EmployeeCardDataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
        private void DeleteCards_Click(object sender, RoutedEventArgs e)
        {
            //удаление определённого официанта
            if (EmployeeCardDataGrid.SelectedItem != null)
            {
                Wraiters item = EmployeeCardDataGrid.SelectedItem as Wraiters;
                var resultMessageBox = MessageBox.Show("Вы действительно хотите удалить клиента", "Удалить", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (resultMessageBox == MessageBoxResult.Yes)
                {
                    MessageBox.Show("Данные удалены");
                    db.Wraiters.Remove(item);
                    db.SaveChanges();
                }
                EmployeeCardDataGrid.ItemsSource = db.Wraiters.ToList();
            }
            else
            {
                MessageBox.Show("Вы не выбрали клиента");
            }
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            Button selelectedButton = sender as Button;
            Wraiters item = selelectedButton.DataContext as Wraiters;
            this.NavigationService.Navigate(new EditEmloyeeCards(item, db));
        }

        private void AddCards_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddEmployeeCard());
        }
    }
}
