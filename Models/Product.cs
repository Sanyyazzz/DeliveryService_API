using System;
using System.Collections.Generic;

namespace DeliveryService_WebAPI.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = null!;
        public double Price { get; set; }
        public int? Weight { get; set; }
        public int CategoryId { get; set; }
        public string Image { get; set; } = null!;

        public virtual ProductCategory Category { get; set; } = null!;
    }
}
