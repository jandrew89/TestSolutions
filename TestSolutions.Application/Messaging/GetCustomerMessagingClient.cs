using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolutions.Application.Customers;

namespace TestSolutions.Application.Messaging
{
    public class CreateCustomerMessagingClient
    {
        private IConnection _connection;
        private IModel _channel;

        public void CreateConnection()
        {
            ConnectionFactory factory = new ConnectionFactory();

            factory.Port = 5672;
            factory.HostName = "localhost";
            factory.UserName = "accountant";
            factory.Password = "accountant";
            factory.VirtualHost = "accounting";

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare("TestSolutionsMessageExchange", ExchangeType.Direct, true, false, null);
            _channel.QueueDeclare("TestSolutionsMessageQueue", true, false, false, null);
            _channel.QueueBind("TestSolutionsMessageQueue", "TestSolutionsMessageExchange", "CustomerCreation");
        }

        public void Close()
        {
            _connection.Close();
        }

        public void AddCustomerDataToQueue(CustomerModel custModel)
        {
            IBasicProperties properties = _channel.CreateBasicProperties();
            properties.Persistent = true;
            properties.ContentType = "text/plain";

            PublicationAddress address = new PublicationAddress(ExchangeType.Direct, "TestSolutionsMessageExchange", "CustomerCreation");
            _channel.BasicPublish(address, properties,custModel.Serialize());
            _channel.Close();
        }
    }
}
