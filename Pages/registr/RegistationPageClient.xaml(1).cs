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

namespace Restaurant.Pages.registr
{
    /// <summary>
    /// Логика взаимодействия для RegistationPageClient.xaml
    /// </summary>
    public partial class RegistationPageClient : Page
    {
        ARM_RestoranEntities db = new ARM_RestoranEntities();
        public RegistationPageClient()
        {
            InitializeComponent();
        }


        private void Login(object sender, RoutedEventArgs e)
        {
            bool resultEnt = false;
            UserController objUser = new UserController();
            CheckController objEmail = new CheckController();
            bool resultname = objUser.CheckName(NameTextBox.Text);
            bool resultLogin = objUser.CheckLogin(LoginTextBox.Text);
            bool resultPass = objUser.CheckPassword(PasswordTextBox.Text);
            bool resulEmail = objEmail.CorrectEmail(EmailnTextBox.Text);
            bool resulEmail2 = objUser.CheckEmail(EmailnTextBox.Text);

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
            Clients add = new Clients()
            {
                first_name = NameTextBox.Text,
                login = LoginTextBox.Text,
                password = PasswordTextBox.Text,
                email = EmailnTextBox.Text,
                role = 1
            };

            var resultMessageBox = MessageBox.Show("Вы действительно хотите зарегистрироваться?", "Изменить", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (resultMessageBox == MessageBoxResult.Yes)
            {
                MessageBox.Show("Данные изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                db.Clients.Add(add);
                db.SaveChanges();
                MessageBox.Show("Данные добавлены");
                {
                    string email = EmailnTextBox.Text.Trim();
                    string password = PasswordTextBox.Text.Trim();
                    if ((email.Contains("@") && email.Contains(".")))
                    {



                        // отправитель - устанавливаем адрес и отображаемое в письме имя
                        MailAddress from = new MailAddress("copmutershoppp@gmail.com", "ComputerShop");//copmutershoppp@gmail.com ComputerShop qwertyuiop67890
                                                                                                       // кому отправляем
                        MailAddress to = new MailAddress(email);
                        // создаем объект сообщения
                        MailMessage m = new MailMessage(from, to);
                        // тема письма
                        m.Subject = "Пароль и логин для входа в аккаунт ComputerShop";
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
                        smtp.Credentials = new NetworkCredential("armrestourant@gmail.com", "armrestourant123");
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
                    this.NavigationService.Navigate(new MainPage());
                }

            }

           
        }
    }
}

