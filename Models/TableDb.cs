using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_My_Table.Models
{
    public class TableDb
    {
        public int TableDbId { get; set; }
        public int RestaurantId { get; set; }
        public ICollection<Restaurant> Restaurants { get; set; }
    }
}