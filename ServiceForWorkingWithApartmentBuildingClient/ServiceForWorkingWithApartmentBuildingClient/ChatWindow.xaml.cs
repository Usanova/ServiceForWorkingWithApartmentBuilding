using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;

namespace ServiceForWorkingWithApartmentBuildingClient
{
    public class MessageData
    {
        public string Message { get; set; }
        public string UserName { get; set; }
        public string dateTime { get; set; }
    }

    public partial class ChatWindow : Window
    {
        HubConnection hubConnection;

        // список всех полученных сообщений (только конкретным пользователем)
        public ObservableCollection<MessageData> Messages { get; }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        // идет ли отправка сообщений
        bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                if (isBusy != value)
                {
                    isBusy = value;
                    OnPropertyChanged("IsBusy");
                }
            }
        }
        // осуществлено ли подключение
        bool isConnected;
        public bool IsConnected
        {
            get => isConnected;
            set
            {
                if (isConnected != value)
                {
                    isConnected = value;
                    OnPropertyChanged("IsConnected");
                }
            }
        }

        delegate Task RetryConnect();
        RetryConnect retryConnect;
        public string userIdProp { get; private set; }
        public string chatIdProp { get; private set; }
        public string userNameProp { get; private set; }
        public bool isMngmtCompany { get; private set; }

        // ctor
        public ChatWindow(string userId, string chatId, string userName, bool isManagementCompany)
        {
            InitializeComponent();

            userIdProp = userId;
            chatIdProp = chatId;
            userNameProp = userName;
            isMngmtCompany = isManagementCompany;

            Messages = new ObservableCollection<MessageData>();

            IsConnected = false;    // по умолчанию не подключены
            IsBusy = false;         // отправка сообщения не идет

            // создание подключения
            hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri("http://localhost:53996/ChatHub"))
                .WithAutomaticReconnect()
                .Build();

            retryConnect += Connect;
            // повторяем попытку соединения с сервером
            if (hubConnection.State == HubConnectionState.Disconnected)
                retryConnect();

            // прослушка респонза от сервера
            hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                DateTime receiveTime = DateTime.Now;
                Messages.Add(new MessageData()
                {
                    Message = message,
                    UserName = user,
                    dateTime = $"{receiveTime.Day}/{receiveTime.Month}/{receiveTime.Year} " +
                    $"{receiveTime.Hour}:{receiveTime.Minute}"
                });

                if (userName.CompareTo(user) == 0)
                    lvMessages.Items.Add(new OwnerChatItemContainer(Messages.Last()));
                else
                    lvMessages.Items.Add(new ChatItemContainer(Messages.Last()));
            });


            hubConnection.Closed += async (error) =>
            {
                MessageBox.Show("Подключение закрыто...");
                IsConnected = false;
                await Task.Delay(5000);
                await Connect();
            };
        }

        // Вступление в группу
        async Task JoinGroup(string groupName)
        {
            try
            {
                IsBusy = true;
                await hubConnection.InvokeAsync("JoinGroup", groupName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        // подключение к чату
        public async Task Connect()
        {
            if (IsConnected)
                return;
            try
            {
                await hubConnection.StartAsync();
                MessageBox.Show("Вы вошли в чат...");

                IsConnected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения: {ex.Message}");
            }
        }

        // Отключение от чата
        public async Task Disconnect()
        {
            if (!IsConnected)
                return;

            await hubConnection.StopAsync();
            IsConnected = false;
            MessageBox.Show("Вы покинули чат...");
        }

        // Исключение из группы
        async Task LeaveGroup(string groupName)
        {
            try
            {
                IsBusy = true;
                await hubConnection.InvokeAsync("LeaveGroup", groupName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        // Отправка сообщения
        async Task SendMessage(string userName, string message)
        {
            try
            {
                IsBusy = true;
                await hubConnection.InvokeAsync("SendMessage", userName, "Group", message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void btnSendMessage_Click(object sender, RoutedEventArgs e)
        {
            await SendMessage(userNameProp, tbxMessage.Text);
        }
    }
}
