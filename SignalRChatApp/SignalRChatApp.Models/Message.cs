using System;
namespace SignalRChatApp.Models
{
    public class Message
    {
        public Message(string userId, string textMessage, DateTime when = default)
        {
            UserId = userId;
            TextMessage = textMessage;
            When = when == default ? DateTime.Now : when;
        }

        public string UserId { get; set; }
        public string TextMessage { get; set; }
        public DateTime When { get; set; }
    }
}
