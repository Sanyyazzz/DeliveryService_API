using DeliveryService_WebAPI.Models;

namespace DeliveryService_WebAPI.Providers
{
    public interface IOrderManager
    {
        public Task<OrderHistory> AddOrderAndOrderListToDB(InputOrder inputOrder);

        public Task<OrderHistory> CreateOrderAndOrderList(InputOrder inputOrder);

        public void AddCostForDeliveryToTotalPrice(InputOrder inputOrder);

        public double GetCostOfDelivery(InputOrder inputOrder);

        public void CreateOrderList(InputOrder inputOrder, int id);
    }
}
