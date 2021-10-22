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
        List<Classes.Victorina> quests = new List<Classes.Victorina>();
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.MainPage());
        }
        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.Develop());
        }
        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            StackPanel st = (StackPanel)btn.Parent;
            TextBlock tx = (TextBlock)st.Children[0];
            string[] files = Directory.GetFiles(dirName, tx.Text + ".data");
            if (broke(files[0]))
                Classes.Manager.MainFrame.Navigate(new Pages.Develop(files[0]));
            else
                MessageBox.Show("Ошибка в чтение файла");
        }
        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить викторину?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                    Button btn = (Button)sender;
                    StackPanel st = (StackPanel)btn.Parent;
                    TextBlock tx = (TextBlock)st.Children[0];

                if (File.Exists(@"Victors\" + tx.Text + ".data"))
                        File.Delete(@"Victors\" + tx.Text + ".data");
                    Victors.Children.Remove(st);
            }           
        }
        private void Begin()
        {
            
            string[] dirs = Directory.GetFiles(dirName,"*.data");
            for (int i = 0; i < dirs.Length; i++)
            {
                StackPanel victor = new StackPanel()
                {
                    Width = 1700,
                    Orientation = Orientation.Horizontal,
                };
                Victors.Children.Add(victor);



                TextBlock textBlock = new TextBlock()
                {
                    Text = System.IO.Path.GetFileNameWithoutExtension(dirs[i]),
                    FontSize = 50,
                    Width = 400,
                    Height = 120,
                    Foreground=Brushes.White,
                    TextWrapping = TextWrapping.Wrap,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                }; 
                victor.Children.Add(textBlock);



                Image img1 = new Image()
                {
                    Width = 50,
                    Height = 50,
                };
                img1.Source = new BitmapImage(new Uri(@"/CheckYourself;component/Resources/change.png", UriKind.RelativeOrAbsolute));
               
                
                
                Image img2 = new Image()
                {
                    Width = 50,
                    Height = 50,
                };
                img2.Source = new BitmapImage(new Uri(@"/CheckYourself;component/Resources/delete.png", UriKind.RelativeOrAbsolute));



                Button btnEdit = new Button()
                {
                    Content = "Редактировать",
                    FontSize = 50,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Top,
                };  
                btnEdit.Margin = new Thickness(1000, 0, 0, 0);
                btnEdit.Click += Button_Click_Edit;
                victor.Children.Add(btnEdit);
                btnEdit.Content = img1;



                Button btnDel = new Button()
                {
                    Content = "Удалить",
                    FontSize = 50,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Top
                };  
                btnDel.Margin = new Thickness(50, 0, 0, 0);
                victor.Children.Add(btnDel);
                btnDel.Click += Button_Click_Delete;
                btnDel.Content = img2;
            }
        }
        bool broke(string path)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                if (reader.PeekChar() == -1)
                    return false;
            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                    while (reader.PeekChar() > -1)
                    {
                        quests.Add(new Classes.Victorina(reader.ReadInt32(), reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadInt32()));
                    }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
