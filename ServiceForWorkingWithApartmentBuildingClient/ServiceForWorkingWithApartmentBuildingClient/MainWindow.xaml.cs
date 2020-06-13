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
    }
}
