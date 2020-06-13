using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ServiceForWorkingWithApartmentBuildingClient.Models;

namespace ServiceForWorkingWithApartmentBuildingClient
{
    /// <summary>
    /// Логика взаимодействия для ManagementCompanyWindow.xaml
    /// </summary>
    public partial class ManagementCompanyWindow : Window
    {
        public ManagementCompanyWindow()
        {
            InitializeComponent();
        }

        // For CreatingPoll
        private void btnNewAnswerOption_Click(object sender, RoutedEventArgs e)
        {
            string name = "answer" + stpAnswerOptions.Children.Count;
            TextBox tb = new TextBox()
            {
                Name = name,
                MaxLength = 1024,
                Margin = new Thickness(0, 20, 0, 0),
                Width = 690,
                Height = 25
            };
            RegisterName(name, tb);
            stpAnswerOptions.Children.Add(tb);
        }

        private void btnDelAnswerOption_Click(object sender, RoutedEventArgs e)
        {
            if (stpAnswerOptions.Children.Count == 0)
                return;
            string name = "answer" + (stpAnswerOptions.Children.Count - 1);
            TextBox tb = (TextBox)stpAnswerOptions.FindName(name);
            stpAnswerOptions.Children.Remove(tb);
            UnregisterName(name);
        }
        // end CreatingPoll

        //ForPolls
        private void InitializePoll(string question, Guid pollId)
        {
            int curNumber = stpPolls.Children.Count;
            StackPanel stpPoll = new StackPanel()
            {
                Background = (Brush)new BrushConverter().ConvertFrom("#7BCCBE"),
                Name = "stpPoll" + curNumber
            };
            RegisterName("stpPoll" + curNumber, stpPoll);
            StackPanel stpGetPoll = new StackPanel()
            {
                Name = "stpGetPoll" + curNumber,
                Orientation = Orientation.Horizontal
            };
            RegisterName("stpGetPoll" + curNumber, stpGetPoll);

            Button btnGetPoll = new Button()
            {
                Name = "btnGetPoll" + curNumber,
                Width = 23,
                Height = 23,
                Content = "v",
                Background = (Brush)new BrushConverter().ConvertFrom("#7BCCBE"),
            };
            btnGetPoll.Tag = pollId;
            btnGetPoll.Click += BtnGetPoll_Click;
            RegisterName("btnGetPoll" + curNumber, btnGetPoll);

            TextBlock tbName = CreateTextBlock("tblNameOfPool" + curNumber, question);
            stpPoll.Children.Add(tbName);


        }

        private void BtnGetPoll_Click(object sender, RoutedEventArgs e)
        {
            Guid pollId = (Guid)this.Tag;
            StackPanel stpGetPoll = (StackPanel)this.Parent;
            StackPanel stpPoll = (StackPanel)stpGetPoll.Parent;
            //get answerList from server

            Grid gr = CreateGridForAnswers(curNumber, new List<AnswerOptionReference>());
            stpPoll.Children.Add(gr);
            stpPolls.Children.Add(stpPoll);
        }

        private TextBlock CreateTextBlock(string name, string text)
        {
            TextBlock tb = new TextBlock
            {
                Name = name,
                Text = text,
                Margin = new Thickness(10, 10, 0, 0),
                TextWrapping = TextWrapping.Wrap
            };
            RegisterName(name, tb);
            return tb;
        }
        private TextBlock CreateTextBlockForAnswers(string name, string text, Grid grForAnswers, int rowNum, int colNum)
        {
            TextBlock tbl = new TextBlock
            {
                Name = name,
                Text = text,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                TextAlignment = TextAlignment.Center
            };
            Grid.SetColumn(tbl, colNum);
            Grid.SetRow(tbl, rowNum);
            RegisterName(name, tbl);
            return tbl;
        }
        private Grid CreateGridForAnswers(int numOfPoll, List<AnswerOptionReference> answerList)
        {
            Grid grPollAnswer = new Grid()
            {
                Name = "grAnswerOptionsOfPool" + numOfPoll,
                Width = 700,
                Background = Brushes.White,
                Margin = new Thickness(0, 10, 0, 10),
            };
            for (int i = 0; i < answerList.Count; i++)
            {
                grPollAnswer.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(23) });
            }
            grPollAnswer.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(380) });
            grPollAnswer.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(80) });

            for (int i = 0; i < answerList.Count; i++)
            {
                grPollAnswer.Children.Add(CreateTextBlockForAnswers("answerName" + numOfPoll + i.ToString(), answerList[i].Answer, grPollAnswer, i, 0));
                grPollAnswer.Children.Add(CreateTextBlockForAnswers("votersNumber" + numOfPoll + i.ToString(), answerList[i].Answer, grPollAnswer, i, 1));
            }
            return grPollAnswer;
        }
        // end ForPolls
        private void btnCreatePoll_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}