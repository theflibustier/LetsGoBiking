using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyCacheJC
{
    public class Contract
    {
        public string name { get; set; }
        public string commercial_name { get; set; }
        public string country_code { get; set; }
        public List<string> cities { get; set; }

    }
}
