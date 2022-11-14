using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DeliveryService_WebAPI.Models;

namespace DeliveryService_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryServiceController : ControllerBase
    {
        DeliveryServiceContext context;

        public DeliveryServiceController(DeliveryServiceContext context)
        {
            this.context = context;
        }

        [HttpGet(Name = "GetAllDeliveryOrders")]
        public IEnumerable<Good> Get()
        {
            return context.Orders.Where(s => s.OrderId == 1).Select((g)=>g.Goods);
        }
    }
}
