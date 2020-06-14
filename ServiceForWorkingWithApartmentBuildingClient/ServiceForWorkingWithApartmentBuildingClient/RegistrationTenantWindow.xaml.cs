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
            lbErrorMessage.Content = String.Empty;

            if (String.IsNullOrEmpty(tbName.Text))
            {
                lbErrorMessage.Content = "Введите имя!";
                return;
            }

            else if (String.IsNullOrEmpty(tbSurname.Text))
            {
                lbErrorMessage.Content = "Введите фамилию!";
                return;
            }

            else if (!(tbBirthDate.SelectedDate < DateTime.Today))
            {
                lbErrorMessage.Content = "Выберите дату рождения!";
                return;
            }

            else if (cmbAddress.SelectedItem == null)
            {
                lbErrorMessage.Content = "Укажите адрес!";
                return;
            }

            else if (String.IsNullOrEmpty(tbEntranceNumber.Text))
            {
                lbErrorMessage.Content = "Укажите подъезд!";
                return;
            }

            else if (FieldsValidation.NumberCheck(tbEntranceNumber.Text) == null)
            {
                lbErrorMessage.Content = "Укажите корректный подъезд!";
                return;
            }

            else if (String.IsNullOrEmpty(tbFlatNumber.Text))
            {
                lbErrorMessage.Content = "Укажите квартиру!";
                return;
            }

            else if (FieldsValidation.NumberCheck(tbFlatNumber.Text) == null)
            {
                lbErrorMessage.Content = "Укажите корректный подъезд!";
                return;
            }

            else if (FieldsValidation.PasswordCheck(psbNewPassword.Password) == null)
            {
                lbErrorMessage.Content = "Введите корректный пароль!\n" +
                    "Он должен содержать хотя бы одну цифру, однин символ нижнего (A-Z) и верхнего регистров (a-z).\n" +
                    "Минимальная длина равна 8.";
                return;
            }

            else if (FieldsValidation.PasswordCheck(psbRepeatPassword.Password) == null)
            {
                lbErrorMessage.Content = "Повторите корректный пароль!";
                return;
            }

            else if (psbNewPassword.Password != psbRepeatPassword.Password)
            {
                lbErrorMessage.Content = "Пароли не совпадают!";
                return;
            }

            var cmi = (ComboBoxItem)cmbAddress.SelectedItem;

            string hashPassword = SHA256Realization.ComputeSha256Hash(psbNewPassword.Password);
                       
            var NewTenant = new CreateTenantBinding()
            {
                Name = tbName.Text,
                Surname = tbSurname.Text,
                DateOfBirth = tbBirthDate.SelectedDate.Value,
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
                var tenantWindow = new TenantWindow();
                tenantWindow.Show(tbName.Text, tbSurname.Text, hashPassword);
                this.Close();
            }
        }
    }
}
