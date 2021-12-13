using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_My_Table.Models
{
    public class Meal
    {
        public int MealId { get; set; }
        public string Name { get; set; }
        public DateTime Timing { get; set; }
        //public ICollection<Restaurant> Restaurants { get; set; }
        public virtual Booking Booking { get; set; }

    }
}