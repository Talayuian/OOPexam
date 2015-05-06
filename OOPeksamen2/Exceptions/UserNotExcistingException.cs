using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPeksamen2
{
    class UserNotExcistingException:Exception
    {
        public UserNotExcistingException()
        {
            
        }
        public UserNotExcistingException(string message):base(message)
        {
        }
        public UserNotExcistingException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
