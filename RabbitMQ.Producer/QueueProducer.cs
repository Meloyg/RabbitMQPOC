using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace RabbitMQ.Producer;

public class QueueProducer
{
    public static void Publish(IModel channel)
    {
        channel.QueueDeclare("demo-queue",
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        var count = 0;
        while (true)
        {
            var message = new
            {
                Name = "Producer",
                Message = "Hello!",
                Count = count
            };

            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

            channel.BasicPublish(string.Empty, "demo-queue", null, body);
            count++;
            Thread.Sleep(1000);
        }
    }
}