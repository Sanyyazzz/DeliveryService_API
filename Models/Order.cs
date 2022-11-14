using System;
using System.Collections.Generic;

namespace DeliveryService_WebAPI.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int GoodsId { get; set; }
        public int Count { get; set; }

        public virtual Good Goods { get; set; } = null!;
        public virtual DeliveryOrder OrderNavigation { get; set; } = null!;
    }
}
