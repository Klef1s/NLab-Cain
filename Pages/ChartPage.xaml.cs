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

        private void allWorld_Click(object sender, RoutedEventArgs e)
        {
            UrlChart.url = "https://api.spotify.com/v1/playlists/37i9dQZEVXbKPTKrnFPD0G/tracks";
            NavigationService.Navigate(new ChartSongsPage());
        }

        private void avstralia_Click(object sender, RoutedEventArgs e)
        {
            UrlChart.url = "https://api.spotify.com/v1/playlists/37i9dQZEVXbMXbN3EUUhlg/tracks";
            NavigationService.Navigate(new ChartSongsPage());
            
        }
    }
}
