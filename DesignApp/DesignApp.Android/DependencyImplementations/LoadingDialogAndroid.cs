
using Android.App;
using Android.Graphics.Drawables;
using Android.Views;
using DesignApp.Droid.DependencyImplementations;
using DesignApp.PlatformDependencies;
using Xamarin.Forms;

[assembly: Dependency(typeof(LoadingDialogAndroid))]
namespace DesignApp.Droid.DependencyImplementations
{

    public class LoadingDialogAndroid : Activity, ILoadingDialog
    {
        private Activity CurrentActivity = MainActivity.Instance;
        private Dialog dialog;

        public void StartLoading()
        {
            CreateDialog();
            CreateAndSetWindowToDialog();
            CreateAndSetProgressBarToDialog();
            dialog.Show();

            void CreateDialog()
            {
                dialog = new Dialog(CurrentActivity);
                dialog.RequestWindowFeature((int)WindowFeatures.NoTitle);
                dialog.SetCancelable(true); // Set to true until a time out and canExecute is implemented.
                dialog.SetCanceledOnTouchOutside(false);
            }
            void CreateAndSetWindowToDialog()
            {
                var window = dialog.Window;
                window.SetLayout(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
                window.SetBackgroundDrawable(new ColorDrawable(Android.Graphics.Color.Transparent));
            }
            void CreateAndSetProgressBarToDialog()
            {
                var progress = new Android.Widget.ProgressBar(CurrentActivity)
                {
                    LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent),
                    Indeterminate = true
                };

                dialog.AddContentView(progress, progress.LayoutParameters);
            }

        }

        public void StopLoading()
        {
            dialog.Dismiss();
        }

    }

}