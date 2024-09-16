using RabbitMQ.Client;
using System.Text;

namespace LibraryManagementSystem.Messaging
{
    public class RabbitMQPublisher
    {
        public void PublishMessage(string message)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "bookQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "", routingKey: "bookQueue", basicProperties: null, body: body);
                Console.WriteLine($" [x] Sent {message}");
            }
        }

    }
}
