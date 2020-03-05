using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoPoverty.Models;

namespace NoPoverty.Views.DonorView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageDonor : MasterDetailPage
    {
        Dictionary<int, NavigationPage> DonorMenuPages = new Dictionary<int, NavigationPage>();
        public MainPageDonor()
        {
            InitializeComponent();
            MasterBehavior = MasterBehavior.Popover;

            DonorMenuPages.Add((int)MenuItemTypeDonor.Home, (NavigationPage)Detail);
        }
        public async Task NavigateFromMenu(int id)
        {
            if (!DonorMenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemTypeDonor.MyDonation:
                        DonorMenuPages.Add(id, new NavigationPage(new MyDonation()));
                        break;

                    case (int)MenuItemTypeDonor.UpdateProfile:
                        //DonorMenuPages.Add(id, new NavigationPage(new UpdateDonorProfile()));
                        break;
                }
            }

            var newPage = DonorMenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}