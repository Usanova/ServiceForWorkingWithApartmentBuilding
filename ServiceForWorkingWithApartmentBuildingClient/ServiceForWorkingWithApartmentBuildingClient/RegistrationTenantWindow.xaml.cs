using ServiceForWorkingWithApartmentBuildingClient.Models;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
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

namespace ServiceForWorkingWithApartmentBuildingClient
{
    /// <summary>
    /// Логика взаимодействия для RegistrationTenantWindow.xaml
    /// </summary>
    public partial class RegistrationTenantWindow : Window
    {
        public RegistrationTenantWindow()
        {
            InitializeComponent();
        }

        public async void ShowRegistrationTenantWindow()
        {
            await LoadAddress();
            this.Show();
        }

        private async Task LoadAddress()
        {
            var addresses = await Server.GetAllAddresses();

            foreach (var address in addresses)
                cmbAddress.Items.Add(new ComboBoxItem { Content = address });
        }

        private void tbName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                tbSurname.Focus();
        }

        private void PsbNewPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                btnSaveNewTenant.Focus();
            //psbRepeatPassword.Focus();
        }

        private void PsbRepeatPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                btnSaveNewTenant.Focus();
        }

        private void tbSurname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                tbEntranceNumber.Focus();
        }

        private void tbEntranceNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                tbFlatNumber.Focus();
        }

        private void tbFlatNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                psbNewPassword.Focus();
        }

        private void btnDownloadAvatar_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void btnSaveNewTenant_Click(object sender, RoutedEventArgs e)
        {
            var cmi = (ComboBoxItem)cmbAddress.SelectedItem;
            if (cmi.Content == null)
                return;

            string hashPassword = SHA256Realization.ComputeSha256Hash(psbNewPassword.Password);

            var NewTenant = new CreateTenantBinding()
            {
                Name = tbName.Text,
                Surname = tbSurname.Text,
                DateOfBirth = tbBirthDate.DisplayDate,
                Address = cmi.Content.ToString(),
                EntranceNumber = int.Parse(tbEntranceNumber.Text),
                FlatNumber = int.Parse(tbFlatNumber.Text),
                Password = hashPassword
            };

            bool isRegistrated = await Server.Register(NewTenant);

            if (!isRegistrated)
            {
                MessageBox.Show("Жилец с такими именем и паролем уже зарегистрирован!");
                return;
            }
            else
            {
                this.Close();
            }
        }
    }
}
