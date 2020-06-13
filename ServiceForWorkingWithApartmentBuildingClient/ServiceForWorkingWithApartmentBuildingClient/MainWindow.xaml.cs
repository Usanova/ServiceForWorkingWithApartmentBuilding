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
using System.Net.Http;
using ServiceForWorkingWithApartmentBuildingClient.Models;

namespace ServiceForWorkingWithApartmentBuildingClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

          
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await 
                client.GetAsync("https://localhost:44303/announcement/tenants/611b8fa3-8906-43a9-af7c-d047f34a51ba");
        }

        private void Tblogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                psbPass.Focus();
        }

        private void PsbPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnAuthentification.Focus();
            }
        }

        private void tbOpenManagementCompanyWindow_MouseEnter(object sender, MouseEventArgs e)
        {
            tbOpenManagementCompanyWindow.Foreground = Brushes.Thistle;
        }

        private void tbOpenManagementCompanyWindow_MouseLeave(object sender, MouseEventArgs e)
        {
            tbOpenManagementCompanyWindow.Foreground = (Brush)new BrushConverter().ConvertFrom("#F4FFEBFF");
        }

        private void tbOpenManagementCompanyWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ManagementCompanyAuthorizationWindow managementCompanyAuthorizationWindow = new ManagementCompanyAuthorizationWindow();
            managementCompanyAuthorizationWindow.Owner = this;
            managementCompanyAuthorizationWindow.ShowDialog();
        }

        private void lblOpenRegistration_MouseEnter(object sender, MouseEventArgs e)
        {
            lblOpenRegistration.Foreground = Brushes.AliceBlue;
        }

        private void lblOpenRegistration_MouseLeave(object sender, MouseEventArgs e)
        {
            lblOpenRegistration.Foreground = Brushes.AntiqueWhite;
        }

        private void lblOpenRegistration_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RegistrationTenantWindow registration = new RegistrationTenantWindow();
            registration.Owner = this;
            //this.Hide();
            registration.ShowRegistrationTenantWindow();
        }

        private async void btnAuthentification_Click(object sender, RoutedEventArgs e)
        {
            string hashPassword = SHA256Realization.ComputeSha256Hash(psbPass.Password);
            var binding = new LoginTenatBinding()
            {
                Name = tblogin.Text,
                Surname = tbSurname.Text,
                Password = hashPassword
            };

            bool isnAuthentificait = await Server.Login(binding);

            if (!isnAuthentificait)
            {
                MessageBox.Show("Неверное имя-фамилия пользователя или пароль!");
                return;
            }
            else
            {
                this.Close();
            }
        }
    }
}
