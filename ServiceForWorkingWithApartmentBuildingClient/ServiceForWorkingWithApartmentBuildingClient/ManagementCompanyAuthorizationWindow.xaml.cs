using ServiceForWorkingWithApartmentBuildingClient.Models;
using System;
using System.Collections.Generic;
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
using ServiceForWorkingWithApartmentBuildingClient.Models;

namespace ServiceForWorkingWithApartmentBuildingClient
{
    /// <summary>
    /// Логика взаимодействия для ManagementCompanyAuthorizationWindow.xaml
    /// </summary>
    public partial class ManagementCompanyAuthorizationWindow : Window
    {
        public ManagementCompanyAuthorizationWindow()
        {
            InitializeComponent();
        }

        private void psbPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)  btnAuthentification.Focus();
        }

        private void tbName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) psbPass.Focus();
        }

        private void tbRegistrationName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) tbRegistrationInfo.Focus();
        }

        private void tbRegistrationInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) psbRegistrationPass.Focus();
        }

        private void psbRegistrationPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) btnRegister.Focus();
        }

        private async void btnAuthentification_Click(object sender, RoutedEventArgs e)
        {
            string hashPassword = SHA256Realization.ComputeSha256Hash(psbPass.Password);
            var binding = new LoginManagementCompanyBinding()
            {
                NameCompany = tbName.Text,
                Password = hashPassword
            };

            bool isnAuthentificait = await Server.LoginManagementCompany(binding);

            if(!isnAuthentificait)
            {
                MessageBox.Show("Неверное имя пользователя или пароль!");
                return;
            }
            else
            {
                this.Close();
            }
        }

        private void btnDownloadAvatar_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void btnRegister_Click(object sender, RoutedEventArgs e)
        {

            string hashPassword = SHA256Realization.ComputeSha256Hash(psbRegistrationPass.Password);

            var binding = new CreateManagementCompanyBinding()
            {
                Name = tbRegistrationName.Text,
                Password = hashPassword,
                Info = tbRegistrationInfo.Text
            };

            bool isRegistrated = await Server.RegisterManagementCompany(binding);

            if (!isRegistrated)
            {
                MessageBox.Show("Компания с таким именем уже зарегистрирована!");
                return;
            }
            else
            {
                this.Close();
            }
        }
    }
}
