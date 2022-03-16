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
            var guessColorFrequencyDictionary = guess.GroupBy(x => x).ToDictionary(x =>
                x.Key, x => x.Count());
            var result = new List<ResultColor>();
            var resultSize = solution.Length;
            
            
            // Resolve all the black elements first
            for (var i = 0; i < resultSize; ++i)
            {
                // iterate through both the solution and guess
                // arrays, add black values in and decrement corresponding values from both dictionaries
                if (guess[i] == solution[i])
                {
                    DecrementFrequency(solutionColorFrequencyDictionary, guess[i]);
                    DecrementFrequency(guessColorFrequencyDictionary, guess[i]);
                    result.Add(ResultColor.Black);
                }
            }
            // Resolve white elements that exist afterwards
            foreach (var kvp in solutionColorFrequencyDictionary)
            {
                var colorFromSolution = kvp.Key;
                if (solutionColorFrequencyDictionary.ContainsKey(colorFromSolution))
                {
                    var numWhites = Math.Min(solutionColorFrequencyDictionary[colorFromSolution],
                        guessColorFrequencyDictionary[colorFromSolution]);
                    for (int i = 0; i < numWhites; i++)
                    {
                        result.Add(ResultColor.White);
                    }
                }
            }
            result.ShuffleMe();
            return result;
        }

        private static void DecrementFrequency(Dictionary<Color, int> dictionary, Color keyToDecrement)
        {
            dictionary[keyToDecrement]--;
        }
    }
}