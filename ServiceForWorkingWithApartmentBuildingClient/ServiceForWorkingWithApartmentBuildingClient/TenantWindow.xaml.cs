using ServiceForWorkingWithApartmentBuildingClient.Models;
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

namespace ServiceForWorkingWithApartmentBuildingClient
{
    /// <summary>
    /// Логика взаимодействия для TenantWindow.xaml
    /// </summary>
    public partial class TenantWindow : Window
    {
        ProfileView Profile { get; set; }
        public TenantWindow()
        {
            InitializeComponent();
        }

        public async void Show(string tenatName, string tenatSurname, string tenantPassword)
        {
            Profile = await Server.GetTenantProfile(tenatName, tenatSurname, tenantPassword);
            tblName.Text = $"{tblName.Text}: {Profile.Name}";
            tblSurname.Text = $"{tblSurname.Text}: {Profile.Surname}";
            tblManagementCompanyName.Text = $"{tblManagementCompanyName.Text}: {Profile.NameManagmentCompany}";
            tblAddress.Text = $"{tblAddress.Text}: {Profile.Address}";
            tblEntranceNumber.Text = $"{tblEntranceNumber.Text}: {Profile.EntranceNumber}";
            tblFlatNumber.Text = $"{tblFlatNumber.Text} {Profile.FlatNumber}";
            if (Profile.HasMeeting != null)
                CreateBtnGoToMeeting();

            lastItem = 1;
            this.Show();
        }
        private Button CreateBtnGoToMeeting()
        {
            Button btn = new Button()
            {
                Height = 100,
                Width = 100,
                Margin = new Thickness(30, 0, 0, 0),
                Style = (Style)this.FindResource("btnGoToMeeting")
            };
            return btn;
        }

        private async void btnStartMeeting(object sender, RoutedEventArgs e)
        {
            var chatWindow = new ChatWindow(Profile.Id.ToString(), Profile.HasMeeting, Profile.Name + Profile.Surname, true);
            chatWindow.ShowDialog();
        }

        int lastItem { get; set; }

        private void tbMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int tab = tcMain.SelectedIndex;

            if (tab == lastItem)
                return;

            switch (tab)
            {
                case 0:
                    LoadPoll();
                    break;
                case 1:
                    LoadAnnouncement();
                    break;
            }
            lastItem = tab;
        }

        private async void LoadPoll()
        {
            stpPolls.Children.Clear();

            var polls = await Server.GetPollsForTeant(Profile.Id.ToString());
            foreach (var poll in polls)
                new PollButtonForTenant(stpPolls, poll);
        }

        private async void LoadAnnouncement()
        {
            stpAnnouncements.Children.Clear();

            var announcements = await Server.GetAnnouncementsForTenant(Profile.Id.ToString());
            foreach (var announcement in announcements)
                new AnnouncementButton(stpAnnouncements, announcement);
        }
    }
}
