using Xamarin.Forms;

namespace DesignApp.PlatformDependencies
{

    public interface ILoadingDialog
    {
        void StartLoading();
        void StopLoading();
    }

    public class LoadingDialog
    {

        public static void StartLoading()
        {
            Device.BeginInvokeOnMainThread(() => DependencyService.Get<ILoadingDialog>().StartLoading());
        }

        public static void StopLoading()
        {
            Device.BeginInvokeOnMainThread(() => DependencyService.Get<ILoadingDialog>().StopLoading());
        }

    }

}
