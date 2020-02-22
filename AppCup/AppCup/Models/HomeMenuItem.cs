using System;
using System.Collections.Generic;
using System.Text;

namespace AppCup.Models
{
    public enum MenuItemType
    {
        Nopoverty,
        Home,
        My_listings,
        Profile,
        Favourites,
        Account,
        Notification,
        About

    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
