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
            //Username.Text = Global.logger.Username;
            //Email.Text = Global.logger.Email;

            Username.Text = Global.currentRep.Username;
            Email.Text = Global.currentRep.InstitutionName;

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Meals, Title="Meals" },
                new HomeMenuItem {Id = MenuItemType.Calendar, Title="Calendar" },
                new HomeMenuItem {Id = MenuItemType.UpdateProfile, Title="Update Profile" },
            }; 

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id,"Institution");
            };
        }
        void OnLogout_Clicked(object sender, EventArgs e)
        {

            App.IsUserLoggedIn = false;
            Global.currentRep = null;
            Application.Current.MainPage = new NavigationPage(new LoginPage());

        }
    }
}