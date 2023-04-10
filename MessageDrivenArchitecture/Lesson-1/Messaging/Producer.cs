using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace Messaging
{
    public class Producer
    {
        private readonly string _queueName;
        private readonly string _hostName;
        public Producer (string queueName, string hostName)
        {
            _queueName = queueName;
            _hostName = hostName;
        }
        public void Send(string message)
        {
            var factory = new ConnectionFactory() { HostName = _hostName };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.ExchangeDeclare(
                "direct_exchange",
                "direct",
                false,
                false,
                null
            );

            var body = Encoding.UTF8.GetBytes( message );

            channel.BasicPublish("direct_exchange",
                _queueName,
                null,
                body);
        }
    }
}
