using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Book_My_Table.Models
{   
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        [Required(ErrorMessage = "Please Enter RestaurantId..")]
        [Display(Name = "RestaurantId")]
        public int RestaurantId { get; set; }
        [Required(ErrorMessage = "Please Enter CustomerId..")]
        [Display(Name = "CustomerId")]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime BookingTime { get; set; }
        public int Noofpeople { get; set; }
        public string ContactNo { get; set; }
        public int MealId { get; set; }
        public ICollection<Meal> Meals { get; set; }
        public ICollection<Customer> Customers { get; set; }
        
        //  public ICollection<Restaurant> Restaurants { get; set; }
    }
}
