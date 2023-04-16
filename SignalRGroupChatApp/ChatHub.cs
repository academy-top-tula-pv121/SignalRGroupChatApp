using Microsoft.AspNetCore.SignalR;

namespace SignalRGroupChatApp
{
    public class ChatHub : Hub
    {
        public async Task Enter(string userName, string userGroup)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userGroup);
            await Clients.All.SendAsync("Notify", $"{userName} input chat group of {userGroup}");
        }

        public async Task Send(string userName, string groupName, string message)
        {
            await Clients.Group(groupName).SendAsync("Receive", userName, message);
        }
    }
}
