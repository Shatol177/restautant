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

namespace Restaurant.Pages.UnderCategories
{
    /// <summary>
    /// Логика взаимодействия для MenegersCards.xaml
    /// </summary>
    public partial class MenegersCards : Page
    {
        ARM_RestoranEntities db;

        public MenegersCards()
        {
            InitializeComponent();
            db = new ARM_RestoranEntities();
            MenegersCardDataGrid.ItemsSource = db.Managers.ToList();
        }

        private void ResultButton_Click(object sender, RoutedEventArgs e)
        {
            MenegersCardDataGrid.ItemsSource = db.Managers.Where(x => x.first_name.Contains(FilterTxt.Text)).ToList();

        }

        private void ClientsCardDataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
           
        }
        private void DeleteCards_Click(object sender, RoutedEventArgs e)
        {
            //удаление определённой специальности
            if (MenegersCardDataGrid.SelectedItem != null)
            {
                Managers item = MenegersCardDataGrid.SelectedItem as Managers;
                var resultMessageBox = MessageBox.Show("Вы действительно хотите удалить менеджера", "Удалить", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (resultMessageBox == MessageBoxResult.Yes)
                {
                    MessageBox.Show("Данные удалены");
                    db.Managers.Remove(item);
                    db.SaveChanges();
                }
                MenegersCardDataGrid.ItemsSource = db.Managers.ToList();
            }
            else
            {
                MessageBox.Show("Вы не выбрали менеджера");
            }
        }
        private void EditMenegers_click(object sender, RoutedEventArgs e)
        {


            Button selelectedButton = sender as Button;
            Managers item = selelectedButton.DataContext as Managers;
            this.NavigationService.Navigate(new EditMenegersCards(item, db));
        }

        private void AddCards_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddManagersCards());
        }
    }
}
