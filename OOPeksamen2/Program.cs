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

            User user = new User((uint)stringsystem.Users.Count, "Line", "Larsen", "fredefup", "frederik@Palmelund.voldby.dk");
            stringsystem.Users.Add(user.UserID, user);

            Console.WriteLine(user.Balance);

            parser.ParseCommand(":addcredits fredefup 100000");
            Console.WriteLine(user.Balance);




            
            

            Console.ReadKey();
        }
    }
}
