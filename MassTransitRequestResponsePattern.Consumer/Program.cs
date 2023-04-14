using MassTransit;
using MassTransitRequestResponsePattern.Consumer.Consumers;

Console.WriteLine("Consumer");
string uri = "amqps://elifsxaozz:fsHBZLFsOOIjLRCPriEgU0sbeKNUhfgt_YSUm@toad.rmq.cloudamqp.com/elixaozz";

string queueName = "request-queue";

var bus=Bus.Factory.CreateUsingRabbitMq(configure =>
{
    configure.Host(uri);

    configure.ReceiveEndpoint(queueName, endpoint =>
    {
        endpoint.Consumer<RequestMessageConsumer>();
    });
});


await bus.StartAsync();

Console.Read();
