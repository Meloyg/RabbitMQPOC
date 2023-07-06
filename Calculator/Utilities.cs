using Calculator.Models;
using MassTransit;

namespace Calculator;

public static class Utilities
{
    public static void ConfigureConsumerUsingAddMassTransit(this IServiceCollection services)
    {
        services.AddMassTransit(config =>
        {
            config.AddConsumer<PayRunConsumer>();

            config.UsingRabbitMq(((context, configurator) =>
            {
                configurator.Host("amqp://guest:guest@localhost:5672");
                configurator.ReceiveEndpoint("payrun-queue",
                    endpoint => { endpoint.ConfigureConsumer<PayRunConsumer>(context); });
            }));
        });

        services.Configure<MassTransitHostOptions>(options =>
        {
            options.WaitUntilStarted = true;
            options.StartTimeout = TimeSpan.FromSeconds(30);
            options.StopTimeout = TimeSpan.FromSeconds(1);
        });
    }
}