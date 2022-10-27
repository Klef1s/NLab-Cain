﻿using System;
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
using System.Windows.Shapes;

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
    }
}
