using Microsoft.AspNetCore.SignalR;

namespace RealTimeChatApp.Models
{
    public class MyHub : Hub
    { 
        private static HashSet<string> ConnectedUsers = new HashSet<string>();
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage",user, message);
        }

        public override Task OnConnectedAsync()
        {
            ConnectedUsers.Add(Context.ConnectionId);
            Clients.All.SendAsync("UpdateUserList", ConnectedUsers);
            return base.OnConnectedAsync(); 
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            ConnectedUsers.Remove(Context.ConnectionId);
            Clients.All.SendAsync("UpdateUserList", ConnectedUsers);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
