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
            User bo = new User(415, "bopus", "Bo", "Larsen", "Bopus_8295-e@Joachim.sneft_rup-blargh.com");
            Console.WriteLine(bo.EMail);
            Console.ReadKey();
        }
    }
}
