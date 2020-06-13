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
    }
}
