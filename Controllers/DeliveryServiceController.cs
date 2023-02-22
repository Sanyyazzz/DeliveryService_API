using DeliveryService_WebAPI.Models;
using DeliveryService_WebAPI.Providers;
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
        private IOrderManager orderManager;

        public DeliveryServiceController(DeliveryServiceContext context, IOrderManager orderManager)
        {
            this.context = context;
            this.orderManager = orderManager;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(context.Products.ToList());
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
            var userFromDb = context.Users.Where((p) => p.Id == id).Single();

            if (userFromDb != null)
            {                
                var userToClient = new UserToClient(userFromDb);

                var usersOrderHistory = context.OrderHistories.Where(h => h.UserId == userToClient.Id).ToList();
                userToClient.OrderHistory = usersOrderHistory;

                return Ok(userToClient);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] InputOrder inputOrder)
        {
            if (ModelState.IsValid)
            {
                var addedOrder = await orderManager.AddOrderAndOrderListToDB(inputOrder);
                return Ok(addedOrder);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelOrder(int id)
        {
            var order = await context.OrderHistories.FindAsync(id);
            
            if(order != null)
            {
                var orderList = context.OrderLists.Where((h) => h.OrderId == order.Id);
                context.OrderLists.RemoveRange(orderList);
                context.OrderHistories.Remove(order);

                context.SaveChangesAsync();
                return Ok();
            }

            return NotFound();
        }
    }
}
