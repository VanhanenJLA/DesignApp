using DesignApp.Core;
using DesignApp.Main;
using DesignApp.Models;
using System.Windows.Input;
using Xamarin.Forms;

namespace DesignApp.Login
{

    public class LoginViewModel : BaseViewModel
    {
        private LoginCredentials LoginCredentials { get; set; }

        private string username;
        public string Username
        {
            get => username;
            set
            {
                username = value;
                RaisePropertyChanged(() => Username);
            }
        }

        private string password;
        public string Password
        {
            get => password;
            set
            {
                password = value;
                RaisePropertyChanged(() => Password);
            }
        }

        // TODO: Add LoginService.
        // Inject LoginService
        public LoginViewModel()
        {

        }

        public ICommand LoginCommand => new Command(async () => await NavigationService.NavigateToAsync<MainViewModel>());

    }

}