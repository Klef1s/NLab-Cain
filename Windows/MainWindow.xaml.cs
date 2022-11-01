using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using NLab_Cain.Pages;

namespace NLab_Cain.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void hideApp_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void closeApp_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void moveArea_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void frameMainWindow_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            var fa = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.35));
            frameMainWindow.BeginAnimation(OpacityProperty, fa);
        }

        private void toSettings_Click(object sender, RoutedEventArgs e)
        {
            homeButton.Source = new Uri("/Resources/Images/Icons/Home.svg", UriKind.Relative);
            settingsButton.Source = new Uri("/Resources/Images/Icons/Settings_filled.svg", UriKind.Relative);
            frameMainWindow.Source = new Uri("/Pages/SettingsPage.xaml", UriKind.Relative);
        }

        private void toCharts_Click(object sender, RoutedEventArgs e)
        {
            homeButton.Source = new Uri("/Resources/Images/Icons/Home_filled.svg", UriKind.Relative);
            settingsButton.Source = new Uri("/Resources/Images/Icons/Settings.svg", UriKind.Relative);
            frameMainWindow.Source = new Uri("/Pages/ChartPage.xaml", UriKind.Relative);
        }
    }

    public static class ValidatorExtensions
    {
        public static bool IsValidEmailAddress(this string s)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            try
            {
                return regex.IsMatch(s);
            }
            catch { return false; }
        }
        public static bool IsValidPassword(this string s)
        {
            Regex regex = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,32}$");
            try
            {
                return regex.IsMatch(s);
            }
            catch { return false; }
        }
        public static bool IsValidSecurityCode(this string s)
        {
            Regex regex = new Regex(@"[0-9]");
            try
            {
                return regex.IsMatch(s);
            }
            catch { return false; }
        }
    }
}
