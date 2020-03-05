using NoPoverty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoPoverty.Views.DonorView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPageDonor : ContentPage
    {
        MainPage RootPageDonor { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItemDonor> menuItemsDonor;
        public MenuPageDonor()
        {
            InitializeComponent();
            Username.Text = Global.currentDonor.Username;
            Email.Text = Global.currentDonor.Email;

            menuItemsDonor = new List<HomeMenuItemDonor>
            {
                new HomeMenuItemDonor {Id = MenuItemTypeDonor.Home, Title="List of institutions" },
                new HomeMenuItemDonor {Id = MenuItemTypeDonor.MyDonation, Title="Click on picture to see my Donations" },
                new HomeMenuItemDonor {Id = MenuItemTypeDonor.UpdateProfile, Title="Update Profile" },
            };

            ListViewMenuDonor.ItemsSource = menuItemsDonor;

            ListViewMenuDonor.SelectedItem = menuItemsDonor[0];
            ListViewMenuDonor.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItemDonor)e.SelectedItem).Id;
                await RootPageDonor.NavigateFromMenu(id);
            };
        }
        void OnLogoutDonor_Clicked(object sender, EventArgs e)
        {

            App.IsUserLoggedIn = false;
            Global.currentDonor = null;
            Application.Current.MainPage = new NavigationPage(new LoginPage());

        }

        async void viewDonations(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MyDonation()));
        }
    }
}