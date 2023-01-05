using System;
using System.Collections.Generic;

namespace DeliveryService_WebAPI.Models
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            OrderHistories = new HashSet<OrderHistory>();
        }

        public int Id { get; set; }
        public string OrderStatus1 { get; set; } = null!;

        public virtual ICollection<OrderHistory> OrderHistories { get; set; }
    }
}
