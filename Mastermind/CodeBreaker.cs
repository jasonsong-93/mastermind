using System;
using System.Collections.Generic;
using System.Linq;
using Mastermind.IO;

namespace Mastermind
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
            _userOutput.DisplayCodeBreaker();
            _userOutput.DisplayBoard(Attempts);
            var guess = _userInput.PlayerGuess(numPegs);
            var result = CalculateResult(guess, solution);
            var attempt = new Attempt(guess, result);
            Attempts.Add(attempt);
            if (!solution.SequenceEqual(guess))
            {
                _userOutput.DisplayNotMatchingResult(result);
                return false;
            }
            return true;
        }

        private static List<ResultColor> CalculateResult(Color[] guess, Color[] solution)
        {
            var solutionColorFrequencyDictionary = solution.GroupBy(x => x).ToDictionary(x =>
                x.Key, x => x.Count());
            var result = new List<ResultColor>();
            for (var i = 0; i < guess.Length; ++i)
            {
                var containsKey = solutionColorFrequencyDictionary.ContainsKey(guess[i]);
                if (containsKey)
                {
                    var frequencyGreaterThanZero = solutionColorFrequencyDictionary[guess[i]] > 0;
                    if (frequencyGreaterThanZero)
                    {
                        if (solution[i] == guess[i])
                        {
                            result.Add(ResultColor.Black);
                            DecrementFrequency(solutionColorFrequencyDictionary, guess[i]);
                        }
                        else
                        {
                            result.Add(ResultColor.White);
                            DecrementFrequency(solutionColorFrequencyDictionary, guess[i]);
                        }
                    }
                }
            }
            return result;
        }

        private static void DecrementFrequency(Dictionary<Color, int> dictionary, Color keyToDecrement)
        {
            dictionary[keyToDecrement]--;
        }
    }
}