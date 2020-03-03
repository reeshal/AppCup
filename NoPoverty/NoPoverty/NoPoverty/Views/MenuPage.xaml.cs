using NoPoverty.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoPoverty.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();
            Username.Text = Global.logger.Username;
            Email.Text = Global.logger.Email;

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Home, Title="Home" },
                new HomeMenuItem {Id = MenuItemType.MyProfile, Title="My Profile" },
                new HomeMenuItem {Id = MenuItemType.MyProductsDonated, Title="Products Donated" },
                new HomeMenuItem {Id = MenuItemType.MyProductsDonated, Title="Products Picked" },
                new HomeMenuItem {Id = MenuItemType.MyProductsDonated, Title="About" }
            }; 

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
        void OnLogout_Clicked(object sender, EventArgs e)
        {

            App.IsUserLoggedIn = false;
            Global.logger = null;
            Application.Current.MainPage = new NavigationPage(new LoginPage());

        }
    }
}