using PrychicSoftware.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrychicSoftware
{
    public class Psychic : IPsychic
    {
        private int _currentGuess;
        private int _lowerBound;
        private int _upperBound;
        private bool _complete;
        private IEnumerable<int> _guessHistory;
        private int _guessCount;
        public int CurrentGuess => _currentGuess;

        public int LowerBound => _lowerBound;

        public int UpperBound => _upperBound;

        public bool Complete => _complete;

        public IEnumerable<int> GuessHistory => _guessHistory;

        public int GuessCount => _guessCount;

        private Random random;
        public Psychic(int lowerBound, int upperBound)
        {
            _complete = false;
            _guessHistory = new List<int>();
            _guessCount = 0;

            _lowerBound = lowerBound;
            _upperBound = upperBound;

            random = new Random();

            _currentGuess = DoGuess();
            if (IsCorrect())
            {
                Correct();
            }

        }

        public void Correct()
        {
            _complete = true;
        }

        public void Higher()
        {
            CheckCompletion();

            if (IsCorrect())
            {
                Correct();
                return;
            }

            if (_upperBound == _currentGuess)
            {
                throw (new HigherNotAvailibleException("Highest is guessed"));
            }
            _lowerBound = _currentGuess + 1;
            _currentGuess = DoGuess();
            

        }

        public void Lower()
        {

            CheckCompletion();

            if (IsCorrect())
            {
                Correct();
                return;
            }

            if (_lowerBound == _currentGuess)
            {
                throw new LowerNotAvailibleException("Lowest is guessed");
            }
            _upperBound = _currentGuess - 1;
            _currentGuess = DoGuess();
            

        }

        private int DoGuess()
        {
            int guess = random.Next(_lowerBound, _upperBound+1);
            List<int> guessHistoryList = _guessHistory as List<int>;
            guessHistoryList.Add(guess);
            _guessCount++;

            return guess;
        }
        private void CheckCompletion()
        {
            if (_complete == true)
            {
                throw new GameAlreadyFinishedException("Game is completed");
            }
        }
        private bool IsCorrect()
        {
            return _upperBound == _lowerBound;
           
        }
    }
}
