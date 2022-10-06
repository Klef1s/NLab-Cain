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
        ApplicationContext db = new ApplicationContext();

        public AuthorizationPage()
        {
            InitializeComponent();
        }

        async private void logInButton_Click(object sender, RoutedEventArgs e)
        { 
            string login = inputLogin.Text.Trim();
            string password = inputPassword.Password.Trim();

            User? authUser = null;

            await Task.Run(() =>
            {
                using (var db = new ApplicationContext())
                {
                    authUser = db.Users.Where(b => b.Login == login && b.Password == password).FirstOrDefault();
                }
            });

            if (authUser != null)
            {
                //переход на основное окно
            }
            else
            {
               //ошибка, такого аккаунта не существует
            }
        }
    }
}
