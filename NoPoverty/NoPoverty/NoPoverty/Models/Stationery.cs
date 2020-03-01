using System;
using System.Collections.Generic;
using System.Text;

namespace NoPoverty.Models
{
    public class Stationery
    {
        public Guid StationeryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Donator { get; set; }
        public string Receiver { get; set; }
        public string PickupTime { get; set; }
        public string Quantity { get; set; }
        public string ImageUrl { get; set; }
    }
}
