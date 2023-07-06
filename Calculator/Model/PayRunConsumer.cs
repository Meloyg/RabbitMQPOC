using MassTransit;
using Model;

namespace Calculator.Model;

public class PayRunConsumer : IConsumer<PayRunClosedEvent>
{
    private readonly ILogger<PayRunConsumer> _logger;

    public PayRunConsumer(ILogger<PayRunConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<PayRunClosedEvent> context)
    {
        await Console.Out.WriteLineAsync($"Received: {context.Message.PayRunId}");
        _logger.LogInformation($"Received: {context.Message.PayRunId}");
    }
}