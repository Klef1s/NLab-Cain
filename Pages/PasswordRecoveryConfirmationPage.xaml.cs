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
        int counter = 0;
        bool sendMail = false;

        Random rnd = new Random();

        public PasswordRecoveryConfirmationPage()
        {
            InitializeComponent();
        }

        async private void continueButton_Click(object sender, RoutedEventArgs e)
        {
            
            string email = inputEmail.Text.Trim();
            bool resultValidEmail = ValidatorExtensions.IsValidEmailAddress(email);

            User? authUser = null;

            counter++;
            if (counter == 1)
            {
                code = rnd.Next(100000, 999999);

                borderLoading.Visibility = Visibility.Visible;

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
                        sendMail = true;

                        SmtpClient Smtp = new SmtpClient("smtp.mail.ru", 587);
                        Smtp.EnableSsl = true;
                        Smtp.Credentials = new NetworkCredential("aristrax337@mail.ru", "ZUFugBUuRP5qD4Rb2HHz");
                        MailMessage Message = new MailMessage();
                        Message.From = new MailAddress("aristrax337@mail.ru");
                        Message.To.Add(new MailAddress(email));
                        Message.Subject = "Восстановление пароля";
                        Message.IsBodyHtml = true;
                        Message.Body = "<html><body><br><img src =\"https://c.tenor.com/5tIBP029IYQAAAAC/chips.gif\" alt=\"BGL\"!><br>Здравствуйте уважаемый(я)</b>" + "<br>Высылаем Вам код для сброса пароля." + "<br>" + "<br>Код для сброса пароля: " + "<big><b>" + code + "</b></big> " + "<br>" + "<br>Если Вы не пытались восстановить пароль, то проигнорируйте данное сообщение!</body></html>";

                        await Task.Run(() =>
                        {
                            try
                            {
                                Smtp.Send(Message);
                            }
                            catch (Exception ex)
                            {
                                sendMail = false;
                                MessageBox.Show(ex.Message);
                            }
                        });

                        if (sendMail == true)
                        {
                            borderLoading.Visibility = Visibility.Hidden;
                            codeBoxes.Visibility = Visibility.Visible;
                            inputEmail.IsEnabled = false;
                        }
                        else borderLoading.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        MessageBox.Show("не ту такой почты");
                        borderLoading.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    //Ошибка поля
                    MessageBox.Show("ne, huina");
                    borderLoading.Visibility = Visibility.Hidden;
                }
            }
            if (counter == 2)
            {
                if (sendMail == true)
                {
                    if (codeBox.Text == code.ToString())
                    {
                        NavigationService.Navigate(new PasswordRecoveryNewPasswordPage());

                    }
                }
            }
        }

        private void codeBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
    }
}
