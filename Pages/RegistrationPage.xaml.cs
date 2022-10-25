using NLab_Cain.Models;
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
using System.Text.RegularExpressions;

namespace NLab_Cain.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        ApplicationContext db = new ApplicationContext();

        public RegistrationPage()
        {
            InitializeComponent();

        }

        async private void regButton_Click(object sender, RoutedEventArgs e)
        {
            borderLoading.Visibility = Visibility.Visible;

            string email = inputEmail.Text.Trim();
            string password = inputPassword.Password.Trim();
            string repeatPassword = inputRepeatPassword.Password.Trim();

            bool resultValidEmail = ValidatorExtensions.IsValidEmailAddress(email);
            bool resultValidPassword = ValidatorExtensions.IsValidPassword(password);
            bool resultvalidRepeatPassword = repeatPassword == password;

            User addUser = new User { Email = email, Password = password };

            User? authUser = null;

            if (resultValidEmail && resultValidPassword && resultvalidRepeatPassword == true)
            {
                await Task.Run(() =>
                {
                    using (var db = new ApplicationContext())
                    {
                        authUser = db.Users.Where(b => b.Email == email).FirstOrDefault();
                    }
                });

                if (authUser != null)
                {
                    borderLoading.Visibility = Visibility.Hidden;

                    //Такой аккаунт уже существует
                    mailErrorMessage.Visibility = Visibility.Visible;
                    mailErrorMessage.Text = "Аккаунт с таким email уже существует";
                }

                else
                {
                    borderLoading.Visibility = Visibility.Hidden;

                    db.Users.Add(addUser);
                    db.SaveChanges();

                    mailErrorMessage.Visibility = Visibility.Collapsed;
                    passwordErrorMessage.Visibility = Visibility.Collapsed;
                    repeatPasswordErrorMessage.Visibility = Visibility.Collapsed;

                    NavigationService.Navigate(new AuthorizationPage());
                }
            }
            else
            {
                borderLoading.Visibility = Visibility.Hidden;

                if (resultValidEmail == false)
                {
                    mailErrorMessage.Visibility = Visibility.Visible;
                    mailErrorMessage.Text = "Введен не коректный email";
                    
                }
                if (resultValidPassword == false)
                {
                    passwordErrorMessage.Visibility = Visibility.Visible;
                    passwordErrorMessage.Text = "Некорректный пароль";
                }
                if (resultvalidRepeatPassword == false)
                {
                    repeatPasswordErrorMessage.Visibility = Visibility.Visible;
                    repeatPasswordErrorMessage.Text = "Пароли не совпадают";
                }
                else
                {
                    mailErrorMessage.Visibility = Visibility.Collapsed;
                    passwordErrorMessage.Visibility = Visibility.Collapsed;
                    repeatPasswordErrorMessage.Visibility = Visibility.Collapsed;
                }

            }
        }

        private void BackToAuthorizationButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
    }

    public static class ValidatorExtensions
    {
        public static bool IsValidEmailAddress(this string s)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
        }
        public static bool IsValidPassword(this string s)
        {
            Regex regex = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,32}$");
            return regex.IsMatch(s);
        }
    }   
}
