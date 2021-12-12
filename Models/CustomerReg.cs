using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_My_Table.Models;

namespace Book_My_Table.Models
{
    public class CustomerReg : DbContext
    {
        public CustomerReg()
        {
        }

        public CustomerReg(DbContextOptions<CustomerReg> options) : base(options)
        {

        }
        public DbSet<Customer> CustomerRegistration { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<Meal> Meal { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<TableDb> TableDb { get; set; }
    }
    
}
