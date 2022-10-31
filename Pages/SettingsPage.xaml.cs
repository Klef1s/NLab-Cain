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
    /// Логика взаимодействия для SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {

        }

        private void tbSignOut_Click(object sender, RoutedEventArgs e)
        {
            OpenAuthorizationWindow();
        }

        private void OpenAuthorizationWindow()
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();

            Application.Current.MainWindow.Close();

            Application.Current.MainWindow = authorizationWindow;
        }
    }
}
