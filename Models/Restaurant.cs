using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_My_Table.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        //  public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime OpeningTime { get; set; }
        public DateTime ClosingTime { get; set; }
        public virtual Meal Meal { get; set; }
        public virtual Booking Booking { get; set; }
        public virtual TableDb TableDb { get; set; }

    }
}