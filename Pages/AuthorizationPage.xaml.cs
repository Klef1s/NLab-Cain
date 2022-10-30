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
using Microsoft.EntityFrameworkCore;
using NLab_Cain.Models;
using NLab_Cain.Windows;

namespace NLab_Cain.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        async private void logInButton_Click(object sender, RoutedEventArgs e)
        {
            borderLoading.Visibility = Visibility.Visible;

            string email = inputEmail.Text.Trim();
            string password = inputPassword.Password.Trim();

            bool resultValidEmail = ValidatorExtensions.IsValidEmailAddress(email);
            bool resultValidPassword = ValidatorExtensions.IsValidPassword(password);

            User? authUser = null;
            
            if (resultValidEmail && resultValidPassword == true)
            {
                await Task.Run(() =>
                {
                    using (var db = new ApplicationContext())
                    {
                        authUser = db.Users.Where(b => b.Email == email && b.Password == password).FirstOrDefault();
                    }
                });

                //Открытие нового окна
                if (authUser != null)
                {
                    borderLoading.Visibility = Visibility.Collapsed;
                    authPasswordErrorMessage.Visibility = Visibility.Collapsed;

                    OpenMainWindow();
                }
                else
                {
                    borderLoading.Visibility = Visibility.Hidden;
                    //ошибка, такого аккаунта не существует
                    ErrorMessage();
                }
            }
            else
            {
                borderLoading.Visibility = Visibility.Hidden;
                ErrorMessage();
            }


        }

        private void toRegistrationPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }

        private void forgotPasswordButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PasswordRecoveryConfirmationPage());
        }

        private void OpenMainWindow()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            Application.Current.MainWindow.Close();
        }

        private void ErrorMessage()
        {
            authPasswordErrorMessage.Visibility = Visibility.Visible;
            authPasswordErrorMessage.Text = "Электронная почта или пароль неверны";
        }
    }
}
