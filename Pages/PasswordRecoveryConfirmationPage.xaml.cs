using NLab_Cain.Models;
using NLab_Cain.Windows;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace NLab_Cain.Pages
{
    /// <summary>
    /// Логика взаимодействия для PasswordRecoveryConfirmationPage.xaml
    /// </summary>
    public partial class PasswordRecoveryConfirmationPage : Page
    {
        int code;
        bool isVisibleCodeBox = false;
        bool isSendMessage = false;

        public static string email { get; set; }

        Random rnd = new Random();

        string body;
        string heading = "Восстановление пароля";

        public PasswordRecoveryConfirmationPage()
        {
            InitializeComponent();
        }

        async private void continueButton_Click(object sender, RoutedEventArgs e)
        {
            email = inputEmail.Text.Trim();

            bool resultValidEmail = ValidatorExtensions.IsValidEmailAddress(email);

            User? authUser = null;

            if (isVisibleCodeBox == false)
            {
                borderLoading.Visibility = Visibility.Visible;

                code = rnd.Next(100000, 999999);

                body = "<html><body><br><img src =\"https://c.tenor.com/5tIBP029IYQAAAAC/chips.gif\" alt=\"BGL\"!><br>Здравствуйте уважаемый(я)</b>"
                + "<br>Высылаем Вам код для сброса пароля."
                + "<br>"
                + "<br>Код: "
                + "<big><b>"
                + code
                + "</b></big> "
                + "<br>"
                + "<br>Если Вы не пытались восстановить пароль, то проигнорируйте данное сообщение!</body></html>";

                if (resultValidEmail == true)
                {
                    await Task.Run(() =>
                    {
                        using (var db = new ApplicationContext())
                        {
                            authUser = db.Users.Where(b => b.Email == email).FirstOrDefault();
                        }
                    });

                    //отправка кода
                    if (authUser != null)
                    {
                        isSendMessage = true;

                        await Task.Run(() =>
                        {
                            try
                            {
                                SendMailMessage.SendMessage(email, body, heading, code);
                            }
                            catch (Exception ex)
                            {
                                isSendMessage = false;
                                MessageBox.Show(ex.Message);
                            }
                        });

                        if (isSendMessage == true)
                        {
                            emailErrorMessage.Visibility = Visibility.Collapsed;

                            isVisibleCodeBox = true;
                            codeBoxes.Visibility = Visibility.Visible;

                            borderLoading.Visibility = Visibility.Hidden;

                            inputEmail.IsEnabled = false;
                        }
                        else borderLoading.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        emailErrorMessage.Text = "Аккаунта с такой почтой не найдено";
                        emailErrorMessage.Visibility = Visibility.Visible;

                        borderLoading.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    //Ошибка поля
                    emailErrorMessage.Text = "Введен не коректный формат email";
                    emailErrorMessage.Visibility = Visibility.Visible;

                    borderLoading.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                if (codeBox.Text == code.ToString())
                {
                    NavigationService.Navigate(new PasswordRecoveryNewPasswordPage());
                }
                else
                {
                    codeErrorMessage.Text = "Не верный код подтверждения";
                    codeErrorMessage.Visibility = Visibility.Visible;
                }
            }
        }

        private async void sendCodeAgain_Click(object sender, RoutedEventArgs e)
        {
            code = rnd.Next(100000, 999999);

            body = "<html><body><br><img src =\"https://c.tenor.com/5tIBP029IYQAAAAC/chips.gif\" alt=\"BGL\"!><br>Здравствуйте уважаемый(я)</b>"
            + "<br>Высылаем Вам код для сброса пароля."
            + "<br>"
            + "<br>Код: "
            + "<big><b>"
            + code
            + "</b></big> "
            + "<br>"
            + "<br>Если Вы не пытались восстановить пароль, то проигнорируйте данное сообщение!</body></html>";

            borderLoading.Visibility = Visibility.Visible;

            sendCodeAgain.IsEnabled = false;

            bool isVisibleLoading = true;

            await Task.Run(() =>
            {
                try
                {
                    SendMailMessage.SendMessage(email, body, heading, code);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                isVisibleLoading = false;
            });

            if (isVisibleLoading == false)
            {
                borderLoading.Visibility = Visibility.Hidden;
            }
        }

        private void codeBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
            codeBox.MaxLength = 6;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
    }

    public class SendMailMessage
    {
        private static MailMessage Message = new MailMessage();
        private static SmtpClient Smtp = new SmtpClient("smtp.mail.ru", 587);

        private static void MessageTemplate(string email, string body, string heading, int code)
        {
            Smtp.EnableSsl = true;
            Smtp.Credentials = new NetworkCredential("aristrax337@mail.ru", "ZUFugBUuRP5qD4Rb2HHz");
            Message.From = new MailAddress("aristrax337@mail.ru");
            Message.To.Add(new MailAddress(email));
            Message.Subject = heading;
            Message.IsBodyHtml = true;
            Message.Body = body;
        }
        public static void SendMessage(string email, string body, string heading, int code)
        {
            MessageTemplate(email, body, heading, code);
            try
            {
                Smtp.Send(Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
    }
}