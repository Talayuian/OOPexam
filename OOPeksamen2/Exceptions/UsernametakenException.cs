using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPeksamen2
{
    class UsernametakenException:Exception
    {
        public UsernametakenException()
        {
        }
        public UsernametakenException(string message)
            : base(message)
        {
        }
        public UsernametakenException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
