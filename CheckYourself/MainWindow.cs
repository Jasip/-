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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CheckYourself
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

        private void Button_Click_Play(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Click_DevelopMode(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Click_Help(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
