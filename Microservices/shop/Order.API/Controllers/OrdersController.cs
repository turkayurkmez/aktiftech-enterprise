using MassTransit;
using Microsoft.AspNetCore.Mvc;
using shop.Messages;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IPublishEndpoint publishEndpoint;
        private readonly ILogger<OrdersController> logger;

        public OrdersController(IPublishEndpoint publishEndpoint, ILogger<OrdersController> logger)
        {
            this.publishEndpoint = publishEndpoint;
            this.logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(int customerId, List<OrderItem> orderItems)
        {
            var orderCreatedEvent = new OrderCreated
            {
                CustomerId = customerId,
                OrderId = new Random().Next(100, 1000),
                TotalPrice = 150,
                OrderItems = orderItems.Select(o => new OrderItemMessage { Price = o.Price, ProductId = o.ProductId, Quantity = o.Quantity }).ToList()

            };

            await publishEndpoint.Publish(orderCreatedEvent);
            logger.LogInformation("Sipariş olayı fırlatıldı ");
            return Ok();
        }
    }
}
