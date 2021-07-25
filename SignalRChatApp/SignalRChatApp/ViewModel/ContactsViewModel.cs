using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using SignalRChatApp.Models;
using SignalRChatApp.Service;
using Xamarin.Forms;

namespace SignalRChatApp.ViewModel
{
    public class ContactsViewModel : BaseViewModel
    {
        

        public IList<User> Users { get; set; }

        public ICommand ChatCommand
        {
            get
            {
                return new Command((user)=>
                {

                });
            }
        }

        public void Init()
        {
            ChatService.Instance.Init();

            ChatService.Instance.OnReceivedMessage += ChatService_OnReceivedMessage;
        }

        public async Task ConnectAsync()
        {
            await ChatService.Instance.ConnectAsync();
        }

        private void ChatService_OnReceivedMessage(object sender, Message e)
        {
            
        }
    }
    
}
