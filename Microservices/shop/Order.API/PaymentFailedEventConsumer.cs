using MassTransit;
using shop.Messages;

public class PaymentFailedEventConsumer : IConsumer<PaymentFailed>
{

    private readonly ILogger<PaymentFailedEventConsumer> _logger;

    public PaymentFailedEventConsumer(ILogger<PaymentFailedEventConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<PaymentFailed> context)
    {
        _logger.LogWarning($"{context.Message.OrderId} nolu sipariş, {context.Message.Message} sebebiyle tamamlanamadı");

        return Task.CompletedTask;
    }

}