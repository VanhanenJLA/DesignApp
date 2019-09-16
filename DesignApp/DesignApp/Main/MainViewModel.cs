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
            => await Application.Current.MainPage.DisplayAlert("TODO:", "Implement imaging feature.", "Dismiss"));
    }

}
