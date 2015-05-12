using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPeksamen2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            StringSystem stringsystem = new StringSystem();
            StringSystemCLI CLI = new StringSystemCLI(stringsystem);
            StringSystemCommandParser parser = new StringSystemCommandParser(stringsystem, CLI);

            CLI.Start(parser);
            Console.ReadKey();
        }
    }
}
