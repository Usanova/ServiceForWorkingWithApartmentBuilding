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
         
        private void psbRegistrationPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) btnRegister.Focus();
        }

        private void psbRegistrationRepeatPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) btnRegister.Focus();
        }

        private void tbRegistrationInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) psbRegistrationPass.Focus();
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
                var managementCompanyWindow = new ManagementCompanyWindow();
                managementCompanyWindow.Show(tbName.Text);
                this.Close();
            }
        }

        private void btnDownloadAvatar_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            lbErrorMessage.Content = String.Empty;

            if (String.IsNullOrEmpty(tbRegistrationName.Text))
            {
                lbErrorMessage.Content = "Введите имя!";
                return;
            }
               
            else if (FieldsValidation.PasswordCheck(psbRegistrationPass.Password) == null)
            {
                lbErrorMessage.Content = "Введите корректный пароль!\n" +
                    "Он должен содержать хотя бы одну цифру, однин символ нижнего (A-Z) и верхнего регистров (a-z).\n" +
                    "Минимальная длина равна 8.";
                return;
            }

            else if (FieldsValidation.PasswordCheck(psbRegistrationRepeatPass.Password) == null)
            {
                lbErrorMessage.Content = "Повторите корректный пароль!";
                return;
            }

            else if (psbRegistrationPass.Password != psbRegistrationRepeatPass.Password)
            {
                lbErrorMessage.Content = "Пароли не совпадают!";
                return;
            }

            if (String.IsNullOrEmpty(tbRegistrationInfo.Text))
            {
                lbErrorMessage.Content = "Введите информацию!";
                return;
            }

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
                var managementCompanyWindow = new ManagementCompanyWindow();
                managementCompanyWindow.Show(tbRegistrationName.Text);
                this.Close();
            }
        }
    }
}
