using System.Collections.Generic;

namespace Mastermind
{
    public class Attempt
    {
        public readonly Color[] _guess;
        public readonly List<ResultColor> _result;

        public Attempt(Color[] guess, List<ResultColor> result)
        {
            _guess = guess;
            _result = result;
        }
    }
}