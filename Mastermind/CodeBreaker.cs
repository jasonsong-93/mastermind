using System.Collections.Generic;
using System.Linq;

namespace Mastermind
{
    public class CodeBreaker : ICodeBreaker

    {
        private readonly IUserInput _userInput;

        public CodeBreaker(IUserInput userInput)
        {
            _userInput = userInput;
        }

        public List<Attempt> GetGuessHistory()
        {
            throw new System.NotImplementedException();
        }

        public bool CodeBroken(Color[] solution)
        {
            return solution.SequenceEqual(_userInput.GetUserGuess());
        }
    }
}