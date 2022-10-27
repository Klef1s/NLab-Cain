using NLab_Cain.Models.ChartModel;
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
    /// Логика взаимодействия для ChartSongsPage.xaml
    /// </summary>
    public partial class ChartSongsPage : Page
    {
        public ChartSongsPage()
        {
            InitializeComponent();
            nameChart.Text = NameChart.nameChart;
        }

        private void backPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }

}
