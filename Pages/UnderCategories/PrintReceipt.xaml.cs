using Microsoft.Win32;
using Restaurant.Controllers;
using Restaurant.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace Restaurant.Pages.UnderCategories
{
    /// <summary>
    /// Логика взаимодействия для PrintReceipt.xaml
    /// </summary>
    public partial class PrintReceipt : Page
    {
        Core db = new Core();
        receipt item;
        Wraiters itemW;
        Tables itemT;
        string nameFile;
        string[] Mass;
        UserController userObj = new UserController();
        List<Model.receipt> currentUsers;

        public PrintReceipt()
        {
            InitializeComponent();
            db = new Core();
            PrintReceiptDataGrid.ItemsSource = db.context.receipt.ToList();
            
            PrintReceiptDataGrid.ItemsSource = currentUsers;



        }

        private void ClientsCardDataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ResultButton_Click(object sender, RoutedEventArgs e)
        {
            
          
           
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
                var resultMessageBox = MessageBox.Show("Вы действительно хотите удалить чек", "Удалить", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (resultMessageBox == MessageBoxResult.Yes)
                {
                    MessageBox.Show("Данные удалены");
                    db.context.receipt.Remove(item);
                    
                    db.context.SaveChanges();
                }
                PrintReceiptDataGrid.ItemsSource = db.context.receipt.ToList();
            }
            else
            {
                MessageBox.Show("Вы не выбрали рецепт");
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
