using RabbitMQ.Client;
using TestSolutions.Application.Orders;
using TestSolutions.Common.ApplicationSettings;

namespace TestSolutions.Application.Messaging
{
    public class CreateOrderMessagingClient
    {
        private readonly IConfigurationRepository _configurationRepository;
        private IConnection _connection;
        private IModel _channel;

        private readonly string _exchange;
        private readonly int _port;
        private readonly string _queue;
        private readonly string _host;
        private readonly string _username;
        private readonly string _password;
        private readonly string _virtualHost;

        private readonly string _routingKey = "CustomerCreation";

        public CreateOrderMessagingClient(IConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;

            _exchange = _configurationRepository.GetConfigurationValue<string>("MessageExchange");
            _port = _configurationRepository.GetConfigurationValue<int>("MessagePort", 5672);
            _queue = _configurationRepository.GetConfigurationValue<string>("MessageQueue");
            _host = _configurationRepository.GetConfigurationValue<string>("MessageHostname");
            _username = _configurationRepository.GetConfigurationValue<string>("MessageUsername");
            _password = _configurationRepository.GetConfigurationValue<string>("MessagePassword");
            _virtualHost = _configurationRepository.GetConfigurationValue<string>("MessageVirtualHost");
        }

        public void CreateConnection()
        {
            _connection = GetRabbitMQConnection();

            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare(_exchange, ExchangeType.Direct, true, false, null);
            _channel.QueueDeclare(_queue, true, false, false, null);
            _channel.QueueBind(_queue, _exchange, _routingKey);
        }

        public void AddOrderToQueue(OrderModel order)
        {
            IBasicProperties properties = _channel.CreateBasicProperties();
            properties.Persistent = true;
            properties.ContentType = "text/plain";

            PublicationAddress address = new PublicationAddress(ExchangeType.Direct, _exchange, _routingKey);
            _channel.BasicPublish(address, properties, order.Serialize());
            _channel.Close();
        }

        public void Close()
        {
            _connection.Close();
        }
        private IConnection GetRabbitMQConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory();
            connectionFactory.Port = _port;
            connectionFactory.HostName = _host;
            connectionFactory.UserName = _username;
            connectionFactory.Password = _password;
            connectionFactory.VirtualHost = _virtualHost;

            return connectionFactory.CreateConnection();
        }
    }
}
