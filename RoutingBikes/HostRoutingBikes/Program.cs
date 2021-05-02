using System;
using System.ServiceModel;

namespace HostRoutingBikes
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost serviceHostRest = new ServiceHost(typeof(RoutingBikes.RoutingBikesRest));
            serviceHostRest.Open();

            ServiceHost serviceHostSoap = new ServiceHost(typeof(RoutingBikes.RoutingBikesSoap));
            serviceHostSoap.Open();

            Console.WriteLine("The services is ready.");
            Console.WriteLine("Press <ENTER> to terminate service.");
            Console.ReadLine();
            serviceHostRest.Close();
            serviceHostSoap.Close();
        }
    }
}
