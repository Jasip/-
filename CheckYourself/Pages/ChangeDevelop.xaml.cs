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
using System.IO;

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
            Begin();
        }
        string dirName = @"Victors\";
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
            Button btn = (Button)sender;
            StackPanel st = (StackPanel)btn.Parent;
            TextBlock tx = (TextBlock)st.Children[0];
            string [] files = Directory.GetFiles(dirName, tx.Text+".dat");
            File.Delete(files[0]);
            Victors.Children.Remove(st);
        }
        private void Begin()
        {
            
            string[] dirs = Directory.GetFiles(dirName);
            for (int i = 0; i < dirs.Length; i++)
            {
                StackPanel victor = new StackPanel()
                {
                    Orientation = Orientation.Horizontal,
                };
                Victors.Children.Add(victor);
                TextBlock textBlock = new TextBlock()
                {
                    Text = System.IO.Path.GetFileNameWithoutExtension(dirs[i]),
                    FontSize = 50,
                    Width = 300,
                    Height = 100,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top
                };
                victor.Children.Add(textBlock);
                Button btnEdit = new Button()
                {
                    Content = "Редактировать",
                    FontSize = 50,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                };  btnEdit.Margin = new Thickness(650, 0, 0, 0);
                btnEdit.Click += Button_Click_Edit;
                victor.Children.Add(btnEdit);
                Button btnDel = new Button()
                {
                    Content = "Удалить",
                    FontSize = 50,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Top
                };  btnDel.Margin = new Thickness(50, 0, 0, 0);
                victor.Children.Add(btnDel);
                btnDel.Click += Button_Click_Delete;

            }
        }
    }
}
