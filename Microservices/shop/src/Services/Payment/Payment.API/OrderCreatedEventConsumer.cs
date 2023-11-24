using MassTransit;
using shop.Messages;

public class StockReservedEventConsumer : IConsumer<StockReserved>
{

    private readonly IPublishEndpoint _endpoint;
    private readonly ILogger<StockReservedEventConsumer> logger;

    public StockReservedEventConsumer(IPublishEndpoint endpoint, ILogger<StockReservedEventConsumer> logger)
    {
        _endpoint = endpoint;
        this.logger = logger;
    }

    public async Task Consume(ConsumeContext<StockReserved> context)
    {
        bool isPaymentCompletet = paymentProcess();
        if (isPaymentCompletet)
        {
            var paymentCompletedEvent = new PaymentCompleted { OrderId = context.Message.OrderId };
            await _endpoint.Publish(paymentCompletedEvent);
            logger.LogInformation("Ödeme yapıldı");
        }
        else
        {
            var paymentFailedEvent = new PaymentFailed { OrderId = context.Message.OrderId, Message = "Hatalı kredi kartı bilgisi" };
            await _endpoint.Publish(paymentFailedEvent);
            logger.LogInformation("Ödeme yapılamadı");

        }
    }

    private bool paymentProcess()
    {
        return Convert.ToBoolean(new Random().Next(0, 2));
    }
}