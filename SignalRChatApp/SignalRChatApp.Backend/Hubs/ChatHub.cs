using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalRChatApp.Models;

namespace SignalRChatApp.Backend.Hubs
{
    public class ChatHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendPrivateMessage(string user, string toUser, Message message)
        {
            await Clients.User(toUser).SendAsync("SendMessage", user, message);
        }
    }
}
