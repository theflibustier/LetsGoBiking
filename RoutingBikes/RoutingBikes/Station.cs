using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingBikes
{
    public class Station
    {
        public string number { get; set; }
        public string contractName { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public Position position { get; set; }
        public string banking { get; set; }
        public string bonus { get; set; }
        public string status { get; set; }
        public string lastUpdate { get; set; }
        public string connected { get; set; }
        public string overflow { get; set; }
        public string shape { get; set; }
        public TotalStands totalStands { get; set; }


        public string toString()
        {
            return "Les infos = " + name + " ; " + number + " ...";
        }
    }
}
