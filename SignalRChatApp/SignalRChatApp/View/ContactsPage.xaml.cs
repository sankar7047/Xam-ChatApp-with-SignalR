using System;
using System.Collections.Generic;
using SignalRChatApp.ViewModel;
using Xamarin.Forms;

namespace SignalRChatApp.View
{
    public partial class ContactsPage : ContentPage
    {
        public ContactsPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var vm = BindingContext as ContactsViewModel;
            vm.Init();
            await vm.ConnectAsync();
        }
    }
}
