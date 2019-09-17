using DesignApp.Core;
using DesignApp.Main;
using DesignApp.Models;
using DesignApp.PlatformDependencies;
using System;
using System.Threading;
using System.Threading.Tasks;
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
        public LoginViewModel() { }

        public ICommand LoginCommand => new Command(async () => await LoginAsync());

        private async Task LoginAsync()
        {
            try
            {
                await Task.Run(() => LoadingDialog.StartLoading());
                await Task.Run(() => Thread.Sleep(1500));
                await NavigationService.NavigateToAsync<MainViewModel>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                await Task.Run(() => LoadingDialog.StopLoading());
            }

        }

    }

}