using System.Collections.Generic;

namespace Mastermind
{
    public class Attempt
    {
        public readonly Color[] Guess;
        public readonly List<ResultColor> Result;

        public Attempt(Color[] guess, List<ResultColor> result)
        {
            Guess = guess;
            Result = result;
        }
    }
}