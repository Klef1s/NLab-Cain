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

        private string UrlDisplayChart(string u)
        {
            UrlChart.url = u;
            NavigationService.Navigate(new ChartSongsPage());
            return u;
        }

        private void allWorld_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbMDoHDwVN2tF/tracks");
        }

        private void australia_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbJPcfkRz0wJ0/tracks");
        }

        private void austria_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbKNHh6NIXu36/tracks");
        }

        private void argentina_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbMMy2roB9myp/tracks");
        }

        private void belarus_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbIYfjSLbWr4V/tracks");
        }

        private void belgium_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbJNSeeHswcKB/tracks");
        }

        private void bulgaria_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbMXbN3EUUhlg/tracks");
        }

        private void brazil_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbNfM2w2mq1B8/tracks");
        }

        private void uk_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbLnolsZ8PSNw/tracks");
        }

        private void hungary_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbNHwMxAkvmF8/tracks");
        }

        private void venezuela_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbNLrliB10ZnX/tracks");
        }

        private void germany_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbJiZcmkrIHGU/tracks");
        }

        private void hongKong_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbLwpL8TjsxOG/tracks");
        }

        private void greece_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbJqdarpmTJDL/tracks");
        }

        private void dominicana_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbKAbrMR8uuf7/tracks");
        }

        private void egypt_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbLn7RQmT5Xv2/tracks");
        }

        private void israel_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbJ6IpvItkve3/tracks");
        }

        private void india_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbLZ52XmnySJg/tracks");
        }

        private void luxembourg_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbKGcyg6TFGx6/tracks");
        }

        private void portugal_Click(object sender, RoutedEventArgs e)
        {
            UrlDisplayChart("https://api.spotify.com/v1/playlists/37i9dQZEVXbKyJS56d1pgi/tracks");
        }
    }
}
