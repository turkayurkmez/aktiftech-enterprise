using MassTransit;
using shop.Messages;

public class PaymentCompletedEventConsumer : IConsumer<PaymentCompleted>
{
    private readonly ILogger<PaymentCompletedEventConsumer> _logger;

    public PaymentCompletedEventConsumer(ILogger<PaymentCompletedEventConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<PaymentCompleted> context)
    {

        _logger.LogInformation($"{context.Message.OrderId} nolu sipariş onaylanmıştır");
        return Task.CompletedTask;
    }
}