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
    /// Логика взаимодействия для RegistrationTenantWindow.xaml
    /// </summary>
    public partial class RegistrationTenantWindow : Window
    {
        public RegistrationTenantWindow()
        {
            InitializeComponent();
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

        private void btnSaveNewTenant_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
