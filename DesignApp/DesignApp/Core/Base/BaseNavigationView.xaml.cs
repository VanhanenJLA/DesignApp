
using Xamarin.Forms;

namespace DesignApp.Views
{
    public partial class BaseNavigationView : NavigationPage
    {
        public BaseNavigationView() : base()
        {
            InitializeComponent();
        }

        public BaseNavigationView(Page root) : base(root)
        {
            InitializeComponent();
        }
    }
}