using System;
using System.ServiceModel;

namespace HostProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost serviceHost = new ServiceHost(typeof(ProxyCacheJC.WebProxyRest));
            serviceHost.Open();
            Console.WriteLine("The service is ready.");
            Console.WriteLine("Press <ENTER> to terminate service.");
            Console.WriteLine();
            Console.ReadLine();
            serviceHost.Close();
        }
    }
}