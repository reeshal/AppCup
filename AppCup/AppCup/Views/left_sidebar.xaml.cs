using AppCup.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCup.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class left_sidebar : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public left_sidebar()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                
                new HomeMenuItem {Id = MenuItemType.Home, Title="Home" },
                new HomeMenuItem {Id = MenuItemType.My_listings, Title="My listing" },
                new HomeMenuItem {Id = MenuItemType.Profile, Title="Profile" },
                new HomeMenuItem {Id = MenuItemType.Favourites, Title="Favourites" },
                new HomeMenuItem {Id = MenuItemType.Account, Title="Account" },
                new HomeMenuItem {Id = MenuItemType.Notification, Title="Notification"},
                new HomeMenuItem {Id = MenuItemType.About, Title="About"}
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
    }
}