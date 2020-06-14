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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ServiceForWorkingWithApartmentBuildingClient
{
    /// <summary>
    /// Логика взаимодействия для FormFotMeetingCreate.xaml
    /// </summary>
    public partial class FormFotMeetingCreate : UserControl
    {
        string ManagementCompanyId { get; set; }
        string MeetingId { get; set; }

        public FormFotMeetingCreate(string managementCompanyId, List<BuildingReference> buildings)
        {
            InitializeComponent();

            ManagementCompanyId = managementCompanyId;

            foreach (var binding in buildings)
                cmbBuildingAddressesForCreateMeeting.Items.Add(new ComboBoxItem()
                {
                    Content = binding.Address,
                    Tag = binding.BuildingId.ToString()
                });
        }

        private async void btnCreateNewMeeting_Click(object sender, RoutedEventArgs e)
        {
            var cmi = (ComboBoxItem)cmbBuildingAddressesForCreateMeeting.SelectedItem;
            if (cmi == null)
                MessageBox.Show("Вы не выбрали дом");

            string buildingId = (string)cmi.Tag;

            var name = tbMeetingTitleForCreateMeeting.Text;

            var createMeetingBinding = new CreateMeetingBinding()
            {
                Name = name,
                OwnerId = ManagementCompanyId
            };

            MeetingId = await Server.OpenMeetingForBuilding(buildingId, createMeetingBinding);

            grMain.Children.Remove(spMain);

            var button = CreateBtnGoToMeeting();

            grMain.Children.Add(button);
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
