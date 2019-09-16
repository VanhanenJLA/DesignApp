using DesignApp.Login;
using DesignApp.Main;
using DesignApp.Navigation;
using TinyIoC;

namespace DesignApp.Container
{

    static class DIContainer
    {
        public static TinyIoCContainer Instance { get; private set; }

        static DIContainer()
        {
            Instance = new TinyIoCContainer();

            Instance.Register<LoginViewModel>();
            Instance.Register<MainViewModel>();

            Instance.Register<INavigationService, NavigationService>();

        }

    }

}
