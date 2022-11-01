using NLab_Cain.Models;
using NLab_Cain.Windows;
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

namespace NLab_Cain.Pages
{
    /// <summary>
    /// Логика взаимодействия для ConfirmationPage.xaml
    /// </summary>
    public partial class ConfirmationPage : Page
    {
        ApplicationContext db = new ApplicationContext();

        Random rnd = new Random();

        int code { get; set; }
        string email = RegistrationPage.email;
        string password = RegistrationPage.password;
        bool isSuccessfully = false;

        string body;
        string heading = "Подтверждение почты";

        public ConfirmationPage()
        {
            InitializeComponent();

            code = rnd.Next(100000, 999999);

            body = "<html><body><br><img src =\"https://c.tenor.com/5tIBP029IYQAAAAC/chips.gif\" alt=\"BGL\"!><br>Здравствуйте уважаемый(я)</b>"
            + "<br>Высылаем Вам код для подтверждения почты."
            + "<br>"
            + "<br>Код: "
            + "<big><b>"
            + code
            + "</b></big> "
            + "<br>"
            + "<br>Благодарим вас за регистрацию в приложении Cain!</body></html>";

            SendMailMessage.SendMessage(email, body, heading, code);
        }

        private async void createAccount_Click(object sender, RoutedEventArgs e)
        {
            User addUser = new User { Email = email, Password = password };

            if (codeBox.Text == code.ToString())
            {
                borderLoading.Visibility = Visibility.Visible;

                await Task.Run(() =>
                {
                    using (var db = new ApplicationContext())
                    {
                        try
                        {
                            db.Users.Add(addUser);
                            db.SaveChanges();
                            isSuccessfully = true;
                        }
                        catch
                        {
                            isSuccessfully = false;
                        }
                    }
                });
                if (isSuccessfully == true)
                {
                    borderLoading.Visibility = Visibility.Collapsed;
                    OpenMainWindow();
                }
                else
                {
                    codeErrorMessage.Text = "Ошибка сервера";
                }
            }
            else
            {
                codeErrorMessage.Text = "Не верный код подтверждения";
                codeErrorMessage.Visibility = Visibility.Visible;
            }
        }

        private void sendCodeAgain_Click(object sender, RoutedEventArgs e)
        {
            sendCodeAgain.IsEnabled = false;

            code = rnd.Next(100000, 999999);
            SendMailMessage.SendMessage(email, body, heading, code);
        }

        private void codeBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
            codeBox.MaxLength = 6;
        }

        private void OpenMainWindow()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            Application.Current.MainWindow.Close();
        }
    }
}