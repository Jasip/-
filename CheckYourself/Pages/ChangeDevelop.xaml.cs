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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CheckYourself.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChangeDevelop.xaml
    /// </summary>
    public partial class ChangeDevelop : Page
    {
        public ChangeDevelop()
        {
            InitializeComponent();
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.GoBack();
        }
        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.Develop());
        }
        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.Develop());
        }
        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {

        }
    }
}