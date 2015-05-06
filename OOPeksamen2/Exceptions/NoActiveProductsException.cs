using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPeksamen2
{
    class NoActiveProductsException:Exception
    {
        public NoActiveProductsException()
        {
        }
        public NoActiveProductsException(string message):base(message)
        {
        }
        public NoActiveProductsException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
