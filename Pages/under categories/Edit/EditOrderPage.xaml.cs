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

namespace Restaurant.Pages.under_categories.Edit
{
    /// <summary>
    /// Логика взаимодействия для EditOrderPage.xaml
    /// </summary>
    public partial class EditOrderPage : Page
    {
        ARM_RestoranEntities db;
        Dishes item1;
        public EditOrderPage(Dishes item, ARM_RestoranEntities db)
        {
            InitializeComponent();
            
            item1 = item;
            this.DataContext = item1;
            this.DataContext = item;
            this.db = db;
           
            FirstNameTextBox.Text = item1.name;
            priceTextBox.Text = Convert.ToString(item1.price); 
            ingedientTextBox.Text = item1.ingedient;

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            item1.name = FirstNameTextBox.Text;
            item1.price = Convert.ToInt32(priceTextBox.Text);
            item1.ingedient = ingedientTextBox.Text;
            var resultMessageBox = MessageBox.Show("Вы действительно хотите изменить название специальности?", "Изменить", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (resultMessageBox == MessageBoxResult.Yes)
            {
                MessageBox.Show("Данные изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                
                db.SaveChanges();
                this.NavigationService.Navigate(new AddOrderPage());
            }
        }
    }
}
