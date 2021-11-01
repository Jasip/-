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
            textboxs.Add(Answer1);
            textboxs.Add(Answer2);
            textboxs.Add(Answer3);
            textboxs.Add(Answer4);
        }
        public Develop(string nameVictor)
        {
            InitializeComponent();
            AddQuest.IsEnabled = false;
            path = nameVictor;
            editmode = true;
            textboxs.Add(Answer1);
            textboxs.Add(Answer2);
            textboxs.Add(Answer3);
            textboxs.Add(Answer4);
            EditMode();
        }
        bool editmode;
        string path;
        List<TextBox> textboxs  = new List<TextBox>();
        List<Classes.Victorina> quests = new List<Classes.Victorina>();
        public int count = 0;
        int QuestNum = 2;
        int ID;
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.GoBack();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        { 
            bool ok = false;
            if (NameVictor.Text.Length > 0)
                if (Quest.Text.Length > 0)
                    if (Answer1.Text.Length > 0 && Answer2.Text.Length > 0 && Answer3.Text.Length > 0 && Answer4.Text.Length > 0)
                        if (Cost.Text.Length > 0)
                            try
                            {
                                Convert.ToInt32(Cost.Text);
                                if (Convert.ToInt32(Cost.Text) >= 1)
                                    {
                                    ok = true;
                                    for (int j = 0; j < 4; j++)
                                        for (int i = 0; i < 4; i++)
                                        {
                                            if ((textboxs[i].Text == textboxs[j].Text) && (i != j))
                                                ok = false;
                                        }
                                    if (!ok)
                                        MessageBox.Show("Ответы не могут повторяться!");
                                    }
                                else
                                    MessageBox.Show("Кол-во очков не может быть меньше нуля!");   
                            } 
                            catch
                            {
                                MessageBox.Show("Кол-во очков должно быть только числового формата");
                            }
                        else MessageBox.Show("Укажите стоимость вопроса");
                    else MessageBox.Show("Укажите все четыре ответа на ваш вопрос");
                else MessageBox.Show("Укажите вопрос");
            else MessageBox.Show("Укажите название викторины");
            if (ok)
            {
                quests.Add(new Classes.Victorina(count, Quest.Text, Answer1.Text, Answer2.Text, Answer3.Text, Answer4.Text, int.Parse(Cost.Text)));
                NameVictor.IsEnabled = false;
                Quest.Text = null;
                Answer1.Text = null;
                Answer2.Text = null;
                Answer3.Text = null;
                Answer4.Text = null;
                Cost.Text = null;
                count++;
                var bc = new BrushConverter();
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
                    CreateVictor.Visibility = Visibility.Visible;
                    AddQuest.Visibility = Visibility.Hidden;
                }
                else
                {
                    for (int i = 0; i < SP_Questions.Children.Count; i++)
                    {
                        (SP_Questions.Children[i] as Button).Foreground = Brushes.White;
                    }
                    Button button = new Button()
                    {
                        Content = "Вопрос " + QuestNum,
                        FontSize = 50,
                        Foreground = (Brush)bc.ConvertFrom("#1266cc"),
                        HorizontalAlignment = HorizontalAlignment.Left
                    };
                    button.Click += Button_Click_SelectQuest;
                    SP_Questions.Children.Add(button);
                    QuestNum++;
                }
            }
        }
        
        private void Button_Click_Create(object sender, RoutedEventArgs e)
        {        
            string path = @"Victors\" + NameVictor.Text + ".data";    
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
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
                MessageBox.Show("Викторина создана");
                Classes.Manager.MainFrame.Navigate(new Pages.ChangeDevelop());
            }
            catch
            {
                MessageBox.Show("Ошибка в записи файлов");
                Classes.Manager.MainFrame.Navigate(new Pages.ChangeDevelop());
            }
        }
        private void EditMode()
        {
            AddQuest.Visibility = Visibility.Hidden;
            CreateVictor.Visibility = Visibility.Visible;
            CreateVictor.Content = "Сохранить викторину";
            NameVictor.Text = System.IO.Path.GetFileNameWithoutExtension(path);
            NameVictor.IsEnabled = false;
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                while (reader.PeekChar() > -1)
                    quests.Add(new Classes.Victorina(reader.ReadInt32(), reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadInt32()));
            for (int i = 0; i < 9; i++)
            {
                Button button = new Button()
                {
                    Content = "Вопрос " + QuestNum,
                    FontSize = 50,
                    HorizontalAlignment = HorizontalAlignment.Left
                };
                button.Click += Button_Click_SelectQuest;
                SP_Questions.Children.Add(button);
                QuestNum++;
                SelectQuest(0);
            }
        }
        private void SelectQuest(int id)
        {
            try
            {
                ID = id;
                Quest.Text = quests[id].quest;
                Answer1.Text = quests[id].answer1;
                Answer2.Text = quests[id].answer2;
                Answer3.Text = quests[id].answer3;
                Answer4.Text = quests[id].answer4;
                Cost.Text = quests[id].cost.ToString();
            }
            catch
            {
                Quest.Text = null;
                Answer1.Text = null;
                Answer2.Text = null;
                Answer3.Text = null;
                Answer4.Text = null;
                Cost.Text = null;
            }
        }
        private void Button_Click_SelectQuest(object sender, RoutedEventArgs e)
        {
            for(int i=0; i<SP_Questions.Children.Count;i++)
            {
                (SP_Questions.Children[i] as Button).Foreground = Brushes.White;
            }
            var bc = new BrushConverter();
            Button btn = (Button)sender;
            btn.Foreground = (Brush)bc.ConvertFrom("#1266cc");
            string text = btn.Content.ToString();
            string[] strings;
            strings = text.Split(' ');
            SelectQuest(Convert.ToInt32(strings[1].ToString())-1);
        }


        private void Answer4_LostFocus(object sender, RoutedEventArgs e)
        {
            if (editmode)
            {
                bool ok = false;
                if (NameVictor.Text.Length > 0)
                    if (Quest.Text.Length > 0)
                        if (Answer1.Text.Length > 0 && Answer2.Text.Length > 0 && Answer3.Text.Length > 0 && Answer4.Text.Length > 0)
                            if (Cost.Text.Length > 0)
                                try
                                {
                                    Convert.ToInt32(Cost.Text);
                                    if (Convert.ToInt32(Cost.Text) > 1)
                                    {
                                        ok = true;
                                        for (int j = 0; j < 4; j++)
                                            for (int i = 0; i < 4; i++)
                                            {
                                                if ((textboxs[i].Text == textboxs[j].Text) && (i != j))
                                                    ok = false;
                                            }
                                        if (!ok)
                                            MessageBox.Show("Ответы не могут повторяться!");
                                    }
                                    else
                                        MessageBox.Show("Кол-во очков не может быть меньше нуля!");
                                }
                                catch
                                {
                                    MessageBox.Show("Кол-во очков должно быть только числового формата");
                                }
                            else MessageBox.Show("Укажите стоимость вопроса");
                        else MessageBox.Show("Укажите все четыре ответа на ваш вопрос");
                    else MessageBox.Show("Укажите вопрос");
                else MessageBox.Show("Укажите название викторины");
                if (ok)
                {
                    quests[ID].quest = Quest.Text;
                    quests[ID].answer1 = Answer1.Text;
                    quests[ID].answer2 = Answer2.Text;
                    quests[ID].answer3 = Answer3.Text;
                    quests[ID].answer4 = Answer4.Text;
                    quests[ID].cost = Int32.Parse(Cost.Text);
                }
            }
        }

        
    }
}
