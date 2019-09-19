using DesignApp.Core;
using System.Windows.Input;
using Xamarin.Forms;

namespace DesignApp.Main
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {

        }

        public ICommand TakePhotoCommand => new Command(async ()
            => await Application.Current.MainPage.DisplayAlert(
                "TODO:", "Come up with a photo capturing use case.", "Dismiss"));
        public ICommand SettingsCommand => new Command(async ()
            => await Application.Current.MainPage.Navigation.PushModalAsync(
                new ContentPage { Content = new Label { Text = "TODO: SettingsPage" } }));
    }

}
