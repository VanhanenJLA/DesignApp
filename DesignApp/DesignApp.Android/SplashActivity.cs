
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;

namespace DesignApp.Droid
{
    [Activity(Label = "DesignApp",
     Icon = "@mipmap/icon",
     Theme = "@style/Theme.Splash",
     NoHistory = true,
     MainLauncher = true,
     ScreenOrientation = ScreenOrientation.Portrait)]
    class SplashActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            InvokeMainActivity();
        }

        private void InvokeMainActivity()
        {
            StartActivity(new Intent(this, typeof(MainActivity)));
        }
    }
}