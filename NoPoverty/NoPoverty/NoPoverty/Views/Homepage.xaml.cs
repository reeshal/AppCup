using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace NoPoverty.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class Homepage : Xamarin.Forms.TabbedPage
    {
        
        public Homepage()
        {
            InitializeComponent();
            CurrentPage = Children[1]; //initialising the 2nd tab as homepage
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }
        private void NavigationPage_SizeChanged(object sender, EventArgs e)
        {
        }

        private void NavigationPage_LayoutChanged(object sender, EventArgs e)
        {
        }
    }
}