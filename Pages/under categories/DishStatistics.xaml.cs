
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
using Core = Restaurant.Model.Core;

namespace Restaurant.Pages
{
    /// <summary>
    /// Логика взаимодействия для DishStatistics.xaml
    /// </summary>
    public partial class DishStatistics : Page
    {
        ARM_RestoranEntities db;
        public DishStatistics()
        {
            InitializeComponent();
            db = new ARM_RestoranEntities();

            DishStatisticsDataGrid.ItemsSource = db.Dishes.ToList();
            
            

        }
        private void DeleteButton(object sender, RoutedEventArgs e)
        {
            //удаление определённого официанта
            if (DishStatisticsDataGrid.SelectedItem != null)
            {
                Dishes item = DishStatisticsDataGrid.SelectedItem as Dishes;
                var resultMessageBox = MessageBox.Show("Вы действительно хотите удалить клиента", "Удалить", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (resultMessageBox == MessageBoxResult.Yes)
                {
                    MessageBox.Show("Данные удалены");
                    db.Dishes.Remove(item);
                    db.SaveChanges();
                }
                DishStatisticsDataGrid.ItemsSource = db.Dishes.ToList();
            }
            else
            {
                MessageBox.Show("Вы не выбрали клиента");
            }
        }

        private void ResultButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClientsCardDataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void cliets_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
