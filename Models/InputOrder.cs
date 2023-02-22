using System.ComponentModel.DataAnnotations;

namespace DeliveryService_WebAPI.Models
{
    public class InputOrder
    {
        [Required]
        public List<InputOrderedProduct> OrderList { get; set; } 

        public double TotalPrice { get; set; }

        [Required]
        public string FromAddress { get; set; } = null!;

        [Required]
        public string ToAddress { get; set; } = null!;

        [Required]
        public int UserId { get; set; }

        public int StatusId { get; set; }
    }
}
