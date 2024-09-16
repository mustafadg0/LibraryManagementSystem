using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entities
{
    public class RabbitMQConsumer
    {
        public void StartListening()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                // Mesajları dinleyeceğimiz kuyruğu belirliyoruz
                channel.QueueDeclare(queue: "bookQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine($" [x] Received {message}");

                    // Burada gelen mesajı işleyebilirsiniz
                };

                // Kuyruğu dinlemeye başlıyoruz
                channel.BasicConsume(queue: "bookQueue", autoAck: true, consumer: consumer);

                Console.WriteLine("Listening for messages. Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}
