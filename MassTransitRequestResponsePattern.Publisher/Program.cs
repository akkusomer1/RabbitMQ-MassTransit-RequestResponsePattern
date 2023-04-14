
using MassTransit;
using Shared.RequestResponseMessages;

Console.WriteLine("Publisher");

string uri = "amqps://elifsxaozz:fsHBZLFsOOIjLRCPriEgU0sbeKNUhfgt_YSUm@toad.rmq.cloudamqp.com/elixaozz";

var bus = Bus.Factory.CreateUsingRabbitMq(configure =>
{
    configure.Host(uri);
});

string queueName = "request-queue";

await bus.StartAsync();
IRequestClient<RequestMessage> request = bus.CreateRequestClient<RequestMessage>(new Uri($"{uri}/{queueName}"));


int i = 0;
while (true)
{
    i++;
   await Task.Delay(1000);
    Response<ResponseMessage> response = await request.GetResponse<ResponseMessage>(new RequestMessage { MessageNo=i, Text=$"{i}. request"});
    Console.WriteLine($"Response Receive:{response.Message.Text}");
}


Console.Read();
