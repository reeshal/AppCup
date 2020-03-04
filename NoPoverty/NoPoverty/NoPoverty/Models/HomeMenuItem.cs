using System;
using System.Collections.Generic;
using System.Text;

namespace NoPoverty.Models
{
    public enum MenuItemType
    {
        Meals,
        Calendar,
        UpdateProfile

    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
