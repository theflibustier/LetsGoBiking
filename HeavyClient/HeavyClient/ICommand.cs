using System;
using System.Collections.Generic;
using System.Text;

namespace HeavyClient
{
    public interface ICommand
    {
        void Execute();
        string help();
    }
}
