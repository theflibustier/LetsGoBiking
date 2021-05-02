using JCAdminEndP;
using System;

namespace HeavyClient
{
    class StatStationCmd : ICommand
    {
        public StatStationCmd()
        {
        }
        public void Execute()
        {
            RoutingBikesSoapClient service = new RoutingBikesSoapClient();
            Console.Write("\tName of your station> ");
            string inputUser = Console.ReadLine().Trim();
            try
            {
                CompositeType compositeType = service.getStatsByStationAsync(inputUser).Result;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t"+compositeType.stationName + " used -> " + compositeType.value + "% of the time");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tStation Inexistante");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public string help()
        {
            return "Command StatStation: Returns the statistics for a given station";
        }
    }
}
