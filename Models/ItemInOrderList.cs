using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DeliveryService_WebAPI.Models
{
    public partial class ItemInOrderList
    {
        public ItemInOrderList() { }

        public ItemInOrderList(int orderID, InputOrderedProduct inputProduct)
        {
            OrderId = orderID;
            ProductId = inputProduct.ProductId;
            Count = inputProduct.Count;
        }

        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }

        public virtual OrderHistory Order { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
