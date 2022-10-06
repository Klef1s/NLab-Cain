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

namespace NLab_Cain.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void AuthFrame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            //Анимация - слайд
            var ta = new ThicknessAnimation();
            ta.Duration = TimeSpan.FromSeconds(0.4);
            ta.DecelerationRatio = 0.7;
            ta.To = new Thickness(0, 0, 0, 0);

            if (e.NavigationMode == NavigationMode.New)
            {
                ta.From = new Thickness(0, 1000, 0, 0);
            }
            else if (e.NavigationMode == NavigationMode.Back)
            {
                ta.From = new Thickness(0, 1000, 0, 0);
            }
            //AuthFrame.BeginAnimation(MarginProperty, ta);

            //Аниамция - затухания
            var fa = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.3));
            AuthFrame.BeginAnimation(OpacityProperty, fa);
        }
    }
}
