using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System;
using System.Text;
using Users.Api.Configuration;

namespace Users.Api.Services
{
    public class MessageService : IMessageService
    {
        private readonly IModel _channel;
        private readonly string _queueName;

        public MessageService(IOptions<MessageSenderSettings> senderSettings)
        {
            var settings = senderSettings.Value;
            _queueName = settings.Queue;

            var factory = new ConnectionFactory() { HostName = settings.HostName, Port = settings.Port };
            factory.UserName = settings.UserName;
            factory.Password = settings.Password;
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
            _channel.QueueDeclare(queue: _queueName,
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);
        }
        public void Enqueue(string messageString)
        {
            _channel.BasicPublish(exchange: "", routingKey: _queueName, body: Encoding.UTF8.GetBytes(messageString));
        }
    }
}
