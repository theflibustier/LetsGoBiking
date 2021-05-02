using System;
using System.Collections.Generic;

namespace HeavyClient
{
    class Program
    {
        static void Main(string[] args)
        {
            IDictionary<string, ICommand> dico = new Dictionary<string, ICommand>();

            initCommands(dico);

            bool isDone = false;
            string inputUser;
            Remote remote = new Remote();
            while (!isDone)
            {
                Console.Write("Enter your command> ");
                inputUser = Console.ReadLine().Trim();
                if (inputUser.Trim().Equals("exit"))
                {
                    Console.WriteLine("Bye :)");
                    return;
                }
                else if(inputUser.Trim().Equals("help")){
                    Console.ForegroundColor = ConsoleColor.Green;
                    int i = 0;
                    foreach(KeyValuePair<string, ICommand> entry in dico)
                    {
                        Console.WriteLine(i+1+": "+ entry.Value.help());
                        i++;
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                if (dico.ContainsKey(inputUser))
                {
                    remote.Invoke(dico[inputUser]);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bad command :(");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        //Adds available commands
        static void initCommands(IDictionary<string, ICommand> dico)
        {
            dico.Add("StatStation", new StatStationCmd());
            dico.Add("MostUsedStation", new MostUsedStationCmd());
            dico.Add("LastUsedStation", new LastUsedStationCmd());
        }
    }
}
