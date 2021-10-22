using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
using System.IO;

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
            Classes.Manager.MainFrame = MainFrame;
            Classes.Manager.MainFrame.Navigate(new Pages.MainPage());
            Begin();


        }
        private void Begin()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.IO.Stream resourceStream = assembly.GetManifestResourceStream(@"CheckYourself.maintheme.wav");
            SoundPlayer player = new SoundPlayer(resourceStream);
            Classes.Manager.MainSoundPlayer = player;
            Classes.Manager.MainSoundPlayer.PlayLooping();
        }


    }
}
