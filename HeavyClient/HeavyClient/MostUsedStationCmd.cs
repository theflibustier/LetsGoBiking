using JCAdminEndP;
using System;

namespace HeavyClient
{
    public class MostUsedStationCmd : ICommand
    {
        public MostUsedStationCmd()
        {
        }
        public void Execute()
        {
            RoutingBikesSoapClient service = new RoutingBikesSoapClient();
            CompositeType compositeType = service.getMostUsedStationAsync().Result;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(compositeType.stationName + " used -> " + compositeType.value + "% of the time");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public string help()
        {
            return "Command MostUsedStation: Returns the most used station"; 
        }
    }
}
