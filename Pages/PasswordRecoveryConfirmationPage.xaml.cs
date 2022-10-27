using NLab_Cain.Models;
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
        public PasswordRecoveryConfirmationPage()
        {
            InitializeComponent();
        }

        async private void continueButton_Click(object sender, RoutedEventArgs e)
        {
            string htmlText = "";

            borderLoading.Visibility = Visibility.Visible;

            string email = inputEmail.Text.Trim();
            bool resultValidEmail = ValidatorExtensions.IsValidEmailAddress(email);

            User? authUser = null;

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
                    bool sendMail = true;

                    SmtpClient Smtp = new SmtpClient("smtp.mail.ru", 587);
                    Smtp.EnableSsl = true;
                    Smtp.Credentials = new NetworkCredential("aristrax337@mail.ru", "P85ummqpM1LKCD0v4nHT");
                    MailMessage Message = new MailMessage();
                    Message.From = new MailAddress("aristrax337@mail.ru");
                    Message.To.Add(new MailAddress(email));
                    Message.Subject = "Восстановление пароля";
                    Message.IsBodyHtml = true;
                    Message.Body = htmlText;

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

        private void firstBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            secondBox.Focus();
        }

        private void secondBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            thirdBox.Focus();
        }

        private void thirdBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            fourthBox.Focus();
        }

        private void fourthBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            fifthBox.Focus();
        }

        private void fifthBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            sixthBox.Focus();
        }
    }
}
