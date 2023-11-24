using MassTransit;
using shop.Messages;

namespace Stock.API
{
    public class OrderCreatedEventConsumer : IConsumer<OrderCreated>
    {
        private readonly ILogger<OrderCreatedEventConsumer> _logger;
        private readonly IPublishEndpoint publishEndpoint;

        public OrderCreatedEventConsumer(ILogger<OrderCreatedEventConsumer> logger, IPublishEndpoint publishEndpoint)
        {
            _logger = logger;
            this.publishEndpoint = publishEndpoint;
        }

        public async Task Consume(ConsumeContext<OrderCreated> context)
        {
            bool isInstock = isAvailableInStock(context.Message.OrderItems);
            if (isInstock)
            {
                var inStockEvent = new StockReserved { CustomerId = context.Message.CustomerId, OrderId = context.Message.OrderId, TotalPrice = context.Message.TotalPrice };

                _logger.LogInformation("Stokta var");
                await publishEndpoint.Publish(inStockEvent);
            }
            else
            {
                var notStockEvent = new StockNotReserved { CustomerId = context.Message.CustomerId, OrderId = context.Message.OrderId, Message = "Stok yetersiz" };
                _logger.LogInformation("Stokta yok");


                await publishEndpoint.Publish(notStockEvent);
            }
        }

        private bool isAvailableInStock(List<OrderItemMessage> orderItems)
        {
            return Convert.ToBoolean(new Random().Next(0, 2));
        }
    }
}
