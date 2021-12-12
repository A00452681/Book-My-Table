using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_My_Table.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int customerId { get; set; }
        public string Amount { get; set; }
        public  DateTime PaymentDate { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}