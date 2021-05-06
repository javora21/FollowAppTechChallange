using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrychicSoftware.Exceptions
{
    public class GameAlreadyFinishedException : Exception
    {
        public GameAlreadyFinishedException(string message)
            :base(message)
        {

        }
    }
}
