
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DesignApp.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void UsernameEntry_Completed(object sender, EventArgs e)
        {
            passwordEntry.Focus();
        }

    }
}