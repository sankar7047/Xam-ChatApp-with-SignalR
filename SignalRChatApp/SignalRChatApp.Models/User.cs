using System;
using System.Collections.Generic;

namespace SignalRChatApp.Models
{
    public class User
    {
        public string UserId { get; set; }
        public IList<Message> Messages { get; set; }
        public IList<User> Contacts { get; set; }
    }
}
