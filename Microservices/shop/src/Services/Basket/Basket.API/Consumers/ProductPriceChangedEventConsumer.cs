using MassTransit;
using shop.Messages;

namespace Basket.API.Consumers
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
            //veritabanında ürünün fiyatını güncellediniz....

            logger.LogInformation($"Ürün fiyatı değişti! {context.Message.ProductId} id'li ürünün yeni fiyatı {context.Message.NewPrice}. Yapılan indirim {context.Message.OldPrice - context.Message.NewPrice}");

            return Task.CompletedTask;
        }
    }
}
