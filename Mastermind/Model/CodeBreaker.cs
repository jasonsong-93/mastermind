using System.Collections.Generic;
using System.Linq;
using Mastermind.IO.Interfaces;
using Mastermind.Model.Interfaces;

namespace Mastermind.Model
{
    public class CodeBreaker : ICodeBreaker
    {
        private readonly IUserInput _userInput;
        private readonly IUserOutput _userOutput;
        public List<Attempt> Attempts { get; }

        public CodeBreaker(IUserInput userInput, IUserOutput userOutput)
        {
            _userInput = userInput;
            _userOutput = userOutput;
            Attempts = new List<Attempt>();
        }

        public bool CodeBroken(Color[] solution, int numPegs)
        {
            CodeBreakerDisplay();
            var guess = _userInput.PlayerGuess(numPegs);
            var result = Utils.ColourCalculator.CalculateResult(guess, solution);
            var attempt = new Attempt(guess, result);
            Attempts.Add(attempt);
            if (solution.SequenceEqual(guess)) return true;
            _userOutput.DisplayNotMatchingResult(result);
            return false;
        }

        private void CodeBreakerDisplay()
        {
            _userOutput.DisplayCodeBreaker();
            _userOutput.DisplayBoard(Attempts);
        }
    }
}