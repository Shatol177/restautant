using Restaurant.Controllers;
using Restaurant.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
    /// Логика взаимодействия для AddClientCards.xaml
    /// </summary>
    public partial class AddClientCards : Page
    {
        ARM_RestoranEntities db = new ARM_RestoranEntities();
        public AddClientCards()
        {
            InitializeComponent();



        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            bool resultEnt = false;
            UserController objUser = new UserController();
            CheckController objEmail = new CheckController();
            CheckController objnull = new CheckController();
            bool resultname = objUser.CheckName(FirstNameTextBox.Text);
            bool resultLogin = objUser.CheckLogin(login.Text);
            bool resultPass = objUser.CheckPassword(passwordText.Text);
            bool resulEmail = objEmail.CorrectEmail(EmailTextBox.Text);
            bool resulEmail2 = objUser.CheckEmail(EmailTextBox.Text);

            bool TextNullname = objnull.TextNull(FirstNameTextBox.Text);
            bool TextNullLogin = objnull.TextNull(login.Text);
            bool TextNullPass = objnull.TextNull(passwordText.Text);
            bool TextNullEmail = objnull.TextNull(EmailTextBox.Text);
           

            if (resultLogin == true)
            {
                MessageBoxResult result = MessageBox.Show("Такой логин уже есть", "", MessageBoxButton.OK);
                return;
            }


            if (resulEmail2 == true)
            {
                MessageBoxResult result = MessageBox.Show("такой email есть", "", MessageBoxButton.OK);
                return;
            }

            if (resulEmail == false)
            {
                MessageBoxResult result = MessageBox.Show("не правильный email", "", MessageBoxButton.OK);
                return;
            }

            if (TextNullname == false)
            {
                MessageBoxResult result = MessageBox.Show("Введите данные", "", MessageBoxButton.OK);
                return;

            }
            if (TextNullLogin == false)
            {
                MessageBoxResult result = MessageBox.Show("Введите данные", "", MessageBoxButton.OK);
                return;
            }
            if (TextNullPass == false)
            {
                MessageBoxResult result = MessageBox.Show("Введите данные", "", MessageBoxButton.OK);
                return;
            }
            if (TextNullEmail == false)
            {
                MessageBoxResult result = MessageBox.Show("Введите данные", "", MessageBoxButton.OK);
                return;
            }


            Clients add = new Clients()
            {
                first_name = FirstNameTextBox.Text,
                email = EmailTextBox.Text,
                login = login.Text,
                password = passwordText.Text,
                role = 1
            };
            {
                string email = EmailTextBox.Text.Trim();
                string password = passwordText.Text.Trim();
                if ((email.Contains("@") && email.Contains(".")))
                {



                    // отправитель - устанавливаем адрес и отображаемое в письме имя
                    MailAddress from = new MailAddress("Restourant@gmail.com", "Restourant");//copmutershoppp@gmail.com ComputerShop qwertyuiop67890
                                                                                               // кому отправляем
                    MailAddress to = new MailAddress(email);
                    // создаем объект сообщения
                    MailMessage m = new MailMessage(from, to);
                    // тема письма
                    m.Subject = "Пароль и логин для входа в аккаунт Restourant";
                    // текст письма
                    //TODO написать норм разметку для письма
                    m.Body = "<h4>Здравствуйте, " + email + "</h4>"
                                + "<p><font-size: 18px>Логин: " + email + "</p>" + "<p><font-size = 18>Пароль: " + password + "</p>"
                                + "<p><font-size: 18px>Если вы не делали запрос на отправку данных, ответье на это письмо: " + "<span><font-size:22px; color: red>";
                    // письмо представляет код html
                    m.IsBodyHtml = true;
                    // адрес smtp-сервера и порт, с которого будем отправлять письмо
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    // логин и пароль
                    smtp.Credentials = new NetworkCredential("armrestourant@gmail.com", "ArmRestourant123");
                    smtp.EnableSsl = true;
                    MessageBox.Show("Отправлено!");
                    try
                    {
                        smtp.Send(m);
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка");

                    }

                }

                db.Clients.Add(add);
                db.SaveChanges();
                MessageBox.Show("Данные добавлены");
                this.NavigationService.Navigate(new ClientCards());

            }
        }
    }
}
