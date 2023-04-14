using MassTransit;
using Shared.RequestResponseMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MassTransitRequestResponsePattern.Consumer.Consumers
{
    public class RequestMessageConsumer: IConsumer<RequestMessage>
    {
        public Task Consume(ConsumeContext<RequestMessage> context)
        {
            //...Process

            Console.WriteLine($"{context.Message.Text}");

            context.RespondAsync<ResponseMessage>(new ResponseMessage { Text=$"{context.Message.MessageNo} response to request" });

            return Task.CompletedTask;
        }
    }
}
