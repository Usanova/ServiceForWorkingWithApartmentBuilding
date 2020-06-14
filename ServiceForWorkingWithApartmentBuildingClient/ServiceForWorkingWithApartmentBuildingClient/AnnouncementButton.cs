using ServiceForWorkingWithApartmentBuildingClient.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ServiceForWorkingWithApartmentBuildingClient
{
    public class AnnouncementButton
    {
        public AnnouncementButton(StackPanel stpPolls, AnnouncementReference announcement)
        {
            Announcement = announcement;
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
                Text = Announcement.Title,
                Margin = new Thickness(10, 10, 0, 10),
                TextWrapping = TextWrapping.Wrap,
                Width = 665,
                VerticalAlignment = VerticalAlignment.Center
            };
            bt = new Button()
            {

                Width = 23,
                Height = 23,
                Content = "v",
                Background = (Brush)new BrushConverter().ConvertFrom("#7BCCBE"),
            };
            bt.Click += ButtonAnnouncementClick;

            stpGetPoll.Children.Add(tb);
            stpGetPoll.Children.Add(bt);
            st.Children.Add(stpGetPoll);
            stpPolls.Children.Add(st);
        }

        Button bt { get; set; }

        StackPanel st { get; set; }

        AnnouncementReference Announcement { get; set; }

        bool Flag = true;

        private async void ButtonAnnouncementClick(object sender, RoutedEventArgs e)
        {
            if (Flag)
            {
                st.Children.Add(CreateGridForAnswers());
            }
            else
            {
                int lastIndexInSt = st.Children.Count;
                st.Children.RemoveAt(lastIndexInSt - 1);
            }
            Flag = !Flag;
        }

        private Grid CreateGridForAnswers()
        {
            Grid grPollAnswer = new Grid()
            {
                Name = "grAnswerOptionsOfPool",
                Width = 700,
                Background = Brushes.White,
                Margin = new Thickness(0, 10, 0, 10),
            };

            grPollAnswer.Children.Add(new TextBlock()
            {
                TextAlignment = TextAlignment.Center,
                Text = Announcement.Content,
            });

            return grPollAnswer;
        }
    }
}
