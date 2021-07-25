using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using SignalRChatApp.Models;
using Xamarin.Essentials;

namespace SignalRChatApp.Service
{
    public sealed class ChatService
    {
        private static ChatService _instance = new ChatService();

        public static ChatService Instance
        {
            get => _instance ?? new ChatService();
        }

        HubConnection hubConnection;

        public event EventHandler<Message> OnReceivedMessage;

        bool IsConnected { get; set; }

        private static string BackendUrl = //"https://signalrchatxam.azurewebsites.net";
                                           //DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:5001" : "https://localhost:5001";
            "https://localhost:5001";

        public string ConnectionId
        {
            get => hubConnection?.ConnectionId;
        } 

        public void Init()
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl($"{BackendUrl}/hubs/chat")
                .WithAutomaticReconnect()
                .Build();

            hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                OnReceivedMessage?.Invoke(this, new Message(message, user));
            });
        }

        public async Task ConnectAsync()
        {
            try
            {
                if (IsConnected)
                    return;

                await hubConnection.StartAsync();
                IsConnected = true;
            }
            catch (Exception ex)
            {

            }
            
        }

        public async Task SendPrivateMessageAsync(string toUser, Message message)
        {
            if (!IsConnected)
                throw new InvalidOperationException("Not connected");

            await hubConnection.InvokeAsync("SendPrivateMessage", ConnectionId, toUser, message);
        }
    }
}
