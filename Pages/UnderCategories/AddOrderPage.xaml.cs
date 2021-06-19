
using Restaurant.Model;
using Restaurant.Pages.UnderCategories.addDish;
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
using Core = Restaurant.Model.Core;
namespace Restaurant.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddOrderPage.xaml
    /// </summary>
    public partial class AddOrderPage : Page
    {
        ARM_RestoranEntities db = new ARM_RestoranEntities();
        Tables itemT;
        Wraiters itemW;
        Dishes item;
        
        public AddOrderPage()
        {
            InitializeComponent();
            db = new ARM_RestoranEntities();
            AddOrderDataGrid.ItemsSource = db.Dishes.ToList();

            
            WraiterList.ItemsSource = db.Wraiters.ToList();
            WraiterList.DisplayMemberPath = "first_name";
            WraiterList.SelectedValuePath = "id";


            TableList.ItemsSource = db.Tables.ToList();
            TableList.DisplayMemberPath = "addres";
            TableList.SelectedValuePath = "id";
            this.DataContext = itemT;
            this.DataContext = itemW;
                    }
     

        private void PlayersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void ResultButton_Click(object sender, RoutedEventArgs e)
        {
            
            
            AddOrderDataGrid.ItemsSource = db.Dishes.Where(y => y.ingedient.Contains(FilterTxtingr.Text)).ToList();
        }
        private void ResultButton_Click2(object sender, RoutedEventArgs e)
        {
            AddOrderDataGrid.ItemsSource = db.Dishes.Where(x => x.name.Contains(FilterTxt.Text)).ToList();

            
        }

        private void PlayerNameTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
 
        private void AddDish_click(object sender, RoutedEventArgs e)
        {
            Button selelectedButton = sender as Button;
            Dishes item = selelectedButton.DataContext as Dishes;
            Wraiters itemW  = WraiterList.SelectedItem as Wraiters;
            Tables itemT = TableList.SelectedItem as Tables;
            receipt itemR = AddOrderDataGrid.SelectedItem as receipt;

            



            this.NavigationService.Navigate(new AddDishPageForPrice(item,itemW.first_name , Convert.ToInt32(itemT.addres)));
        }
        private void EditDish_click(object sender, RoutedEventArgs e)
        {
            Button selelectedButton = sender as Button;
            Dishes item = selelectedButton.DataContext as Dishes;
            this.NavigationService.Navigate(new EditOrderPage(item, db));
        }
        private void DeleteDish_click(object sender, RoutedEventArgs e)
        {
            //удаление определённого официанта
            if (AddOrderDataGrid.SelectedItem != null)
            {
                Dishes item = AddOrderDataGrid.SelectedItem as Dishes;
                var resultMessageBox = MessageBox.Show("Вы действительно хотите удалить клиента", "Удалить", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (resultMessageBox == MessageBoxResult.Yes)
                {
                    MessageBox.Show("Данные удалены");
                    db.Dishes.Remove(item);
                    db.SaveChanges();
                }
                AddOrderDataGrid.ItemsSource = db.Dishes.ToList();
            }
            else
            {
                MessageBox.Show("Вы не выбрали клиента");
            }
        }

        private void AddOrder_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void WraiterList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void FilterTxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
