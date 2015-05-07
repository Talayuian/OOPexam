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


            User user = new User((uint)stringsystem.Users.Count, "Frederik", "Palmelund", "thepalmelund", "frederik.palmelund@gmail.com");
            stringsystem.Users.Add(user.UserID, user);

            parser.ParseCommand(":addcredits thepalmelund 1000000");

            stringsystem.BuyProduct(user,11);
            stringsystem.BuyProduct(user, 13);
            stringsystem.BuyProduct(user, 14);
            stringsystem.BuyProduct(user, 15);
            stringsystem.BuyProduct(user, 16);
            stringsystem.BuyProduct(user, 11);
            stringsystem.BuyProduct(user, 13);
            stringsystem.BuyProduct(user, 14);
            stringsystem.BuyProduct(user, 15);
            stringsystem.BuyProduct(user, 16);
            stringsystem.BuyProduct(user, 11);
            stringsystem.BuyProduct(user, 13);
            stringsystem.BuyProduct(user, 14);
            stringsystem.BuyProduct(user, 15);
            stringsystem.BuyProduct(user, 16);
            stringsystem.BuyProduct(user, 11);
            stringsystem.BuyProduct(user, 13);
            stringsystem.BuyProduct(user, 14);
            stringsystem.BuyProduct(user, 15);
            stringsystem.BuyProduct(user, 16);
            

            parser.ParseCommand("thepalmelund");
            Console.ReadKey();
        }
    }
}
