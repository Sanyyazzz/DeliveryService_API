using DeliveryService_WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeliveryService_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryServiceController : ControllerBase
    {
        private DeliveryServiceContext context;

        public DeliveryServiceController(DeliveryServiceContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            if(context.Products.ToList().Count == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(context.Products.ToList());
            }
        }            

        [HttpGet("{id}")]
        public IActionResult GetProductByCategory(int id)
        {
            var productByCategory = context.Products.Where((p) => p.CategoryId == id).ToList();

            return Ok(productByCategory);
        }

        [HttpGet("user/{id}")]
        public IActionResult GetUser(int id)
        {
            return Ok(context.Users.Where((p) => p.Id == id).Single());
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] InputOrder inputOrder)
        {
            var deliveryCost = 40; //static cost for all order            
            var order = new OrderHistory(inputOrder);
            var orderList = new List<ItemInOrderList>();

            order.TotalPrice += deliveryCost;

            context.OrderHistories.Add(order);
            await context.SaveChangesAsync();
                        
            if(order.Id == 0)
            {
                return BadRequest();
            }
            else
            {
                inputOrder.OrderList.ForEach((g) => orderList.Add(new ItemInOrderList(order.Id, g)));
                await context.OrderLists.AddRangeAsync(orderList);

                await context.SaveChangesAsync();
            }

            return Ok();
        }
    }
}
