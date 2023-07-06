using MassTransit;
using Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

var bus = Bus.Factory.CreateUsingRabbitMq(configure =>
{
    configure.Host("amqp://guest:guest@localhost:5672");
    configure.ReceiveEndpoint("temp-queue",
        endpoint =>
        {
            endpoint.Handler<PayRunClosedEvent>(context =>
            {
                return Console.Out.WriteLineAsync($"Received: {context.Message.PayRunId}");
            });
        });
});

bus.Start();

bus.Publish(new PayRunClosedEvent { PayRunId = 123 });