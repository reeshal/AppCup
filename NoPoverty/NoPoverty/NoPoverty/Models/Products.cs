using System;
using System.Collections.Generic;
using System.Text;

namespace NoPoverty.Models
{
    class Products
    {
        public Guid ItemId { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public String Category { get; set; }
        public String Donator { get; set; }
        public String Receiver { get; set; }
        public String PickupTime { get; set; }

        public Products(string title, string description, string category, string donator, string pickupTime)
        {
            
            Title = title;
            Description = description;
            Category = category;
            Donator = donator;
            Receiver = "";
            PickupTime = pickupTime;
        }
    }
}
