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

namespace Restaurant.Pages.UnderCategories.addDish
{
    /// <summary>
    /// Логика взаимодействия для AddDishPageForPrice.xaml
    /// </summary>
    public partial class AddDishPageForPrice : Page
    {
        ARM_RestoranEntities db = new ARM_RestoranEntities();
        Dishes item1;
        receipt itep;
        string firs1;
        int addres1;
        public AddDishPageForPrice(Dishes item,string firs, int addres)
        {
            //входные параметры будут айди офиц. и айди столика.   Dishes item1; - вместо этого интовые переменные id_writer, id_table присвоить в receipt  
            InitializeComponent();
            db = new ARM_RestoranEntities();
            item1 = item;
            this.DataContext = item;
            firs1 = firs;
            addres1 = addres;


           
            
            
            FirstNameTextBox.Content = item1.name;
            PriceTextBox.Text = Convert.ToString(item1.price);
            
        }

        

        private void DecreaseAmountButton_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(AmountTextBox.Text) >= 1)
            {
                

                AmountTextBox.Text = (Convert.ToInt32(AmountTextBox.Text) - 1).ToString();
                PriceTextBox.Text = Convert.ToString(Convert.ToInt32(AmountTextBox.Text) * Convert.ToInt32(item1.price));

            } 
            else if(Convert.ToInt32(AmountTextBox.Text) == -1)
            {
                MessageBox.Show("Вы не можете сделать отрицательное количество блюд");
                return;
            }
            if(Convert.ToInt32(AmountTextBox.Text) == 0)
            {
                PriceTextBox.Text = Convert.ToString(0);
            }

        }
        

        private void IncreaseAmountButton_Click(object sender, RoutedEventArgs e)
        {
            

            AmountTextBox.Text = (Convert.ToInt32(AmountTextBox.Text) + 1).ToString();
            PriceTextBox.Text = Convert.ToString(Convert.ToInt32(AmountTextBox.Text) * Convert.ToInt32(item1.price) );
        }

        private void AmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (AmountTextBox.Text == "15")
            {
                AmountTextBox.Text = "15";
                MessageBox.Show("Слушай, а не много ли ты ешь?!");
            }
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
            Random rd = new Random();








            receipt add = new receipt()

            {


                 table_number = addres1,
                 wraiter = firs1,
                 price = Convert.ToInt32(PriceTextBox.Text),
                 col_dish = Convert.ToInt32(AmountTextBox.Text),
                 number_receipt = rd.Next(100, 999),
                 name = item1.name
                 



        };

            db.receipt.Add(add);
            db.SaveChanges();

            item1.number_of_orders = Convert.ToInt32(AmountTextBox.Text);

            

            
            db.SaveChanges();
            MessageBox.Show("Блюдо добавлены");
            this.NavigationService.Navigate(new AddOrderPage());
        }

    }
}
