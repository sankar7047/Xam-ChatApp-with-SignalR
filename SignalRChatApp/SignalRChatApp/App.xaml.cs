using System;
using SignalRChatApp.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SignalRChatApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ContactsPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
