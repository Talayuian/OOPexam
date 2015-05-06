using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPeksamen2.Exceptions
{
    class NotActiveException : Exception
    {
        public NotActiveException()
        {
        }
        public NotActiveException(string message)
            : base(message)
        {
        }
        public NotActiveException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
