using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyCacheJC
{
    public class JCDecauxItem
    {
        public string response { get; set; }
        public JCDecauxItem()
        {
        }

        public JCDecauxItem(string json)
        {
            response = json;
        }
    }
}
