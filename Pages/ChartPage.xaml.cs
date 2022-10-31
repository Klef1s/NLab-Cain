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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NLab_Cain.Models.ChartModel;

namespace NLab_Cain.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChartPage.xaml
    /// </summary>
    public partial class ChartPage : Page
    {
        public ChartPage()
        {
            InitializeComponent();
        }

        private void UrlDisplayChart(string u, string n)
        {
            UrlChart.url = u;
            NameChart.nameChart = n;
            NavigationService.Navigate(new ChartSongsPage());

        }

        private void allWorld_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbMDoHDwVN2tF/tracks", "Топ 50 (Во всем мире)");
        }

        private void australia_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbJPcfkRz0wJ0/tracks", "Топ 50 (Австралия)");
        }

        private void austria_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbKNHh6NIXu36/tracks", "Топ 50 (Австрия)");
        }

        private void argentina_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbMMy2roB9myp/tracks", "Топ 50 (Аргентина)");
        }

        private void belarus_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbIYfjSLbWr4V/tracks", "Топ 50 (Беларусь)");
        }

        private void belgium_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbJNSeeHswcKB/tracks", "Топ 50 (Бельгия)");
        }

        private void bulgaria_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbMXbN3EUUhlg/tracks", "Топ 50 (Болгария)");
        }

        private void brazil_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbNfM2w2mq1B8/tracks", "Топ 50 (Бразилия)");
        }

        private void uk_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbLnolsZ8PSNw/tracks", "Топ 50 (Великобритания)");
        }

        private void hungary_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbNHwMxAkvmF8/tracks", "Топ 50 (Венгрия)");
        }

        private void venezuela_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbNLrliB10ZnX/tracks", "Топ 50 (Венесуэла)");
        }

        private void germany_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbJiZcmkrIHGU/tracks", "Топ 50 (Германия)");
        }

        private void hongKong_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbLwpL8TjsxOG/tracks", "Топ 50 (Гонконг)");
        }

        private void greece_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbJqdarpmTJDL/tracks", "Топ 50 (Греция)");
        }

        private void dominicana_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbKAbrMR8uuf7/tracks", "Топ 50 (Доминикана)");
        }

        private void egypt_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbLn7RQmT5Xv2/tracks", "Топ 50 (Египет)");
        }

        private void israel_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbJ6IpvItkve3/tracks", "Топ 50 (Израиль)");
        }

        private void india_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbLZ52XmnySJg/tracks", "Топ 50 (Индия)");
        }

        private void luxembourg_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbKGcyg6TFGx6/tracks", "Топ 50 (Люксембург)");
        }

        private void portugal_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbKyJS56d1pgi/tracks", "Топ 50 (Португалия)");
        }
    }
}