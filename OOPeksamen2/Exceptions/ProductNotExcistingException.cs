using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPeksamen2
{
    class ProductNotExcistingException:Exception
    {
        public ProductNotExcistingException()
        {
        }
        public ProductNotExcistingException(string message)
            : base(message)
        {
        }
        public ProductNotExcistingException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
