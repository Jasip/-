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
        public Game()
        {
            InitializeComponent();
            Start();
        }
        List<Classes.Victorina> quests = new List<Classes.Victorina>();
        int state = 0;
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.MainPage());
        }
        private void Start()
        {
            string path = @"Victors\" + Name + ".dat";
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                while (reader.PeekChar() > -1)
            quests.Add(new Classes.Victorina(reader.ReadInt32(), reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadInt32()));
            Quest.Content = quests[0].quest;
            Answer1.Content = quests[0].answer1;
            Answer2.Content = quests[0].answer2;
            Answer3.Content = quests[0].answer3;
            Answer4.Content = quests[0].answer4;
        }
    }
}
