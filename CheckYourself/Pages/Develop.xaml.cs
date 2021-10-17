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
    /// Логика взаимодействия для Develop.xaml
    /// </summary>
    public partial class Develop : Page
    {
        public Develop()
        {
            InitializeComponent();
            CreateVictor.IsEnabled = false;
        }
        List<Classes.Victorina> quests = new List<Classes.Victorina>();
        public int count = 0;
        int QuestNum = 2;
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.GoBack();
        }
        
        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            
            Button button = new Button()
            {
                Content = "Вопрос " + QuestNum,
                FontSize = 50,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            SP_Questions.Children.Add(button);
            QuestNum++;

            quests.Add(new Classes.Victorina(count,Quest.Text,Answer1.Text,Answer2.Text,Answer3.Text,Answer4.Text,int.Parse(Cost.Text)));
            NameVictor.IsEnabled = false;
            Quest.Text = null;
            Answer1.Text = null;
            Answer2.Text = null;
            Answer3.Text = null;
            Answer4.Text = null;
            Cost.Text = null;
            count++;
            if (count == 10)
            {
                Quest.IsEnabled = false;
                Answer1.IsEnabled = false;
                Answer2.IsEnabled = false;
                Answer3.IsEnabled = false;
                Answer4.IsEnabled = false;
                Cost.IsEnabled = false;
                CreateVictor.IsEnabled = true;
                AddQuest.IsEnabled = false;
            }
        }
        private void Button_Click_Create(object sender, RoutedEventArgs e)
        {
            string path = @"Victors\" + NameVictor.Text + ".dat";

            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
                {
                    foreach (Classes.Victorina s in quests)
                    {
                        writer.Write(s.count);
                        writer.Write(s.quest);
                        writer.Write(s.answer1);
                        writer.Write(s.answer2);
                        writer.Write(s.answer3);
                        writer.Write(s.answer4);
                        writer.Write(s.cost);
                    }
                    writer.Close();
                }  
            }
            catch
            {
                MessageBox.Show("Ошибка в записи файлов");
                Classes.Manager.MainFrame.Navigate(new Pages.ChangeDevelop());
            }
        }
    }
}
