using System;
using System.Collections.Generic;

namespace DeliveryService_WebAPI.Models
{
    public partial class UserToClient
    {
        public UserToClient(User user)
        {
            this.Id = user.Id;
            this.Name = user.Name;
            this.PhoneNumber = user.PhoneNumber;
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public List<OrderHistory> OrderHistory { get; set; }
    }
}

