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

namespace Restaurant.Pages.under_categories
{
    /// <summary>
    /// Логика взаимодействия для PrintReceipt.xaml
    /// </summary>
    public partial class PrintReceipt : Page
    {
        ARM_RestoranEntities db;
        receipt itemR;
        Wraiters itemW;
        Tables itemT;
        Dishes item;
        public PrintReceipt()
        {
            InitializeComponent();
            db = new ARM_RestoranEntities();
            PrintReceiptDataGrid.ItemsSource = db.receipt.ToList();
            

        }

        private void ClientsCardDataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ResultButton_Click(object sender, RoutedEventArgs e)
        {
            
            PrintReceiptDataGrid.ItemsSource = db.receipt.Where(x => x.wraiter.Contains(FilterCheck.Text)).ToList();
        }
        
        private void PrintResult(object sender, RoutedEventArgs e)
        {

            
        }
        private void DeleteResult(object sender, RoutedEventArgs e)
        {
            //удаление определённого официанта
            if (PrintReceiptDataGrid.SelectedItem != null)
            {
                receipt item = PrintReceiptDataGrid.SelectedItem as receipt;
                var resultMessageBox = MessageBox.Show("Вы действительно хотите удалить клиента", "Удалить", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (resultMessageBox == MessageBoxResult.Yes)
                {
                    MessageBox.Show("Данные удалены");
                    db.receipt.Remove(item);
                    
                    db.SaveChanges();
                }
                PrintReceiptDataGrid.ItemsSource = db.receipt.ToList();
            }
            else
            {
                MessageBox.Show("Вы не выбрали клиента");
            }
        }
        private void printReceipt(object sender, SelectionChangedEventArgs e)
        {

        }
        private void deleteReceipt(object sender, SelectionChangedEventArgs e)
        {

        }
        private void FilterCheck_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
