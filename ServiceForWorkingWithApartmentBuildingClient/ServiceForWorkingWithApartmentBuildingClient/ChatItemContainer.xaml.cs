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
    /// Логика взаимодействия для ChatItemContainer.xaml
    /// </summary>
    public partial class ChatItemContainer : UserControl
    {
        public ChatItemContainer(MessageData messageData)
        {
            InitializeComponent();

            lblMsgOwner.Content = messageData.UserName;
            lblReceiveDate.Content = messageData.dateTime;
            tbxMsgContent.Text = messageData.Message;
        }
    }
}
