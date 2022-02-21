using System.Collections.Generic;

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
            throw new System.NotImplementedException();
        }
    }
}