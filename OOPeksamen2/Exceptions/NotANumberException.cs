using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPeksamen2
{
    public class NotANumberException:Exception
    {
         public NotANumberException()
        {
        }
        public NotANumberException(string message):base(message)
        {
        }
        public NotANumberException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
