using System;
using System.Collections.Generic;

namespace DeliveryService_WebAPI.Models
{
    public partial class OrderHistory
    {
        public OrderHistory(InputOrder inputOrder)
        {
            TotalPrice = inputOrder.TotalPrice;
            FromAddress = inputOrder.FromAddress;
            ToAddress = inputOrder.ToAddress;
            UserId = inputOrder.UserId;
            StatusId = inputOrder.StatusId;
        }

        public OrderHistory(
            double totalPrice, 
            string fromAddress, 
            string toAddress, 
            int userId, 
            int statusId
            )
        {
            TotalPrice = totalPrice;
            FromAddress = fromAddress;
            ToAddress = toAddress;
            UserId = userId;
            StatusId = statusId;
        }

        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public string FromAddress { get; set; } = null!;
        public string ToAddress { get; set; } = null!;
        public int UserId { get; set; }
        public int StatusId { get; set; }

        public virtual OrderStatus Status { get; set; } = null!;
    }
}
