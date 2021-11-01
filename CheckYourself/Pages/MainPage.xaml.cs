using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            if (!Classes.Manager.music)
            {
                Sound.Source = new BitmapImage(new Uri("/Resources/nosound.png", UriKind.Relative));
            }
            else
            {
                Sound.Source = new BitmapImage(new Uri("/Resources/sound.png", UriKind.Relative));
            }
        }
        private void Button_Click_Play(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.ChangeVictor());
        }
        private void Button_Click_DevelopMode(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.ChangeDevelop());
        }
        private void Button_Click_Help(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.Help());
        }
        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void SoundButton_Click(object sender, RoutedEventArgs e)
        {
            if (Classes.Manager.music)
            {
                Classes.Manager.MainSoundPlayer.Stop();
                Classes.Manager.music = false;
                Sound.Source = new BitmapImage(new Uri("/Resources/nosound.png",UriKind.Relative));              
            }
            else
            {
                Classes.Manager.MainSoundPlayer.PlayLooping();
                Classes.Manager.music = true;
                Sound.Source = new BitmapImage(new Uri("/Resources/sound.png", UriKind.Relative));
            }
        }
    }
}
