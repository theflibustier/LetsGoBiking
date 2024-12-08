using Aspose.Cells;
using System;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using System.Text.Json;

namespace RoutingBikes
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "IRoutingBikes" à la fois dans le code et le fichier de configuration.
    public class RoutingBikesSoap : IRoutingBikesSoap
    {
        private Workbook wb;
        private Worksheet sheet;
        private readonly string brokerUri;
        private readonly string userName;
        private readonly string password;

        public RoutingBikesSoap()
        {
            wb = new Workbook(@"Excel.xlsx");
            sheet = wb.Worksheets[0];
            brokerUri = System.Configuration.ConfigurationManager.AppSettings["activemq.brokerUri"];
            userName = System.Configuration.ConfigurationManager.AppSettings["activemq.userName"];
            password = System.Configuration.ConfigurationManager.AppSettings["activemq.password"];
        }

        public CompositeType getMostUsedStation()
        {
            return SendRequest<CompositeType>("getMostUsedStation", null);
        }

        public CompositeType getStatsByStation(string stationName)
        {
            return SendRequest<CompositeType>("getStatsByStation", stationName);
        }

        public CompositeType getLastUsedStation()
        {
            return SendRequest<CompositeType>("getLastUsedStation", null);
        }

        private T SendRequest<T>(string operation, string parameter)
        {
            IConnectionFactory factory = new ConnectionFactory(brokerUri);
            using (IConnection connection = factory.CreateConnection(userName, password))
            {
                connection.Start();
                using (ISession session = connection.CreateSession())
                {
                    IDestination destination = session.GetQueue("RoutingBikesQueue");
                    using (IMessageProducer producer = session.CreateProducer(destination))
                    {
                        IMessage requestMessage = session.CreateTextMessage(JsonSerializer.Serialize(new { Operation = operation, Parameter = parameter }));
                        producer.Send(requestMessage);

                        using (IMessageConsumer consumer = session.CreateConsumer(destination))
                        {
                            IMessage responseMessage = consumer.Receive();
                            if (responseMessage is ITextMessage textMessage)
                            {
                                return JsonSerializer.Deserialize<T>(textMessage.Text);
                            }
                        }
                    }
                }
            }
            return default(T);
        }
    }
}
