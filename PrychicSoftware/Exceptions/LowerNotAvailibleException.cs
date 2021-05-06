using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrychicSoftware.Exceptions
{
    public class LowerNotAvailibleException : Exception
    {
        public LowerNotAvailibleException(string message)
            : base(message)
        {

        }
    
    }
}
