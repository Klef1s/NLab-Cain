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
    /// Логика взаимодействия для PasswordRecoveryNewPasswordPage.xaml
    /// </summary>
    public partial class PasswordRecoveryNewPasswordPage : Page
    {
        ApplicationContext db = new ApplicationContext();

        string email = PasswordRecoveryConfirmationPage.email;

        public PasswordRecoveryNewPasswordPage()
        {
            InitializeComponent();
        }

        private async void continueButton_Click(object sender, RoutedEventArgs e)
        {
            string newPassword = inputNewPassword.Password.Trim();
            string repeatPassword = inputRepeatPassword.Password.Trim();

            bool resultValidPassword = ValidatorExtensions.IsValidPassword(newPassword);
            bool resultvalidRepeatPassword = repeatPassword == newPassword;

            User user = null;

            if (resultValidPassword && resultvalidRepeatPassword == true)
            {
                await Task.Run(() =>
                {
                    using (var db = new ApplicationContext())
                    {
                        user = db.Users.Where(b => b.Email == email).FirstOrDefault();
                    }
                });
                if (user != null)
                {
                    user.Password = newPassword;
                    db.Update(user);
                    db.SaveChanges();

                    NavigationService.Navigate(new AuthorizationPage());
                }
            }
            else
            {
                if (resultValidPassword == false)
                {
                    passwordErrorMessage.Visibility = Visibility.Visible;
                    passwordErrorMessage.Text = "Введен некорректный формат пароля";
                }
                else if (resultValidPassword == true) passwordErrorMessage.Visibility = Visibility.Collapsed;

                if (resultvalidRepeatPassword == false || repeatPassword == null)
                {
                    repeatPasswordErrorMessage.Visibility = Visibility.Visible;
                    repeatPasswordErrorMessage.Text = "Пароли не совпадают";
                }
                else if (resultvalidRepeatPassword == true) repeatPasswordErrorMessage.Visibility = Visibility.Collapsed;
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
    }
}
