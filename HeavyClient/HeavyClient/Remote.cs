using System;
using System.Collections.Generic;
using System.Text;

namespace HeavyClient
{
    public class Remote
    {
        public Remote()
        {
        }
        public void Invoke(ICommand cmd)
        {
            cmd.Execute();
        }
    }
}
