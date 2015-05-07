using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPeksamen2.Parser
{
    class AdminCommands
    {
        public AdminCommands(string admincommand,Func<bool,bool>,StringSystem Data)
        {

        }
        Dictionary<string,Func<bool,bool>> bo = new Dictionary<string,Func<bool,bool>>();

    }
}
