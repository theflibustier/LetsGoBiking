using JCAdminEndP;
using System;
namespace HeavyClient
{
    class LastUsedStationCmd : ICommand
    {
        public LastUsedStationCmd()
        {
        }
        public void Execute()
        {
            RoutingBikesSoapClient service = new RoutingBikesSoapClient();
            CompositeType compositeType = service.getLastUsedStationAsync().Result;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(compositeType.stationName + " used -> " + compositeType.value + "% of the time");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public string help()
        {
            return "Command LastUsedStation: Returns the last used station";
        }
    }
}
