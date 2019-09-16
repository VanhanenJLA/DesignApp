using DesignApp.Core;
using DesignApp.Navigation;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DesignApp.Core
{
    public abstract class BaseViewModel : BaseModel
    {

        protected readonly INavigationService NavigationService;
        protected App App => Application.Current as App;

        public BaseViewModel()
        {
            NavigationService = App.Container.Resolve<INavigationService>();
        }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.CompletedTask;
        }

    }

}
