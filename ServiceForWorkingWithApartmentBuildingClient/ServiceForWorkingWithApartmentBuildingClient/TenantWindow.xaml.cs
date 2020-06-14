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
        public TenantWindow()
        {
            InitializeComponent();
            CreateBtnGoToMeeting();
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
    }
}
