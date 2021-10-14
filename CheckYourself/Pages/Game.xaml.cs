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
    /// Логика взаимодействия для Game.xaml
    /// </summary>
    public partial class Game : Page
    {
        public Game(string username)
        {
            InitializeComponent();
            Start();
            ShowName.Text = username;
        }
        public Random rnd = new Random();
        List<Classes.Victorina> quests = new List<Classes.Victorina>();
        int state = 0;
        string CorAnser;
        int cost = 0;
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.MainPage());
        }
        private void Start()
        {
            string path = @"Victors\2.dat";
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                while (reader.PeekChar() > -1)
            quests.Add(new Classes.Victorina(reader.ReadInt32(), reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadInt32()));
            Stage();
        }
        private void Stage()
        {
            SumCost.Text = "Ваши очки: " + cost.ToString();
            if (state > 8)
            {
                Classes.Manager.MainFrame.Navigate(new Pages.Result(ShowName.Text, cost));
            }
            else
            {

                int corect = rnd.Next(1, 4);
                if (corect == 1)
                {
                    Quest.Content = quests[state].quest;
                    Answer1.Content = quests[state].answer1;
                    Answer2.Content = quests[state].answer2;
                    Answer3.Content = quests[state].answer3;
                    Answer4.Content = quests[state].answer4;
                }
                if (corect == 2)
                {
                    Quest.Content = quests[state].quest;
                    Answer1.Content = quests[state].answer2;
                    Answer2.Content = quests[state].answer3;
                    Answer3.Content = quests[state].answer4;
                    Answer4.Content = quests[state].answer1;
                }
                if (corect == 3)
                {
                    Quest.Content = quests[state].quest;
                    Answer1.Content = quests[state].answer2;
                    Answer2.Content = quests[state].answer4;
                    Answer3.Content = quests[state].answer3;
                    Answer4.Content = quests[state].answer1;
                }
                if (corect == 4)
                {
                    Quest.Content = quests[state].quest;
                    Answer1.Content = quests[state].answer4;
                    Answer2.Content = quests[state].answer3;
                    Answer3.Content = quests[state].answer2;
                    Answer4.Content = quests[state].answer1;
                }
                CorAnser = quests[state].answer4;
            }
        }

        private void Answer_Click(object sender, RoutedEventArgs e)
        {
            Button text = (Button)sender;
            if (text.Content.ToString() == CorAnser)
            {
                state++;
                cost = cost + quests[state].cost;
                Count.Text = "Вопрос " + (state + 1).ToString() + "/10";
                Stage();
            }
            else
                MessageBox.Show("Неверно!");
        }
    }
}
