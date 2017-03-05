using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSolutions.OrderPlanner
{
    public class Program
    {
        private static string _hostName = "localhost";
        private static string _userName = "accountant";
        private static string _password = "accountant";
        private static string _queue = "TestSolutionsMessageQueue";
        private static string _virtualHost = "accounting";
        private static int _port = 5672;

        static void Main(string[] args)
        {
            BuildMessageQueue();
        }

        private static void BuildMessageQueue()
        {
            IConnection connection = GetRabbitMqConnection();
            IModel channel = connection.CreateModel();
            channel.BasicQos(0, 1, false);
            EventingBasicConsumer eventingBasicConsumer = new EventingBasicConsumer(channel);

            eventingBasicConsumer.Received += (sender, BasicDeliverEventArgs) =>
            {
                IBasicProperties basicProperties = BasicDeliverEventArgs.BasicProperties;
                Console.WriteLine("Message Recieved by the consumer");
                Console.WriteLine(string.Concat("Message recieved from the exchange: ", BasicDeliverEventArgs.Exchange));
                Console.WriteLine(string.Concat("Routing Key: ", BasicDeliverEventArgs.RoutingKey));
                Console.WriteLine(string.Concat("Message: \r\n\r\n", Encoding.UTF8.GetString(BasicDeliverEventArgs.Body)));
                channel.BasicAck(BasicDeliverEventArgs.DeliveryTag, false);
            };
            channel.BasicConsume(_queue, false, eventingBasicConsumer);
        }

        private static IConnection GetRabbitMqConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory();
            connectionFactory.Port = _port;
            connectionFactory.HostName = _hostName;
            connectionFactory.UserName = _userName;
            connectionFactory.Password = _password;
            connectionFactory.VirtualHost = _virtualHost;
            return connectionFactory.CreateConnection();
        }
    }
}
