using System;
using System.Collections.Generic;
using System.Text;

namespace NoPoverty.Models
{
    public class Books
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Donator { get; set; }
        public string Receiver { get; set; }
        public string PickupTime { get; set; }
        public string Quantity { get; set; }
        public string ImageUrl { get; set; }
    }
}
