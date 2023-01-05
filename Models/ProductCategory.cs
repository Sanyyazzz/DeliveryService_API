using System;
using System.Collections.Generic;

namespace DeliveryService_WebAPI.Models
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Category { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
