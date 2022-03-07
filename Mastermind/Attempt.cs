using System.Collections.Generic;

namespace Mastermind
{
    public class Attempt
    {
        public readonly Color[] _guess;
        public readonly List<Color> _result;

        public Attempt(Color[] guess, List<Color> result)
        {
            _guess = guess;
            _result = result;
        }
    }
}