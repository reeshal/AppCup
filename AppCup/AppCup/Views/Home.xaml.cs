using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class Home : Xamarin.Forms.TabbedPage
    {
        public Home()
        {
            InitializeComponent();
            
        }

        private void NavigationPage_SizeChanged(object sender, EventArgs e)
        {
            
           
        }

        

        private void NavigationPage_LayoutChanged(object sender, EventArgs e)
        {

        }
    }
}