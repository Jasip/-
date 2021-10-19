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
        public Game(string username, string victor)
        {
            InitializeComponent();
            ShowName.Text = username;
            path = @"Victors\" + victor + ".dat";
            Start();
        }
        string path;
        public Random rnd = new Random();
        List<Classes.Victorina> quests = new List<Classes.Victorina>();
        List<int> Numbers = new List<int>();
        List<Button> btns = new List<Button>();

        int state = 0;
        string CorAnser;
        int cost = 0;
        int n;
        bool help = false;
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.MainPage());
        }
        private void Start()
        {
            try
            {
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                while (reader.PeekChar() > -1)
                    quests.Add(new Classes.Victorina(reader.ReadInt32(), reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadInt32()));
            Random r = new Random();
            int value;
            for (int i = 0; i < 10;)
            {
                value = r.Next(10);
                if (!Numbers.Contains(value))
                {
                    Numbers.Add(value);
                    i++;
                }
            }
            btns.Add(Answer1);
            btns.Add(Answer2);
            btns.Add(Answer3);
            btns.Add(Answer4);
            Stage();
            }
            catch
            {
                MessageBox.Show("Ошибка в чтении файла!");
                
            }
        }
        private void Stage()
        {
            for (int i = 0; i < 3; i++)
            {
                btns[i].Visibility = Visibility.Visible;
            }
            SumCost.Text = "Ваши очки: " + cost.ToString();
            if (state > 9)
            {
                Classes.Manager.MainFrame.Navigate(new Pages.Result(ShowName.Text, cost));
            }
            else
            {
                n = Numbers[state];
                int corect = rnd.Next(1, 4);
                if (corect == 1)
                {
                    Quest.Content = quests[n].quest;
                    Answer1.Content = quests[n].answer1;
                    Answer2.Content = quests[n].answer2;
                    Answer3.Content = quests[n].answer3;
                    Answer4.Content = quests[n].answer4;
                }
                if (corect == 2)
                {
                    Quest.Content = quests[n].quest;
                    Answer1.Content = quests[n].answer2;
                    Answer2.Content = quests[n].answer3;
                    Answer3.Content = quests[n].answer4;
                    Answer4.Content = quests[n].answer1;
                }
                if (corect == 3)
                {
                    Quest.Content = quests[n].quest;
                    Answer1.Content = quests[n].answer2;
                    Answer2.Content = quests[n].answer4;
                    Answer3.Content = quests[n].answer3;
                    Answer4.Content = quests[n].answer1;
                }
                if (corect == 4)
                {
                    Quest.Content = quests[n].quest;
                    Answer1.Content = quests[n].answer4;
                    Answer2.Content = quests[n].answer3;
                    Answer3.Content = quests[n].answer2;
                    Answer4.Content = quests[n].answer1;
                }
                CorAnser = quests[n].answer4;
            }
        }

        private void Answer_Click(object sender, RoutedEventArgs e)
        {
            Button text = (Button)sender;
            if (help)
            {
                if (text.Content.ToString() != CorAnser)
                {
                    text.Visibility = Visibility.Hidden;
                    help = false;
                }
                else
                {
                    cost = cost + quests[n].cost;
                    Count.Text = "Вопрос " + (state + 2).ToString() + "/10";
                    state++;
                    Stage();
                    help = false;
                }
            }
            else
            {
                if (text.Content.ToString() == CorAnser)
                {
                    cost = cost + quests[n].cost;
                }
                Count.Text = "Вопрос " + (state + 2).ToString() + "/10";
                state++;
                Stage();
            }
        }

        private void Button_Click_help1(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            int i = 0;

            while (i < 2)
            {
                int j = r.Next(0, 3);
                if (btns[j].Content.ToString() != CorAnser && (btns[j].IsVisible==true))
                {
                    btns[j].Visibility = Visibility.Hidden;
                    i++;
                }
            }
            Button btn = (Button)sender;
            btn.Visibility = Visibility.Hidden;
        }
        private void Button_Click_help2(object sender, RoutedEventArgs e)
        {
            help = true;
            Button btn = (Button)sender;
            btn.Visibility = Visibility.Hidden;
        }
    }
}
