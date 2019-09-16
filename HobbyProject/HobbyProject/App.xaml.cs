using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HobbyProject
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ContentPage { Content = new Label { Text = "Wello Horld." } };
        }

        protected override void OnStart() { }

        protected override void OnSleep() { }

        protected override void OnResume() { }
    }
}
