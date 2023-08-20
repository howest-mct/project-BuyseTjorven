using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace eindopdrachtdesign
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //MainPage = new NavigationPage(new MainPage());
            //if (Connectivity.NetworkAccess != NetworkAccess.None)
            //{
                MainPage = new NavigationPage(new MainPage());
            //}
            //else
            //{
                //MainPage = new Views.NoNetworkPage();
            //}
        }

        protected override void OnStart()
        {
            //Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            MessagingCenter.Send(this, "ConnectionEvent", e.NetworkAccess == NetworkAccess.Internet);
            if (Connectivity.NetworkAccess == NetworkAccess.None)
            {
                Debug.WriteLine("no internet");
                MainPage = new Views.NoNetworkPage();
            }
            else if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                Debug.WriteLine("internet back");
                MainPage = new NavigationPage(new MainPage());
            }

        }

    }
}
