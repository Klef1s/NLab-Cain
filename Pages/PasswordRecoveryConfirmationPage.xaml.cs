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
        StreamReader sr = new StreamReader("D:/Application/C#/NLab Cain/Resources/Files/text.txt", Encoding.UTF8);


        public PasswordRecoveryConfirmationPage()
        {
            InitializeComponent();
        }

        async private void continueButton_Click(object sender, RoutedEventArgs e)
        {
            string htmlText = sr.ReadToEnd();

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

                    await Task.Run(() =>
                    {
                        try
                        {
                            SmtpClient Smtp = new SmtpClient("smtp.mail.ru", 465);
                            Smtp.EnableSsl = true;
                            Smtp.Credentials = new NetworkCredential("nlab-cain-supprt@mail.ru", "FNtu1QjMr4scP3D6B9KJ");
                            MailMessage Message = new MailMessage();
                            Message.From = new MailAddress("nlab-cain-supprt@mail.ru");
                            Message.To.Add(new MailAddress(email));
                            Message.Subject = "Восстановление пароля";
                            Message.IsBodyHtml = false;
                            Message.Body = htmlText;
                            Smtp.Send(Message);

                            MessageBox.Show("VSE OK");
                        }
                        catch
                        {
                            sendMail = false;
                            MessageBox.Show("PIIIZDA");
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
    }
}
