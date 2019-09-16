using DesignApp.Container;
using DesignApp.Navigation;
using TinyIoC;
using Xamarin.Forms;

namespace DesignApp
{
    public partial class App : Application
    {
        internal static readonly TinyIoCContainer Container = DIContainer.Instance;

        public App()
        {
            InitializeComponent();
            Container.Resolve<INavigationService>().InitializeAsync();
        }

        protected override void OnStart() { }

        protected override void OnSleep() { }

        protected override void OnResume() { }
    }
}
