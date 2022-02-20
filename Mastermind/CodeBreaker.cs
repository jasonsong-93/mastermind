using System.Collections.Generic;

namespace Mastermind
{
    public class CodeBreaker : ICodeBreaker

    {
        public CodeBreaker(IUserInput userInput)
        {
        }

        public List<Attempt> GetGuessHistory()
        {
            throw new System.NotImplementedException();
        }

        public bool CheckGuess(Color[] solution)
        {
            throw new System.NotImplementedException();
        }

        public bool CodeBroken()
        {
            throw new System.NotImplementedException();
        }
    }
}