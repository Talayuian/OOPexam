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
            User bo = new User(0415, "bopus", "Bo", "Larsen", "Dani_9220@hotmail.com");
            Console.WriteLine(bo.ToString);
            Console.ReadKey();
        }
    }
}
