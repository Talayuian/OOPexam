using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPeksamen2
{
    class StringSystemCommandParser
    {
        IStringSystem stringsystem;
        IStringsystemUI CLI;
        Dictionary<string, Action<string[]>> admincmd = new Dictionary<string, Action<string[]>>();
        public StringSystemCommandParser(StringSystem stringsystem, StringSystemCLI CLI)
        {
            this.stringsystem = stringsystem;
            this.CLI = CLI;
            admincmd.Add(":q", s => CLI.Close());
            admincmd.Add(":quit", s => CLI.Close());
            admincmd.Add(":Q", s => CLI.Close());
            admincmd.Add(":Quit", s => CLI.Close());
            admincmd.Add(":deactivate", s => stringsystem.Products[uint.Parse(s[1])].SetActive(false));
            admincmd.Add(":activate", s => stringsystem.Products[uint.Parse(s[1])].SetActive(true));
            admincmd.Add(":crediton", s => stringsystem.Products[uint.Parse(s[1])].SetCanBeBoughtOnCredit(true));
            admincmd.Add(":creditoff", s => stringsystem.Products[uint.Parse(s[1])].SetCanBeBoughtOnCredit(false));
            admincmd.Add(":addcredits", s => stringsystem.Users[stringsystem.GetUser(s[1]).UserID].AddToSaldo(int.Parse(s[2])));

        }

        public void ParseCommand(string command)
        {
            if (command.StartsWith(":"))
            {
                string[] s = command.Split(' ');
                admincmd[s[0]].Invoke(s);
            }
            else
            {

            }
        }





    }
}
