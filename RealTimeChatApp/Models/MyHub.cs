﻿using Microsoft.AspNetCore.SignalR;

namespace RealTimeChatApp.Models
{
    public class MyHub : Hub
    { 
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage",user, message);
        }
    }
}
