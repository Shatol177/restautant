using Restaurant.Controllers;
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

namespace Restaurant.Pages.UnderCategories.add
{
    /// <summary>
    /// Логика взаимодействия для AddDishePage.xaml
    /// </summary>
    public partial class AddDishePage : Page
    {
        ARM_RestoranEntities db = new ARM_RestoranEntities();
        public AddDishePage()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            CheckController objCheck = new CheckController();
            bool NameNull = objCheck.TextNull(FirstNameTextBox.Text);
            bool PriceNull = objCheck.TextNull(price.Text);
            bool ingridNull = objCheck.TextNull(ingrid.Text);
            if (NameNull == false)
            {
                MessageBoxResult result = MessageBox.Show("Введите данные", "", MessageBoxButton.OK);
                return;

            }
            if (PriceNull == false)
            {
                MessageBoxResult result = MessageBox.Show("Введите данные", "", MessageBoxButton.OK);
                return;
            }
            if (ingridNull == false)
            {
                MessageBoxResult result = MessageBox.Show("Введите данные", "", MessageBoxButton.OK);
                return;
            }
            Dishes add = new Dishes()
            {
                name = FirstNameTextBox.Text,
                price = Convert.ToInt32(price.Text),
                ingedient = ingrid.Text,
                number_of_orders = 0
            };

            db.Dishes.Add(add);
            db.SaveChanges();
            MessageBox.Show("Данные добавлены");
            this.NavigationService.Navigate(new AdminMenuPage());

        }
    }
    
}
