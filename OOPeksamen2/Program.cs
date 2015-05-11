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

            //test user begin:
            stringsystem.Users.Add((uint) stringsystem.Users.Count,new User((uint)stringsystem.Users.Count,"daniel thiemer","Sørensen","me","dtsa14@student.aau.dk"));
            parser.ParseCommand(":addcredits me 20050");
            //test user end:

            CLI.Start(parser);
            Console.ReadKey();
        }
    }
}
