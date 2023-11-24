using MassTransit;
using shop.Messages;

namespace Order.API.Consumers
{
    public class ProductPriceChangedEventConsumer : IConsumer<ProductPriceChanged>
    {
        private readonly ILogger<ProductPriceChangedEventConsumer> logger;

        public ProductPriceChangedEventConsumer(ILogger<ProductPriceChangedEventConsumer> logger)
        {
            this.logger = logger;
        }

        public Task Consume(ConsumeContext<ProductPriceChanged> context)
        {
            logger.LogInformation($"{context.Message.ProductId} nolu ürünün fiyatı düştü.");
            return Task.CompletedTask;
        }
    }
}
