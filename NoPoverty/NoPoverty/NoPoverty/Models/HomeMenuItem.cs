using System;
using System.Collections.Generic;
using System.Text;

namespace NoPoverty.Models
{
    public enum MenuItemType
    {
        Home,
        MyProfile,
        MyProductsDonated,
        MyProductsReceived,
        Browse
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
