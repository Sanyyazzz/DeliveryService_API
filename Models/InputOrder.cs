namespace DeliveryService_WebAPI.Models
{
    public class InputOrder
    {
        public List<InputOrderedProduct> OrderList { get; set; } 
        public double TotalPrice { get; set; }
        public string FromAddress { get; set; } = null!;
        public string ToAddress { get; set; } = null!;
        public int UserId { get; set; }
        public int StatusId { get; set; }
    }
}
