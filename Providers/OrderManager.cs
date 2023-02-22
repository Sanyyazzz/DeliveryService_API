using DeliveryService_WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryService_WebAPI.Providers
{
    public class OrderManager : IOrderManager
    {
        DeliveryServiceContext context;

        public OrderManager(){ }

        public OrderManager(DeliveryServiceContext context)
        {
            this.context = context;
        }

        public async Task<OrderHistory> AddOrderAndOrderListToDB(InputOrder inputOrder)
        {
            var order = await CreateOrderAndOrderList(inputOrder);
            return order;
        }

        public async Task<OrderHistory> CreateOrderAndOrderList(InputOrder inputOrder)
        {

            AddCostForDeliveryToTotalPrice(inputOrder);

            var order = new OrderHistory(inputOrder);

            context.OrderHistories.Add(order);
            await context.SaveChangesAsync();

            CreateOrderList(inputOrder, order.Id);

            return order;
        }

        public void AddCostForDeliveryToTotalPrice(InputOrder inputOrder)
        {
            var costOfDelivery = GetCostOfDelivery(inputOrder);
            inputOrder.TotalPrice += costOfDelivery;
        }

        public double GetCostOfDelivery(InputOrder inputOrder)
        {
            return 40;
        }

        public async void CreateOrderList(InputOrder inputOrder, int id)
        {
            var orderList = new List<ItemInOrderList>();

            if (id == 0) //order in db doesn't create
            {
                throw new Exception("Uncorrect ID in order");
            }
            else
            {
                inputOrder.OrderList.ForEach((g) => orderList.Add(new ItemInOrderList(id, g)));
                await context.OrderLists.AddRangeAsync(orderList);
                await context.SaveChangesAsync();
            }
        }
    }
}
