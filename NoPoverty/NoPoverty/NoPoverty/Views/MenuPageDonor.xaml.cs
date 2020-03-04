using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoPoverty.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoPoverty.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    //[DesignTimeVisible(false)]
    public partial class MenuPageDonor : ContentPage
    {
        MainPage RootPageDonor { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItemDonor> menuItemsDonor;
        public MenuPageDonor()
        {
            InitializeComponent();
            //Username.Text = Global.logger.Username;
            //Email.Text = Global.logger.Email;

            Username.Text = Global.currentRep.Username;
            Email.Text = Global.currentRep.InstitutionName;

            menuItemsDonor = new List<HomeMenuItemDonor>
            {
                new HomeMenuItemDonor {Id = MenuItemTypeDonor.Home, Title="List of institutions" },
                new HomeMenuItemDonor {Id = MenuItemTypeDonor.MyDonation, Title="My Donations" },
                new HomeMenuItemDonor {Id = MenuItemTypeDonor.UpdateProfile, Title="Update Profile" },
            };

            ListViewMenuDonor.ItemsSource = menuItemsDonor;

            ListViewMenuDonor.SelectedItem = menuItemsDonor[0];
            ListViewMenuDonor.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItemDonor)e.SelectedItem).Id;
                await RootPageDonor.NavigateFromMenu(id,"Donor");
            };
        }
        void OnLogoutDonor_Clicked(object sender, EventArgs e)
        {

            App.IsUserLoggedIn = false;
            Global.currentRep = null;
            Application.Current.MainPage = new NavigationPage(new LoginPage());

        }
    }
}