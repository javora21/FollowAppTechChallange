using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrychicSoftware
{
    public interface IPsychic
    {
        int CurrentGuess { get; }
        int LowerBound { get; }
        int UpperBound { get; }
        bool Complete { get; }
        IEnumerable<int> GuessHistory { get; }
        int GuessCount { get; }
        void Higher();
        void Lower();
        void Correct();
    }
}
