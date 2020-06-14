using ServiceForWorkingWithApartmentBuildingClient.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ServiceForWorkingWithApartmentBuildingClient
{
    public class PollButtonForManagementCompany
    {
        public PollButtonForManagementCompany(StackPanel stpPolls, PollReference poll)
        {
            this.bt = bt;
            this.st = st;
            this.stPolls = stpPolls;
            Poll = poll;

            st = new StackPanel()
            {
                Background = (Brush)new BrushConverter().ConvertFrom("#7BCCBE"),
            };
            StackPanel stpGetPoll = new StackPanel()
            {
                Orientation = Orientation.Horizontal
            };
            TextBlock tb = new TextBlock
            {
                Text = Poll.Question,
                Margin = new Thickness(10, 10, 0, 10),
                TextWrapping = TextWrapping.Wrap,
                Width = 625,
            };
            bt = new Button()
            {

                Width = 23,
                Height = 23,
                Content = "v",
                Background = (Brush)new BrushConverter().ConvertFrom("#7BCCBE"),
            };
            bt.Click += ButtonPollClick;

            btClose = new Button()
            {

                Width = 23,
                Height = 23,
                Content = "x",
                Background = (Brush)new BrushConverter().ConvertFrom("#7BCCBE"),
                Margin = new Thickness(15,0,0,0)
            };
            btClose.Click += Close;

            stpGetPoll.Children.Add(tb);
            stpGetPoll.Children.Add(bt);
            stpGetPoll.Children.Add(btClose);
            st.Children.Add(stpGetPoll);
            stpPolls.Children.Add(st);
        }

        Button bt { get; set; }

        Button btClose { get; set; }

        StackPanel st { get; set; }

        PollReference Poll { get; set; }

        StackPanel stPolls { get; set; }

        bool Flag = true;

        private async void ButtonPollClick(object sender, RoutedEventArgs e)
        {
            if (Flag)
            {
                var answers = await Server.GetAnswerOption(Poll.PollId.ToString());
                st.Children.Add(CreateGridForAnswers(answers));
            }
            else
            {
                int lastIndexInSt = st.Children.Count;
                st.Children.RemoveAt(lastIndexInSt - 1);
            }
            Flag = !Flag;
        }

        private async void Close(object sender, RoutedEventArgs e)
        {
            await Server.ClosePoll(Poll.PollId.ToString());

            stPolls.Children.Remove(st);
        }

        private Grid CreateGridForAnswers(List<AnswerOptionReference> answerList)
        {
            Grid grPollAnswer = new Grid()
            {
                Name = "grAnswerOptionsOfPool",
                Width = 700,
                Background = Brushes.White,
                Margin = new Thickness(0, 10, 0, 10),
            };
            for (int i = 0; i < answerList.Count; i++)
            {
                grPollAnswer.RowDefinitions.Add(new RowDefinition());
            }
            grPollAnswer.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(600) });
            grPollAnswer.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(100) });


            int countVoters = 0;
            for (int i = 0; i < answerList.Count; i++)
            {
                countVoters += answerList[i].VotersNumber;
            }

            for (int i = 0; i < answerList.Count; i++)
            {
                grPollAnswer.Children.Add(CreateTextBlockForAnswers(answerList[i].Answer, grPollAnswer, i, 0));

                string countVotersForThisAnswer;
                if (countVoters == 0)
                    countVotersForThisAnswer = $"{answerList[i].VotersNumber} (0%)";
                else
                    countVotersForThisAnswer = $"{answerList[i].VotersNumber} " +
                        $"({(int)((answerList[i].VotersNumber / ((double)countVoters))*100)}%)";

                grPollAnswer.Children.Add(CreateTextBlockForAnswers(countVotersForThisAnswer.ToString(),
                    grPollAnswer, i, 1));
            }
            return grPollAnswer;
        }

        private Border CreateTextBlockForAnswers(string text, Grid grForAnswers, int rowNum, int colNum)
        {
            TextBlock tbl = new TextBlock
            {
                Text = text,
                VerticalAlignment = VerticalAlignment.Center,
                TextAlignment = TextAlignment.Center,
                TextWrapping = TextWrapping.Wrap,
                FontFamily = new FontFamily("Palatino Linotype"),
                Margin = new Thickness(0, 5, 0, 5),
            };
            var br = new Border
            {
                BorderThickness = new Thickness(0.5),
                BorderBrush = new SolidColorBrush(Colors.SlateGray),
                Child = tbl
            };
            Grid.SetColumn(br, colNum);
            Grid.SetRow(br, rowNum);

            return br;
        }
    }
}
