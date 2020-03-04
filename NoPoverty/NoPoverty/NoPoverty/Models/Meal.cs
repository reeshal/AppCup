using System;
using System.Collections.Generic;
using System.Text;

namespace NoPoverty.Models
{
    public class Meal
    {
        public Guid MealId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Donator { get; set; }
        public string Calorie { get; set; }
        public string Healthiness { get; set; }
        public string Quantity { get; set; }
        public string ImageUrl { get; set; }
    }
}
