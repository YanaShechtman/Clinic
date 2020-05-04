using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace RabbitDevice
{
    public class RabbitSender
    {
        public string HostName { get; set; }
        private ConnectionFactory _factory;
        public RabbitSender(string hostName)
        {
            HostName = hostName;
            _factory = new ConnectionFactory() { HostName = HostName };
        }

        public void SendMessage(string queueName, string message)
        {
            using (var connection = _factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueName,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                    routingKey: queueName,
                    basicProperties: null,
                    body: body);
            }
        }
    }
}
