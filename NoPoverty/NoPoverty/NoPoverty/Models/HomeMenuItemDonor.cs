using System;
using System.Collections.Generic;
using System.Text;

namespace NoPoverty.Models
{
    public enum MenuItemTypeDonor
    {
        Home,
        MyDonation,
        UpdateProfile

    }
    public class HomeMenuItemDonor
    {
        public MenuItemTypeDonor Id { get; set; }

        public string Title { get; set; }
    }
}
