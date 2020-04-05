using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitDevice
{
    public class RabbitReceiver : IDisposable
    {
        public string HostName { get; set; }
        private IConnection _connection;
        private IModel _channel;
        public string QueueName { get; set; }
        
        public RabbitReceiver(string hostName, string queueName)
        {
            HostName = hostName;
            QueueName = queueName;
            var factory = new ConnectionFactory() { HostName = HostName };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: QueueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += ConsumerOnReceived;
            _channel.BasicConsume(queue: "hello",
                autoAck: true,
                consumer: consumer);
        }

        private void ConsumerOnReceived(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body;
            var message = Encoding.UTF8.GetString(body);
        }

        public void Dispose()
        {
            _connection?.Dispose();
            _channel?.Dispose();
        }
    }
}
