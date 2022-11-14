using System;
using System.Collections.Generic;

namespace DeliveryService_WebAPI.Models
{
    public partial class Good
    {
        public Good()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Food { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double Price { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
