using MassTransit;
using shop.Messages;

public class StockNotReservedEventConsumer : IConsumer<StockNotReserved>
{
    private readonly ILogger<StockNotReservedEventConsumer> _logger;

    public StockNotReservedEventConsumer(ILogger<StockNotReservedEventConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<StockNotReserved> context)
    {
        _logger.LogInformation($"{context.Message.OrderId} nolu siparişte yer alan ürünler stokta kalmamış");
        return Task.CompletedTask;
    }
}