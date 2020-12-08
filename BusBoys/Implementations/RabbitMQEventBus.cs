using BusBoys.Interfaces;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BusBoys.Implementations
{
    public class RabbitMQEventBus : IEventBus
    {
        String _hostname;
        int _portNumber;
        public string HostName { get => _hostname; set => _hostname = value; }

        public int PortNumber { get => _portNumber; set => _portNumber = value; }

        public string ConsumeEvent(string queueName)
        {
            var factory = new ConnectionFactory() { HostName = "host.docker.internal" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueName,
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var data = channel.BasicGet(queueName, false);

                if (data == null) return false.ToString();

                var body = data.Body.ToArray();

                var message = Encoding.UTF8.GetString(body);

                channel.BasicAck(data.DeliveryTag, false);

                return message;
            }
        }

        public void PublishEvent<T>(String queueName, T e)
        {
            if (String.IsNullOrEmpty(HostName))
                throw new Exception("Hostname needs provided");

            var factory = new ConnectionFactory() { HostName = _hostname, Port = _portNumber };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueName,
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = JsonSerializer.Serialize(e);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: queueName,
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}

