using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Book_My_Table.Models
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }
       
        [Display(Name = "Restaurant Name")]
        public string RestaurantName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }
        public SelectList Names { get; set; }
        //public IEnumerable<string> Names { get; set; }
        //  public virtual Meal Meal { get; set; }
        // public virtual Booking Booking { get; set; }
        //public virtual TableDb TableDb { get; set; }

    }
}