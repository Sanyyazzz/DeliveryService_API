using System;
using System.Collections.Generic;

namespace DeliveryService_WebAPI.Models
{
    public partial class DeliveryOrder
    {
        public DeliveryOrder()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string AddressFrom { get; set; } = null!;
        public string AddressTo { get; set; } = null!;
        public double GoodsPrice { get; set; }
        public double DeliveryPrice { get; set; }
        public double TotalPrice { get; set; }
        public bool CompleteStatus { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
