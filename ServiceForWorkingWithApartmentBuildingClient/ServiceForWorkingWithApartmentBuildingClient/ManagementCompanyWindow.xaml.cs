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
        ManagementCompanyProfileView Profile { get; set; }
        public ManagementCompanyWindow()
        {
            InitializeComponent();
        }

        public async void Show(string managementCompanyName)
        {
            Profile = await Server.GetManagementCompanyProfile(managementCompanyName);
            lblName.Text = $" {Profile.Name}";
            lblInfo.Text = $" {Profile.Info}";
            LoadMeeting();
            this.Show();
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
        private async void btnCreatePoll_Click(object sender, RoutedEventArgs e)
        {
            var cmi = (ComboBoxItem)cmbBuildingAddressesForCreaatePoll.SelectedItem;
            if (cmi == null)
                MessageBox.Show("Вы не выбрали дом");

            string buildingId = (string)cmi.Tag;
            string question = tbPollQuestionForCreatePoll.Text;
            List<string> answers = new List<string>();

            foreach(var answer in stpAnswerOptions.Children)
            {
                var tbAnswer = (TextBox)answer;
                answers.Add(tbAnswer.Text);
            }

            var createPollBinding = new CreatePollBinding()
            {
                Question = question,
                Answers = answers,
                OwnerId = Profile.Id.ToString(),
            };

            await Server.CreatePollByBuildingId(buildingId, createPollBinding);

            lblCreatePollState.Content = "Опрос успешно создан";
            tbPollQuestionForCreatePoll.Text = "";
            foreach (var answer in stpAnswerOptions.Children)
            {
                var tbAnswer = (TextBox)answer;
                tbAnswer.Text = "";
            }
        }

        int lastItem { get; set; }

        private void tbMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int tab = tcMain.SelectedIndex;

            if (tab == lastItem)
                return;

            switch(tab)
            {
                case 0:
                    LoadMeeting();
                    break;
                case 1:
                    LoadPoll();
                    break;
                case 2:
                    LoadBuildingsForCreatePoll();
                    break;
                case 3:
                    LoadBuildingsForCreateAnnouncement();
                    break;
            }
            lastItem = tab;
        }

        private async void LoadPoll()
        {
            stpPolls.Children.Clear();

            var polls = await Server.GetPollsFromManagementCompany(Profile.Id.ToString());
            foreach (var poll in polls)
                new PollButtonForManagementCompany(stpPolls, poll);
        }

        async void LoadBuildingsForCreatePoll()
        {
            var buildings = await Server.GetBuildings(Profile.Id.ToString());

            foreach (var building in buildings)
                cmbBuildingAddressesForCreaatePoll.Items.Add(new ComboBoxItem()
                {
                    Content = building.Address,
                    Tag = building.BuildingId.ToString()
                });
        }

        async void LoadBuildingsForCreateAnnouncement()
        {
            var buildings = await Server.GetBuildings(Profile.Id.ToString());

            foreach (var building in buildings)
                cmbBuildingAddressesForCreateAnnouncement.Items.Add(new ComboBoxItem()
                {
                    Content = building.Address,
                    Tag = building.BuildingId.ToString()
                });
        }


        private async void LoadMeeting()
        {
            Profile = await Server.GetManagementCompanyProfile(Profile.Name);
            if (Profile.HasMeeting != null)
            {
                var button = CreateBtnGoToMeeting();
                spMeeting.Children.Add(button);
            }
            else
            {
                var buildings = await Server.GetBuildings(Profile.Id.ToString());
                var formForMeetingCreate = new FormFotMeetingCreate(Profile.Id.ToString(), buildings);
                spMeeting.Children.Add(formForMeetingCreate);
            }
        }

        private async void btnCreateNewAnnouncement_Click(object sender, RoutedEventArgs e)
        {
            var cmi = (ComboBoxItem)cmbBuildingAddressesForCreateAnnouncement.SelectedItem;
            if (cmi == null)
                MessageBox.Show("Вы не выбрали дом");

            string buildingId = (string)cmi.Tag;
            string title = tbAnnouncementTitleForCreateAnnouncement.Text;
            string content = tbAnnouncementContentForCreateAnnouncement.Text;

            var createAnnouncementBinding = new CreateAnnouncementBinding()
            {
                Title = title,
                Content = content
            };

            await Server.CreateAnnouncementByBuildingId(buildingId, createAnnouncementBinding);
            lblCreateAnnouncementState.Content = "Объявление успешно создано";

            tbAnnouncementTitleForCreateAnnouncement.Text = "";
            tbAnnouncementContentForCreateAnnouncement.Text = "";
        }

        private async void btnCreateBuilding_Click(object sender, RoutedEventArgs e)
        {
            string address = tbBuildingAddressForCreateBuildin.Text;
            var createBuildingBinding = new CreateBuildingBinding()
            {
                Address = address
            };

            bool result = await Server.CreateBuildingByManagementCompanyId(Profile.Id.ToString(), createBuildingBinding);

            if (result == true)
                lblCreateBuildingState.Content = "Адрес успешно на вас зарегестрирован";
            else
                lblCreateBuildingState.Content = "Данный адрес уже зарегистрирован на другую компанию";
        }

        private Button CreateBtnGoToMeeting()
        {
            Button btn = new Button()
            {
                Height = 200,
                Width = 200,
                Margin = new Thickness(30, 0, 0, 0),
                Style = (Style)this.FindResource("btnGoToMeeting")
            };
            return btn;
        }
    }
}