using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPeksamen2
{
    class NoTransactionsFoundException:Exception
    {
        public NoTransactionsFoundException()
        {
        }
        public NoTransactionsFoundException(string message):base(message)
        {
        }
        public NoTransactionsFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
