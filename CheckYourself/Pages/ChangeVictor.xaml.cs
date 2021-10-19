using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для ChangeVictor.xaml
    /// </summary>
    public partial class ChangeVictor : Page
    {
        public ChangeVictor()
        {
            InitializeComponent();
            Victors.Foreground = Brushes.Black;
            Begin();
        }
        string dirName = @"Victors\";
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.GoBack();
        }

        private void Button_Click_Play(object sender, RoutedEventArgs e)
        {
            if (Victors.SelectedIndex >= 0)
                if (Name.Text.Length > 0)
                    Classes.Manager.MainFrame.Navigate(new Pages.Game(Name.Text, Victors.SelectedItem.ToString()));
                else
                    MessageBox.Show("Укажите ник для начала игры");
            else
                MessageBox.Show("Выберите викторину для начала игры");
        }
        private void Begin ()
        {
            string[] dirs = Directory.GetFiles(dirName,"*.dat");
            for (int i = 0; i < dirs.Length; i++)
            {
                Victors.Items.Add(System.IO.Path.GetFileNameWithoutExtension(dirs[i]));
            }
        }
    }
}
