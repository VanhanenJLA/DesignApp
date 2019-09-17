using DesignApp.Core;
using DesignApp.Login;
using DesignApp.Main;
using System;
using System.Globalization;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DesignApp.Navigation
{
    public class NavigationService : INavigationService
    {
        public BaseViewModel PreviousPageViewModel
        {
            get
            {
                var mainPage = Application.Current.MainPage as BaseNavigationView;
                var viewModel = mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2].BindingContext;
                return viewModel as BaseViewModel;
            }
        }

        public Task InitializeAsync()
        {
            // TODO: Implement authentication.
            bool LoggedIn = false;
            if (!LoggedIn)
            {
                return NavigateToAsync<LoginViewModel>();
            }
            return NavigateToAsync<MainViewModel>();
        }

        public async Task ShowModalAsync<TViewModel>(object parameter = null) where TViewModel : BaseViewModel
        {
            var page = CreatePage(typeof(TViewModel), parameter);
            var context = page.BindingContext as BaseViewModel;
            await context.InitializeAsync(parameter);
            await Application.Current.MainPage.Navigation.PushModalAsync(page);
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel
        {
            return InternalNavigateToAsync(typeof(TViewModel), null);
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel
        {
            return InternalNavigateToAsync(typeof(TViewModel), parameter);
        }

        public Task RemoveLastFromBackStackAsync()
        {
            var mainPage = Application.Current.MainPage as BaseNavigationView;

            if (mainPage != null)
            {
                mainPage.Navigation.RemovePage(
                    mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2]);
            }

            return Task.CompletedTask;

        }

        public Task RemoveBackStackAsync()
        {
            var mainPage = Application.Current.MainPage as BaseNavigationView;

            if (mainPage != null)
            {
                for (int i = 0; i < mainPage.Navigation.NavigationStack.Count - 1; i++)
                {
                    var page = mainPage.Navigation.NavigationStack[i];
                    mainPage.Navigation.RemovePage(page);
                }
            }

            return Task.CompletedTask;

        }

        private async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            if (viewModelType == null)
            {
                throw new Exception("View not yet supported.");
            }

            Page page = CreatePage(viewModelType, parameter);

            if (page is LoginView)
            {
                Application.Current.MainPage = new BaseNavigationView(page);
            }
            else
            {
                if (Application.Current.MainPage is BaseNavigationView navigationPage)
                {
                    await navigationPage.PushAsync(page);
                }
                else
                {
                    Application.Current.MainPage = new BaseNavigationView(page);
                }
            }

            await (page.BindingContext as BaseViewModel).InitializeAsync(parameter);
        }


        private Page CreatePage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null)
                throw new Exception($"Cannot locate page type for {viewModelType}");

            Page page = Activator.CreateInstance(pageType) as Page;
            return page;

            Type GetPageTypeForViewModel(Type _viewModelType)
            {
                var viewName = _viewModelType.FullName.Replace("Model", string.Empty);
                var viewModelAssemblyName = _viewModelType.GetTypeInfo().Assembly.FullName;
                var viewAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);
                var viewType = Type.GetType(viewAssemblyName);
                return viewType;
            }

        }

    }
}
