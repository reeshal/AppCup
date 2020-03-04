using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using NoPoverty.Models;

namespace NoPoverty.Views 
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemTypeDonor.Home, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id,String UserType)
        {
            if (UserType == "Donor")
            {
                if (!MenuPages.ContainsKey(id))
                {
                    switch (id)
                    {
                        case (int)MenuItemTypeDonor.MyDonation:
                            //MenuPages.Add(id, new NavigationPage(new MyDonationDonor()));
                            break;
                        case (int)MenuItemTypeDonor.Profile:
                            MenuPages.Add(id, new NavigationPage(new MyProfile()));
                            break;
                    }
                }
            }
            else
            {
                if (!MenuPages.ContainsKey(id))
                {
                    switch (id)
                    {
                        case (int)MenuItemType.Calendar:
                            //MenuPages.Add(id, new NavigationPage(new RepCalendar()));
                            break;
                        case (int)MenuItemType.UpdateProfile:
                            //MenuPages.Add(id, new NavigationPage(new UpdateRepProfile()));
                            break;
                        

                    }
                }
            }
            var newPage = MenuPages[id];

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