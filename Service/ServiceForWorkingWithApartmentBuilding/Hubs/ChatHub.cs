using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ServiceForWorkingWithApartmentBuilding.Hubs
{
    public class ContosoChatHub : Hub
    {
        public Task JoinGroup(string groupName)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task SendMessage(string user, string groupName, string message)
        {
            await Clients.Group(groupName).SendAsync("ReceiveMessage", user, message);
        }

        public Task LeaveGroup(string groupName)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }
    }
}
