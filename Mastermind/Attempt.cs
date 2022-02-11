using System.Collections.Generic;

namespace Mastermind
{
    public class Attempt
    {
        private readonly Color[] _guess;
        private readonly List<Color> _result;

        public Attempt(Color[] guess, List<Color> result)
        {
            _guess = guess;
            _result = result;
        }
    }
}